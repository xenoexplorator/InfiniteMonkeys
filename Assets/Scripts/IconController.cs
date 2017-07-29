using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconController : MonoBehaviour {

	public Image AOE;
	public Image Heal;
	public Image armor;
	public Image teleport;

	public Sprite AOEAvailable;
	public Sprite AOENotAvailable;

	public Sprite HealAvailable;
	public Sprite HealNotAvailable;

	public Sprite armorAvailable;
	public Sprite armorNotAvailable;

	public Sprite teleportAvailable;
	public Sprite teleportNotAvailable;

	void Update()
	{
		if (PlayerController.AOEAvailable)
			AOE.sprite = AOEAvailable;
		else
			AOE.sprite = AOENotAvailable;

		if (PlayerController.FullHealAvailable)
			Heal.sprite = HealAvailable;
		else
			Heal.sprite = HealNotAvailable;

		if (PlayerController.ShieldAvailable)
			armor.sprite = armorAvailable;
		else
			armor.sprite = armorNotAvailable;

		if (PlayerController.TeleportAvailable)
			teleport.sprite = teleportAvailable;
		else
			teleport.sprite = teleportNotAvailable;
	}
}
