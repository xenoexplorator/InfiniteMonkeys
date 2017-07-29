using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObiject : JamObject {

	public JamObject toFollow;

	// Update is called once per frame
	void Update () {
		if (toFollow != null) {
			this.X = toFollow.X;
			this.Y = toFollow.Y;
		}
	}
}
