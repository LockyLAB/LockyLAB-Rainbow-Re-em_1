using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Initialise : MonoBehaviour {
	
	// ClickButton()
	// Checks to see if button has been clicked
	// Params:
	// 		int buttonClicked - asigns a whole number to a button. 
	// Return:
	//		void
	public void ClickButton (int buttonClicked){

		if(buttonClicked ==1){
			ReturnGame ();

	
		}

		if(buttonClicked ==2){
			ExitGame ();
		}
	}

	// ReturnGame()
	// Called if button 1 is clicked and loads the main game scene
	// Params:
	// 
	// Return:
	// 		void


	public void ReturnGame(){
		SceneManager.LoadScene ("Game");
	}

	// ExitGame()
	// Called if button 2 is clicked and quits the game
	// Params:
	//
	// Return:
	//		void

	public void ExitGame(){
		Application.Quit ();
	}
}
	


