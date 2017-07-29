using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : JamObject {

	private float distanceToPlayer;
	private float distanceToStart;
	private bool aggroed = false;
	private Vector3 startingLocation;

	public float baseSpeed;
	public float AggroDistance;
	public float LeashDistance;
	public int health;
	public float anglePadding = 20;

	// Use this for initialization
	void Start () {
		startingLocation = this.transform.position;
		speed = baseSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		distanceToPlayer = Mathf.Abs(Vector3.Distance (this.transform.position, PlayerController.playerPosition));
		distanceToStart = Mathf.Abs(Vector3.Distance (this.transform.position, this.startingLocation));
		aggroed = distanceToPlayer < AggroDistance ? true : false;

		speed = aggroed ? baseSpeed : baseSpeed / 2;

		if (aggroed) {
			_direction = PlayerController.playerPosition - this.transform.position;
		} 
		else { //U dun' kiting bro
			_direction = startingLocation - this.transform.position;
		}
		_direction.Normalize ();
		direction += Random.Range (-anglePadding, anglePadding);
		Move ();
	}
}
