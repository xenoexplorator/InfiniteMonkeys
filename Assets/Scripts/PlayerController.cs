using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : JamObject {

	public static Vector3 playerPosition;

	public const int MAX_HEALTH = 100;

	private  float verticalSpeed = 0;
	private float horizontalSpeed = 0;
	private int wKey = 0;
	private int aKey = 0;
	private int sKey = 0;
	private int dKey = 0;

	private int health = MAX_HEALTH;

	public float baseSpeed;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		wKey = Input.GetKey (KeyCode.W) ? 1 : 0;
		aKey = Input.GetKey (KeyCode.A) ? 1 : 0;
		sKey = Input.GetKey (KeyCode.S) ? 1 : 0;
		dKey = Input.GetKey (KeyCode.D) ? 1 : 0;
		speed = Input.GetKey (KeyCode.LeftShift) ? baseSpeed * 2 : baseSpeed;

		verticalSpeed = wKey - sKey;
		horizontalSpeed = dKey - aKey;

		if (horizontalSpeed != 0 || verticalSpeed != 0) {
			direction = (Mathf.Atan2 (verticalSpeed, horizontalSpeed)) * 180 / Mathf.PI;
			Move ();
			playerPosition = this.transform.position;
		}

	}

	void Attack()
	{
		//Who knows what will happen here. Not me, at least.
	}

	public bool ShieldAvailable = true;
	public bool ShieldUp = false;
	void SpecialShield()
	{
		ShieldAvailable = false;
		ShieldUp = true;
	}
		
	public void TakeDamage(int dmg)
	{
		health -= dmg;
		if (ShieldUp) {
			ShieldUp = false;
			return;
		}
		if (health <= 0)
			GameOver ();
	}

	private bool FullHealAvailable = true;
	void SpecialFullHeal()
	{
		health = MAX_HEALTH;
		FullHealAvailable = false;
	}

	public void GameOver()
	{
	}
}
