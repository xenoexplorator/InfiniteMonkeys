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


	void Start()
	{
		WelcomeQuips.Add (@"Are you here to save me? No thanks, I'm fine here."); 
		WelcomeQuips.Add (@"Oh, it's you again. What, do you want a medal or something?"); 
		WelcomeQuips.Add (@"There, I found a medal. Take it if you want."); 
		WelcomeQuips.Add (@"You know what? That medal really suits you."); 
		WelcomeQuips.Add (@"One man's trash is another princess's.... trash?");

		ReloadedHealing.Add (@"Yeah you seem to need it.");
		ReloadedHealing.Add (@"That again? Okay.");
		ReloadedHealing.Add (@"Who's in distress now?");
		ReloadedHealing.Add (@"If you make it through I'll unlock easy mode for you.");
		ReloadedHealing.Add (@"This is getting humiliating for you...");

		ReloadedAOE.Add (@"Blow them up!");
		ReloadedAOE.Add (@"Soooo.... did you miss? Is that why you pick it up again?");
		ReloadedAOE.Add (@"You could just attack regularly for once.");
		ReloadedAOE.Add (@"You know this isn't your only power, right?");
		ReloadedAOE.Add (@"This is getting humiliating for you...");

		ReloadedTeleport.Add (@"When in a though spot...");
		ReloadedTeleport.Add (@"A bit shy, I see.");
		ReloadedTeleport.Add (@"Have you tried fighting?");
		ReloadedTeleport.Add (@"You know, you can't win by running away.");
		ReloadedTeleport.Add (@"This is getting humiliating for you...");

		ReloadedArmor.Add (@"Always use protection.");
		ReloadedArmor.Add (@"I said always but I didn't mean it that much.");
		ReloadedArmor.Add (@"This won't save you all the time.");
		ReloadedArmor.Add (@"This is not how you're supposed to do it.");
		ReloadedArmor.Add (@"This is getting humiliating for you...");

		initiated = true;
	}
}
