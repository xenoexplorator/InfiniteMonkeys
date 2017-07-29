using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour {


	public void StartGame()
	{
		SceneManager.LoadScene ("Level1");
	}

	public void ShowControls()
	{
		
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
