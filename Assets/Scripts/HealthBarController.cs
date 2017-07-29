using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

	public Image healthbar;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		var theBarRectTransform = healthbar.transform as RectTransform;
		theBarRectTransform.sizeDelta = new Vector2 (PlayerController.health*2, theBarRectTransform.sizeDelta.y);
	}


}
