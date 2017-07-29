using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObiject : JamObject {

	public JamObject toFollow;

	// Update is called once per frame
	void Update () {
		if (toFollow != null) {
			Vector3 lerped = Vector3.Lerp (this.transform.position, toFollow.transform.position, 0.1f);
			this.X = lerped.x;
			this.Y = lerped.y;
//
//			this.X = toFollow.X;
//			this.Y = toFollow.Y;
		}
	}
}
