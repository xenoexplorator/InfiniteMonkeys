using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : JamObject {

	public int damage;

	public int timer;
	private int spentTime;
	
	// Update is called once per frame
	void Update () {
		if (spentTime > timer)
			Destroy (this.gameObject);
		if (_direction.x > 0)
			GetComponent<SpriteRenderer> ().flipX = true;
		
		spentTime++;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			other.SendMessage ("TakeDamage", damage);
	}
}
