﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public List <GameObject> rainbowPieceList = new List <GameObject> ();

	public List <GameObject> platformList = new List<GameObject> ();

	//	public GameObject groundPiece1;
	//	public GameObject groundPiece2;
	//	public GameObject groundPiece3;

	// A Counter of all the pieces we have spwaned
	public int rainbowPieceCounter = 0;
	public int platformCounter = 0;
	// The depth of each Ground Piece
	public int depthOfRainbowPiece = 5;
	public int heightOfPlatform = 10;
	// How many pieces we want to spawn
	public int numberOfRainbowPieces = 40;
	public int numberOfPlatforms = 150;
	//Player position reference
	public float playerPositionCounter = 0;
	public GameObject player;
	public float maxPlatformPos = 7.5f;
	public float minPlatformPos = -7f;


	// Use this for initialization
	void Start () {
		for (int i = 0; i <numberOfRainbowPieces; i++) {
			//Instantiate (groundPiece, Vector3.zero, Quaternion.identity);
			BuildGround();
		}

		for (int i = 0; i < numberOfPlatforms; i++) {
			BuildPlatforms();
		}
	}

	private void BuildGround(){
		GameObject rainbowPieceToPlace = null;
		//int randomPiece = Random.Range (0, 3);
		//
		//		if (randomPiece == 0) {
		//			groundPieceToPlace = groundPiece1;
		//		} else if (randomPiece == 1) {
		//			groundPieceToPlace = groundPiece2;
		//		} else if (randomPiece == 2) {
		//			groundPieceToPlace = groundPiece3;
		//		}

		rainbowPieceToPlace = rainbowPieceList [Random.Range (0, rainbowPieceList.Count)];

		Instantiate (rainbowPieceToPlace, Vector3.up * depthOfRainbowPiece * rainbowPieceCounter, Quaternion.identity);
		rainbowPieceCounter++;
	}

	private void BuildPlatforms(){
		GameObject platformPieceToPlace = null;

		platformPieceToPlace = platformList [Random.Range (0, platformList.Count)];

		Instantiate (platformPieceToPlace, (Vector3.up * heightOfPlatform * platformCounter) + new Vector3(Random.Range(minPlatformPos, maxPlatformPos),0, 0), Quaternion.identity);
		platformCounter++;

	}



	// Update is called once per frame
	void Update () {
		if (player.transform.position.y > playerPositionCounter){
			playerPositionCounter += depthOfRainbowPiece;
	
			BuildGround();
			BuildPlatforms();
		}
	}
}
