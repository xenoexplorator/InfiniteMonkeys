using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : JamObject {

	private const int NONATTACK_WINDUP = 10;
	private const int WINDUP_LENGTH = 5;
	private float distanceToPlayer;
	private float distanceToStart;
	private bool aggroed = false;
	private Vector3 startingLocation;
	private bool hasBeenLeashed;
	private int attackCooldown = 0;
	private int attackWindup = 10;

	public float baseSpeed;
	public float AggroDistance;
	public float LeashDistance;
	public float attackRange;
	public int health;
	public float anglePadding = 20;
	public GameObject Attack;

	// Use this for initialization
	void Start () {
		startingLocation = this.transform.position;
		speed = baseSpeed;
	}
	
	// Update is called once per frame
	void Update() {
		var distanceToPlayer = Vector3.Distance (this.transform.position, PlayerController.playerPosition);
		UpdateMovement(distanceToPlayer);
		UpdateAttack(distanceToPlayer);
	}
	
	void UpdateMovement(float distanceToPlayer) {
		distanceToStart = Mathf.Abs(Vector3.Distance (this.transform.position, this.startingLocation));
		if (distanceToStart > LeashDistance)
			hasBeenLeashed = true;
		aggroed = distanceToPlayer < AggroDistance && !hasBeenLeashed;

		speed = baseSpeed * (aggroed ? 1.0f : 0.5f) * (attackWindup < NONATTACK_WINDUP ? 0.0f : 1.0f);

		if (aggroed) {
			_direction = PlayerController.playerPosition - this.transform.position;
		} 
		else { //U dun' kiting bro
			_direction = startingLocation - this.transform.position;
		}
		_direction.Normalize ();
		direction += Random.Range (-anglePadding, anglePadding);
		Move ();
		if (distanceToStart < AggroDistance)
			hasBeenLeashed = false;
	}

	void UpdateAttack(float distanceToPlayer) {
		if (distanceToPlayer < attackRange
				&& attackCooldown == 0
				&& !hasBeenLeashed) {
			attackWindup = WINDUP_LENGTH;
		}
		if (attackWindup < NONATTACK_WINDUP) {
			if (attackWindup == 0) {
				Instantiate(Attack, this.transform.position + _direction * attackRange/2, Quaternion.identity);
				attackWindup = NONATTACK_WINDUP;
				attackCooldown = 30;
			} else {
				attackWindup -= 1;
			}
		} else if (attackCooldown > 0) {
			attackCooldown -= 1;
		}
	}

	public void TakeDamage(int dmg)
	{
		health -= dmg;
		if (health <= 0)
			Destroy (this.gameObject);
	}
}
