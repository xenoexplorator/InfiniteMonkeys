using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHide : MonoBehaviour {

	public int DisplayTime;
	private int countdown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (countdown > 0) {
			countdown -= 1;
		} else {
			gameObject.SetActive(false);
		}
	}

	public void UnHide() {
		countdown = DisplayTime;
		gameObject.SetActive(true);
	}
}
