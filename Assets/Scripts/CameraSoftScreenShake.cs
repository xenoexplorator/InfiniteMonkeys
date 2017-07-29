using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSoftScreenShake : MonoBehaviour {

	public GameObject something; // set this via inspector
	public float shake = 0;
	public float shakeAmount = 0.7f;

	void Update() {
		var test = Random.insideUnitSphere * shakeAmount;
		something.transform.localPosition = Random.insideUnitSphere * shakeAmount;
	}

}
