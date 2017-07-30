using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObiject : JamObject {

	public GameObject toFollow;

	// Update is called once per frame
	void Update () {
		if (toFollow != null) {
			Vector3 lerped = Vector3.Lerp (this.transform.position, toFollow.transform.position, speed);
			this.X = lerped.x;
			this.Y = lerped.y;
		}
	}

	public void StartFollow(float spd) {
		speed = spd;
	}
}
