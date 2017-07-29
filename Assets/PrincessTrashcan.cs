using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	public GameObject textBubble;
	public Text text;

	private bool isInRangeToPlayer = false;
	private bool quippedHello = false;
	public bool helped = false;

	// Use this for initialization
	void Start () {
		
	}
	private int frameTimer = 0;
	private int maxFramesForQuip = 250;
	// Update is called once per frame
	void Update () {
		isInRangeToPlayer = Vector3.Distance (this.transform.position, PlayerController.playerPosition) < DISTANCE_TO_INSULT ? true : false;
		if(isInRangeToPlayer)
			PlayerController.princessInRange = this;

		if (isInRangeToPlayer && !quippedHello) {
			Quip (QuipsCollection.WelcomeQuips[QuipsCollection.Welcome]);
			QuipsCollection.Welcome++;
			quippedHello = true;
		}
		UpdateQuip ();
	}

	public void HelpedWith(SpecialType type)
	{
		helped = true;
		numberOfHelpReceived++;
		switch (type)
		{
		case SpecialType.AOE:
			Quip (QuipsCollection.ReloadedAOE [QuipsCollection.AOE]);
			QuipsCollection.AOE++;
			break;
		case SpecialType.HEAL:
			Quip (QuipsCollection.ReloadedHealing [QuipsCollection.HEAL]);
			QuipsCollection.HEAL++;
			break;
		case SpecialType.SHIELD:
			Quip (QuipsCollection.ReloadedArmor [QuipsCollection.ARMOR]);
			QuipsCollection.ARMOR++;
			break;
		case SpecialType.TELEPORT:
			Quip (QuipsCollection.ReloadedTeleport [QuipsCollection.TELEPORT]);
			QuipsCollection.TELEPORT++;
			break;
		default:
			break;
		}
	}
		
	void UpdateQuip()
	{
		if (textBubble.activeSelf)
			frameTimer++;
		if (frameTimer > maxFramesForQuip)
			textBubble.SetActive (false);
	}

	void Quip(string speach)
	{
		textBubble.SetActive (true);
		frameTimer = 0;
		text.text = speach;
	}
}
