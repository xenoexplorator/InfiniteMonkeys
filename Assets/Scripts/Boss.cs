using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {
	private BasicEnemy monster;
	private bool musicStarted = false;
	public AudioClip music;

	// Use this for initialization
	void Start () {
		monster = gameObject.GetComponent<BasicEnemy>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!musicStarted && monster.distanceToPlayer < 10) {
			var camera = GameObject.FindWithTag("MainCamera");
			var audio = camera.GetComponent<AudioSource>();
			//audio.clip = music;
			musicStarted = true;
		}
		if (monster.health <= 0) {
			SceneManager.LoadScene("Victory");
		}
	}
}
