using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpecialType
{
	AOE,
	TELEPORT,
	SHIELD,
	HEAL
}

public class PrincessTrashcan : JamObject {

	public const float DISTANCE_TO_INSULT = 5f;
	public static int numberOfHelpReceived = 0;

	private bool isInRangeToPlayer = false;
	private bool quippedHello = false;
	public bool helped = false;
	public string helloQuip = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		isInRangeToPlayer = Vector3.Distance (this.transform.position, PlayerController.playerPosition) < DISTANCE_TO_INSULT ? true : false;
		if(isInRangeToPlayer)
			PlayerController.princessInRange = this;

		if (isInRangeToPlayer && !quippedHello) {
			Quip (helloQuip);
			quippedHello = true;
		}
	}

	public void HelpedWith(SpecialType type)
	{
		helped = true;
		numberOfHelpReceived++;
		Quip ("Now who's in distress?");
	}

	void Quip(string speach)
	{
		Debug.Log (speach);
	}
}
