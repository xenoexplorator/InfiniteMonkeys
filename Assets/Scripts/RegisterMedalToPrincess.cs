using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterMedalToPrincess : JamObject {

	// Use this for initialization
	void Start () {
		PrincessTrashcan.medaille = this.gameObject;
	}

}
