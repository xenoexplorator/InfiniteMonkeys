using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : JamObject {

	public static Vector3 playerPosition;

	public const int MAX_HEALTH = 100;
	public const float ATTACK_DISTANCE = 0.8f;

	public GameObject basicAttackPrefab;

	private  float verticalSpeed = 0;
	private float horizontalSpeed = 0;
	private int wKey = 0;
	private int aKey = 0;
	private int sKey = 0;
	private int dKey = 0;
	private int spaceKey = 0;

	private int health = MAX_HEALTH;

	public float baseSpeed;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		GetInputs ();
		verticalSpeed = wKey - sKey;
		horizontalSpeed = dKey - aKey;

		if (horizontalSpeed != 0 || verticalSpeed != 0) {
			direction = (Mathf.Atan2 (verticalSpeed, horizontalSpeed)) * 180 / Mathf.PI;
			Move ();
			playerPosition = this.transform.position;
		}

		if (spaceKey == 1)
			Attack ();
	}

	void GetInputs()
	{
		wKey = Input.GetKey (KeyCode.W) ? 1 : 0;
		aKey = Input.GetKey (KeyCode.A) ? 1 : 0;
		sKey = Input.GetKey (KeyCode.S) ? 1 : 0;
		dKey = Input.GetKey (KeyCode.D) ? 1 : 0;
		speed = Input.GetKey (KeyCode.LeftShift) ? baseSpeed * 2 : baseSpeed;
		spaceKey = Input.GetKeyDown (KeyCode.Space) ? 1 : 0;
	}

	void Attack()
	{
		Instantiate (basicAttackPrefab, (this.transform.position + (_direction * ATTACK_DISTANCE)), Quaternion.identity);
		//Who knows what will happen here. Not me, that's for sure.
	}

	
	//Shield Logic. Do we even have a shield?
	public bool ShieldAvailable = true;
	private bool ShieldUp = false;
	private int ShieldUsed = 0;
	private int ShieldMaxDamage = 3;
	void SpecialShield()
	{
		ShieldAvailable = false;
		ShieldUp = true;
	}
		
	//I guessed this is how we should take damage
	public void TakeDamage(int dmg)
	{
		health -= dmg;
		if (ShieldUp) {
			ShieldUsed++;
			ShieldUp = ShieldUsed >= ShieldMaxDamage ? false : true;
			return;
		}
		if (health <= 0)
			GameOver ();
	}

	//FULL HEAL!!!
	private bool FullHealAvailable = true;
	void SpecialFullHeal()
	{
		health = MAX_HEALTH;
		FullHealAvailable = false;
	}

	//Shhhhhh, Shhhhhhhh, it's all over now
	public void GameOver()
	{
	}
}
