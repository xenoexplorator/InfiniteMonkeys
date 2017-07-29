using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DungeonParser : MonoBehaviour {

	public TextAsset Fichier;
	public float step;
	public GameObject[] Spawns;
	public GameObject[] TileMap;
	public char[] TileIDs;

	private GameObject player;

	public void Start() {
		player = GameObject.FindWithTag("Player");
		Parse();
	}
	public void Update() { }

	public void Parse() {
		var y = 0f - 8*step;
		var lines = Fichier.text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
		foreach (var line in lines) {
			y += step;
			float x = 0f - 8*step;
			foreach (char c in line) {
				x += step;
				if (c == ' ') continue; // empty tile
				else if (c == '0') { // player spawn
					Instantiate(TileMap[4], new Vector3(x, -y, 0), Quaternion.identity);
					player.transform.position = new Vector3(x, -y, 0);
				} else {
					var id = Array.IndexOf(TileIDs, c);
					if (id == -1) Debug.Log(c);
					// File line numbers and Unity y-coordinate are in opposite directions
					Instantiate(TileMap[id], new Vector3(x, -y, 0), Quaternion.identity);
				}
			}
		}
	}
}
