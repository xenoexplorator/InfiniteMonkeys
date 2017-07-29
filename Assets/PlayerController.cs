using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : JamObject {

	private  float verticalSpeed = 0;
	private float horizontalSpeed = 0;
	private int wKey = 0;
	private int aKey = 0;
	private int sKey = 0;
	private int dKey = 0;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		wKey = Input.GetKey (KeyCode.W) ? 1 : 0;
		aKey = Input.GetKey (KeyCode.A) ? 1 : 0;
		sKey = Input.GetKey (KeyCode.S) ? 1 : 0;
		dKey = Input.GetKey (KeyCode.D) ? 1 : 0;

		verticalSpeed = wKey - sKey;
		horizontalSpeed = dKey - aKey;

		if (horizontalSpeed != 0 || verticalSpeed != 0) {
			direction = (Mathf.Atan2 (verticalSpeed, horizontalSpeed)) * 180 / Mathf.PI;
			Move ();
		}
	}
}
