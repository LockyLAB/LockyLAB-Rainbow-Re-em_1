using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

	// This script controls the Opening menu buttons

public class OpeningMenu : MonoBehaviour {



	// ClickButton()
	// Checks to see if button has been clicked
	// Params:
	// 		int buttonClicked - asigns a whole number to a button. 
	// Return:
	//		void

	public void ClickButton (int buttonClicked){

		if(buttonClicked == 1){
			RunGame ();
		}

		if(buttonClicked == 2){
			EndGame ();
		}
		
	}

	// ReturnGame()
	// Called if button 1 is clicked and loads the main game scene
	// Params:
	// 
	// Return:
	// 		void

	public void RunGame(){
		SceneManager.LoadScene ("Game");
	}

	// ExitGame()
	// Called if button 2 is clicked and quits the game
	// Params:
	//
	// Return:
	//		void

	public void EndGame(){
		Application.Quit ();
	}
}
