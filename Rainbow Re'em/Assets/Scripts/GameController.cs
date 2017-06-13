﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	// This script Controls the spawning of platforms	

public class GameController : MonoBehaviour {
	

	// List of all the rainbow pieces available to spawn
	public List <GameObject> rainbowPieceList = new List <GameObject> ();
	// List of all platforms available to spawn
	public List <GameObject> platformList = new List<GameObject> ();
	// A Counter of all the rainbow pieces we have spwaned
	public int rainbowPieceCounter = 0;
	// A counter of all the platform pieces we have spawned
	public int platformCounter = 0;
	// The height of each Rainbow Piece
	public int heightOfRainbowPiece = 5;
	// The height of each platform
	public float heightOfPlatform = 10;
	// How many rainbow pieces we want to spawn
	public int numberOfRainbowPieces = 40;
	// How many platforms we want to spawn
	public int numberOfPlatforms = 150;
	// Player position reference
	public float playerPositionCounter = 0;
	// Reference for the player object
	public GameObject player;
	// Reference for the maximum spawn point along the X Axis 
	public float maxPlatformPos = 7.5f;
	// Reference for the minimum spawn point along the X Axis 
	public float minPlatformPos = -7f; 
	// Sets the layer platforms to interact with
	private LayerMask groundLayer;
	// Sets the starting position of where each platform is to be placed
	public Vector3 platformPlacement;
	// Sets a reference for a previous platform placement position
	public Vector3 previousValue = Vector3.zero;



	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// Start()
	// 		Runs once at the beginning of the game. Starts two loop statements that check for how many platforms have been built 
	//		and how many rainbow pieces have been built
	// Params:
	//
	// Return:
	// 		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		for (int i = 0; i <numberOfRainbowPieces; i++) {
			BuildRainbow();
		}

		for (int i = 0; i < numberOfPlatforms; i++) {
			BuildPlatforms();
		}
	}



	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// BuildRainbow()
	// 		Run continously with a looping statement and chooses a random rainbow piece and places it vertical based off the height set.
	// Param:
	//
	// Return:
	// 		void	
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	private void BuildRainbow(){
		GameObject rainbowPieceToPlace = null;


		rainbowPieceToPlace = rainbowPieceList [Random.Range (0, rainbowPieceList.Count)];

		Instantiate (rainbowPieceToPlace, Vector3.up * heightOfRainbowPiece * rainbowPieceCounter, Quaternion.identity);
		rainbowPieceCounter++;
	}





	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// BuildPlatforms()
	// 		Runs continously within a looping statement, chooses a random platform from a list and places it vertically based off the height set.
	// 		Also randomly places each piece along the X axis randomly between the min and max set
	//		Checks to see if a platform is directly above another, if so moves said platform along the x Axis to mis.
	// Param:
	//
	// Return:
	// 		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	private void BuildPlatforms(){
		GameObject platformPieceToPlace = null;

		platformPieceToPlace = platformList [Random.Range (0, platformList.Count)];

		Instantiate (platformPieceToPlace, platformPlacement, Quaternion.identity);
		platformCounter++;

		int infiniteLoopProtection = 0;


		do {
			platformPlacement = (Vector3.up * heightOfPlatform * platformCounter) + new Vector3 (Random.Range (minPlatformPos, maxPlatformPos), 0, 0);
			infiniteLoopProtection ++;

			if(infiniteLoopProtection > 1000){
				break;
			}

		} while ( platformPlacement.x  >= previousValue.x - 2 && platformPlacement.x <= previousValue.x + 2);
		previousValue = platformPlacement;

	}
		

	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// Update()
	//		Runs every frame and checks to see if the player has exceeded the max set in the Start() for loops
	//  	If true adds to the counter so the loop can continue building
	// Param:
	//
	// Return:
	// 		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void Update () {
		if (player.transform.position.y > playerPositionCounter){
			playerPositionCounter += heightOfRainbowPiece;
	
			BuildRainbow();
			BuildPlatforms();
		}
	}
}
