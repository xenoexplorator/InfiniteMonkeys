using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuipsCollection : MonoBehaviour {
	public static List<string> WelcomeQuips = new List<string> ();
	public static List<string> ReloadedHealing = new List<string> ();
	public static List<string> ReloadedAOE = new List<string> ();
	public static List<string> ReloadedTeleport = new List<string> ();
	public static List<string> ReloadedArmor = new List<string> ();
	public static bool initiated = false;
	public static int Welcome = 0;
	public static int AOE = 0;
	public static int HEAL = 0;
	public static int TELEPORT = 0;
	public static int ARMOR = 0;

	public static void ResetCollections()
	{
		WelcomeQuips.Clear ();
		ReloadedAOE.Clear ();
		ReloadedArmor.Clear ();
		ReloadedHealing.Clear ();
		ReloadedTeleport.Clear ();
		initiated = false;
		Welcome = 0;
		AOE = 0;
		HEAL = 0;
		TELEPORT = 0;
		ARMOR = 0;
	}

	void Start()
	{
		ResetCollections ();

		WelcomeQuips.Add (@"Are you here to save me? No thanks, I'm fine here."); 
		WelcomeQuips.Add (@"Oh, it's you again. What, do you want a medal or something?"); 
		WelcomeQuips.Add (@"There, I found a medal. Take it if you want."); 
		WelcomeQuips.Add (@"You know what? That medal really suits you."); 
		WelcomeQuips.Add (@"One man's trash is another princess's.... trash?");

		ReloadedHealing.Add (@"I'm sure you'll need that again.");
		ReloadedHealing.Add (@"I told you you'd need it again.");
		ReloadedHealing.Add (@"That won't fix your face you know.");
		ReloadedHealing.Add (@"Make it through this and I'll unlock easy mode for you.");
		ReloadedHealing.Add (@"This is getting humiliating for you...");

		ReloadedAOE.Add (@"Did your last one miss?");
		ReloadedAOE.Add (@"You should try something else if you can't aim.");
		ReloadedAOE.Add (@"That not the only attack you can use you know...");
		ReloadedAOE.Add (@"Are you compensating for something?");
		ReloadedAOE.Add (@"This is getting humiliating for you...");

		ReloadedTeleport.Add (@"Bit of a tough spot back there?");
		ReloadedTeleport.Add (@"Come on, those things aren't that hard to kill.");
		ReloadedTeleport.Add (@"Oh, I see. You're just afraid of them.");
		ReloadedTeleport.Add (@"You can't run away forever, you know.");
		ReloadedTeleport.Add (@"This is getting humiliating for you...");

		ReloadedArmor.Add (@"Now who's in distress.");
		ReloadedArmor.Add (@"Who ever heard of a knight who needed a princess to protect him anyway?");
		ReloadedArmor.Add (@"You can't always rely on that you know.");
		ReloadedArmor.Add (@"You really need to learn how to dodge.");
		ReloadedArmor.Add (@"This is getting humiliating for you...");

		initiated = true;
	}
}
