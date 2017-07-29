using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : JamObject {

	private float distanceToPlayer;
	private  bool aggroed = false;
	private Vector3 startingLocation;

	public float AggroDistance;
	public int health;

	// Use this for initialization
	void Start () {
		startingLocation = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		distanceToPlayer = Vector3.Distance (this.transform.position, PlayerController.playerPosition);
		aggroed = distanceToPlayer < AggroDistance ? true : false;
	}
}
