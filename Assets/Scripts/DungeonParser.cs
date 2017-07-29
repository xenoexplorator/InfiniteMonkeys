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
		var step = 0.64f;
		var y = 0f;
		var lines = Fichier.text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
		foreach (var line in lines) {
			float x = 0f;
			foreach (char c in line) {
				var id = Array.IndexOf(TileIDs, c);
				Instantiate(TileMap[id], new Vector3(x, y, 0), Quaternion.identity);
				x += step;
			}
			y += step;
		}
	}
}
