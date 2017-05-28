using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Initialise : MonoBehaviour {

	public void ClickButton (int buttonClicked){

		if(buttonClicked ==1){
			ReturnGame ();

	
		}

		if(buttonClicked ==2){
			ExitGame ();
		}
	}

	public void ReturnGame(){
		SceneManager.LoadScene ("Game");
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
	


