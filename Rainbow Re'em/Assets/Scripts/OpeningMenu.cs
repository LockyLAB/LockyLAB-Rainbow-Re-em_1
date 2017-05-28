using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningMenu : MonoBehaviour {

	public void ClickButton (int buttonClicked){

		if(buttonClicked == 1){
			RunGame ();
		}

		if(buttonClicked == 2){
			EndGame ();
		}
		
	}


	public void RunGame(){
		SceneManager.LoadScene ("Game");
	}

	public void EndGame(){
		Application.Quit ();
	}
}
