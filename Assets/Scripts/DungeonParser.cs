using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DungeonParser : MonoBehaviour {

	public GameObject[] TileMap;
	public char[] TileIDs;
	public TextAsset Fichier;

	public void Start() {
		Parse();
	}
	public void Update() { }

	public void Parse() {
		var scale = 1f;
		var y = 0f;
		var lines = Fichier.text.Split(new[] { "\n" }, StringSplitOptions.None);
		foreach (var line in lines) {
			Debug.Log(line);
			float x = 0f;
			foreach (char c in line) {
				var id = Array.IndexOf(TileIDs, c);
				Instantiate(TileMap[id], new Vector3(x, y, 0), Quaternion.identity);
				x += scale;
			}
			y += scale;
		}
	}
}
