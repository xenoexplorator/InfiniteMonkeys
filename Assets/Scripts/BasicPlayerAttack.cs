using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerAttack : JamObject {

	public int damage;

	public int timer;
	private int spentTime;
	
	// Update is called once per frame
	void Update () {
		if (spentTime > timer)
			Destroy (this.gameObject);
		
		spentTime++;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "ENEMY")
			other.SendMessage ("TakeDamage", damage);
	}
}
