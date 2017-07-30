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
	// Update is called once per frame
	public void Update () {
		isInRangeToPlayer = Vector3.Distance (this.transform.position, PlayerController.playerPosition) < DISTANCE_TO_INSULT ? true : false;
		if(isInRangeToPlayer) {
			PlayerController.princessInRange = this;
		}

		if (isInRangeToPlayer && !quippedHello) {
			Quip (QuipsCollection.WelcomeQuips[QuipsCollection.Welcome]);
			QuipsCollection.Welcome++;
			quippedHello = true;
		}
		if (QuipsCollection.Welcome == 2 && !textBubble.activeSelf) {
			var medaille = GameObject.FindWithTag("Medaille");
			var follower = medaille.GetComponent<FollowObiject>();
			if (follower.toFollow == null) {
				var player = GameObject.FindWithTag("Player");
				follower.SetToFollow(player, 0.01f);
			}
		}
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
		
	protected void Quip(string speach)
	{
		text.text = speach;
		var hider = textBubble.GetComponent<AutoHide> ();
		hider.UnHide ();
	}
}
