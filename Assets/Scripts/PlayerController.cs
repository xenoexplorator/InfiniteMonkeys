using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : JamObject {

	public static Vector3 playerPosition;
	public static bool reloadAvailable = false;
	public static PrincessTrashcan princessInRange;

	public const int MAX_HEALTH = 100;
	public const float ATTACK_DISTANCE = 1.8f;

	public GameObject basicAttackPrefab;
	public GameObject aimCursorObject;
	public float baseSpeed;
	public Animator anim;
	public SpriteRenderer sprRender;

	public GameObject teleportAnimation;
	public GameObject shieldAnimation;
	public GameObject healingAnimation;

	#region Properties
	private  float verticalSpeed = 0;
	private float horizontalSpeed = 0;
	private int wKey = 0;
	private int aKey = 0;
	private int sKey = 0;
	private int dKey = 0;
	private int spaceKey = 0;
	private Vector3 mouseRealPosition;
	public static int health = MAX_HEALTH;
	#endregion

	void Start()
	{
		health = MAX_HEALTH;
	}

	// Update is called once per frame
	void Update () {

		GetInputs ();
		verticalSpeed = wKey - sKey;
		horizontalSpeed = dKey - aKey;

		if (horizontalSpeed != 0) {
			anim.SetTrigger ("side_walk_right");
			if (horizontalSpeed == -1)
				sprRender.flipX = true;
			else if (horizontalSpeed == 1)
				sprRender.flipX = false;
		} else if (verticalSpeed != 0) {
			if (verticalSpeed == 1)
				anim.SetTrigger ("back");
			else
				anim.SetTrigger ("front");
		}
		else
			anim.SetTrigger ("idle");

		playerPosition = this.transform.position;

		if (horizontalSpeed != 0 || verticalSpeed != 0) {
			direction = (Mathf.Atan2 (verticalSpeed, horizontalSpeed)) * 180 / Mathf.PI;
			Move ();
		}

		if (spaceKey == 1)
			Attack ();

		if (princessInRange != null && princessInRange.helped == false)
			CheckForReloads ();
		else
			UseSpecials ();

		UpdateShield ();
		princessInRange = null;
	}

	void CheckForReloads()
	{
		if (Input.GetKeyDown (KeyCode.E) && !AOEAvailable){
			AOEAvailable = true;
			princessInRange.HelpedWith (SpecialType.AOE);
		}

		if (Input.GetKeyDown (KeyCode.F) && !FullHealAvailable){
			FullHealAvailable = true;
			princessInRange.HelpedWith (SpecialType.HEAL);
		}

		if (Input.GetMouseButtonDown (1) && !TeleportAvailable){
			TeleportAvailable = true;
			princessInRange.HelpedWith (SpecialType.TELEPORT);
		}

		if (Input.GetMouseButtonDown (2) && !ShieldAvailable){
			ShieldAvailable = true;
			princessInRange.HelpedWith (SpecialType.SHIELD);
		}

	}

	void UseSpecials()
	{
		if (Input.GetKeyDown (KeyCode.E)) {
			if (AOEAvailable) {
				if (isAimingAOE)
					StopAimingAOE ();
				else
					PrepareForAOEAttack ();
			}
		}
		if (isAimingAOE)
			PrepareForAOEAttack ();

		if (Input.GetKeyDown (KeyCode.F) && FullHealAvailable)
			SpecialFullHeal ();

		if (Input.GetMouseButtonDown (1) && TeleportAvailable)
			TeleportSpecial ();

		if (Input.GetMouseButtonDown (2) && ShieldAvailable)
			SpecialShield ();
	}

	void GetInputs()
	{
		wKey = Input.GetKey (KeyCode.W) ? 1 : 0;
		aKey = Input.GetKey (KeyCode.A) ? 1 : 0;
		sKey = Input.GetKey (KeyCode.S) ? 1 : 0;
		dKey = Input.GetKey (KeyCode.D) ? 1 : 0;
		speed = baseSpeed;
		spaceKey = Input.GetKeyDown (KeyCode.Space) ? 1 : 0;
	}

	void OnGUI()
	{
		Camera  c = Camera.main;
		Event   e = Event.current;
		Vector2 mousePos = new Vector2();

		// Get the mouse position from Event.
		// Note that the y position from Event is inverted.
		mousePos.x = e.mousePosition.x;
		mousePos.y = c.pixelHeight - e.mousePosition.y;

		mouseRealPosition = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, c.nearClipPlane));
	}

	void Attack()
	{
		var attack = Instantiate (basicAttackPrefab, (this.transform.position + (_direction * ATTACK_DISTANCE)), Quaternion.identity);
		if (_direction.x < 0)
			attack.GetComponent<SpriteRenderer> ().flipX = false;
		anim.SetTrigger ("side_attack");
	}

	//I guessed this is how we should take damage
	public void TakeDamage(int dmg)
	{
		if (ShieldUp) {
			currentShieldFrames += 30;
			if (ShieldUp && currentShieldFrames > ShieldMaxFrames)
				ShieldUp = false;
			if (!ShieldUp)
				StopShield ();
			return;
		}
		else
			health -= dmg;
		if (health <= 0)
			GameOver ();
	}

	#region Specials!
	#region AOE Attack
	public static bool AOEAvailable = true;
	private bool isAimingAOE = false;
	private GameObject _aimCursor;
	void PrepareForAOEAttack()
	{
		if (isAimingAOE) {
			_aimCursor.transform.position = new Vector3 (mouseRealPosition.x, mouseRealPosition.y);
			if (Input.GetMouseButtonDown (0))
				AOEAttack ();
		} else {
			isAimingAOE = true;
			_aimCursor = Instantiate (aimCursorObject, new Vector3(mouseRealPosition.x, mouseRealPosition.y), Quaternion.identity);
		}
	}

	void StopAimingAOE()
	{
		isAimingAOE = false;
		if (_aimCursor != null)
			Destroy (_aimCursor);
	}

	void AOEAttack()
	{
		var attack = Instantiate (basicAttackPrefab, (this.transform.position + (_direction * ATTACK_DISTANCE)), Quaternion.identity);
		attack.transform.position = new Vector3(mouseRealPosition.x,mouseRealPosition.y,0);
		attack.transform.localScale = new Vector3 (5, 5, 0);
		AOEAvailable = false;
		StopAimingAOE ();
	}
	#endregion


	#region Shield
	//Shield Logic. Do we even have a shield?
	public static bool ShieldAvailable = true;
	public static bool ShieldUp = false;
	private int ShieldUsedSoaks = 0;
	private int ShieldMaxDamage = 3;
	private int ShieldMaxFrames = 300;
	public static int currentShieldFrames = 0;

	private GameObject shieldObject;
	void SpecialShield()
	{
		ShieldAvailable = false;
		ShieldUp = true;
		ShieldUsedSoaks = 0;
		shieldObject = Instantiate (shieldAnimation, this.transform);
	}

	void UpdateShield()
	{
		currentShieldFrames = ShieldUp ? currentShieldFrames+1 : 0;
		if (currentShieldFrames > ShieldMaxFrames)
			StopShield ();
	}

	void StopShield()
	{
		ShieldUp = false;
		ShieldUsedSoaks = 0;
		currentShieldFrames = 0;
		Destroy (shieldObject);
	}
	#endregion	

	#region teleport
	public static bool TeleportAvailable = true;
	void TeleportSpecial()
	{
		X = mouseRealPosition.x;
		Y = mouseRealPosition.y;
		TeleportAvailable = false;
		Instantiate (teleportAnimation, this.transform);
	}
	#endregion

	#region FullHeal
	//FULL HEAL!!!
	public static bool FullHealAvailable = true;
	void SpecialFullHeal()
	{
		health = MAX_HEALTH;
		FullHealAvailable = false;
		Instantiate (healingAnimation, this.transform);
	}
	#endregion

	#endregion



	//Shhh, Shhhhhhhh, it's all over now
	public void GameOver()
	{
	}
}
