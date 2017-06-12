using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	// Reference set from the score value between two values
	public float distance;
	// Reference for the player object
	public Transform player;
	// Reference for the text or numbers to be displayed from
	public Text scoreOutputText; 
	// Base value to multiply to base score
	public float multiplier;
	// Null score value set at the start of the game
	private Vector3 playerPos = new Vector3 (0, 0, 0);
	// Null score value set the start of the game 
	private Vector3 startPos = new Vector3 (0, 1.61f, 0);


	//-----------------------------------------------------------------------------------------------------------------------------------------------------
	// Awake()
	//		Runs before anything else and makes sure that this script is not destroyed when the scene is deleted
	// Params;
	//
	// Return:
	//		void
	//-----------------------------------------------------------------------------------------------------------------------------------------------------
	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}


	//-----------------------------------------------------------------------------------------------------------------------------------------------------
	// Update()
	// 		Runs every frame and runs ScoreCount
	// Params:
	//
	// Return:
	// 		void
	//-----------------------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
		if(player != null){
			ScoreCount ();
		}
	}


	//-----------------------------------------------------------------------------------------------------------------------------------------------------
	// 	ScoreCount()
	// 		Runs every frame and gets a value from the players starting y position and current y posiition then muliplies by a set value, rounding up
	// 		Outputs this value on the UI 
	// Params:
	//
	// Return:
	// 		void
	//-----------------------------------------------------------------------------------------------------------------------------------------------------
	void ScoreCount(){
		playerPos = new Vector3 (0, player.position.y, 0);
		startPos = new Vector3 (0, transform.position.y, 0);
		float currentDistance =  Mathf.Round(Vector3.Distance(playerPos, startPos));

		if(currentDistance > distance){
			distance = currentDistance;
			scoreOutputText.text = distance.ToString();
		}




	}
}
