using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterASecond : MonoBehaviour {

	private int MAX_FRAMES = 120;
	private int currentFrames = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		currentFrames++;
		if (currentFrames >= MAX_FRAMES)
			Destroy (this.gameObject);
	}
}
