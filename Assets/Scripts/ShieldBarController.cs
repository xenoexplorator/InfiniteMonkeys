using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBarController : MonoBehaviour {

	public Image shieldBar;

	// Update is called once per frame
	void Update () {
		if (PlayerController.ShieldUp) {
			var theBarRectTransform = shieldBar.transform as RectTransform;
			theBarRectTransform.sizeDelta = new Vector2 (200 - (150 * PlayerController.currentShieldFrames / 100), theBarRectTransform.sizeDelta.y);
		} else {
			var theBarRectTransform = shieldBar.transform as RectTransform;
			theBarRectTransform.sizeDelta = new Vector2 (0, theBarRectTransform.sizeDelta.y);
		}
	}
}
