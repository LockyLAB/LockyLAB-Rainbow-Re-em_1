using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	//	This Script contorls the score being output to the death screen
public class MenuScore : MonoBehaviour {

	// Sets the score on the death screen
	public Text finalScoreOutputText;




	//--------------------------------------------------------------------------------------------------------------------------
	// Awake()
	//	Called before start, finds an object from the previous scene, grabs the score value within that object and places it onto the new menu
	// Params:
	//
	// Return:
	//		void
	//--------------------------------------------------------------------------------------------------------------------------
	void Awake(){
		finalScoreOutputText.text = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Score> ().distance.ToString();
		}
		
}