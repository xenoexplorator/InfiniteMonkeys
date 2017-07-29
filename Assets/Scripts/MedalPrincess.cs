using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedalPrincess : PrincessTrashcan {

	public JamObject medaille;
	public float medailleSpeed = 0.01f;
	public bool medailleGiven = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		if (helped && !medailleGiven)
			StartCoroutine ("GiveMedal");
	}

	IEnumerator GiveMedal()
	{
		yield return new WaitForSecondsRealtime (2);
		Quip ("Congrats, you needed my help! Have a medal.");
		medaille.speed = medailleSpeed;
	}
}
