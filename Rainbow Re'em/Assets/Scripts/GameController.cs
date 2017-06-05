using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	

	// List of all the rainbow pieces available to spawn
	public List <GameObject> rainbowPieceList = new List <GameObject> ();
	// List of all platforms available to spawn
	public List <GameObject> platformList = new List<GameObject> ();
	// A counter for the Lie platforms that have spawned
	public int liePlatformCounter = 0;
	// A Counter of all the rainbow pieces we have spwaned
	public int rainbowPieceCounter = 0;
	// A counter of all the platform pieces we have spawned
	public int platformCounter = 0;
	// The height of each Rainbow Piece
	public int heightOfRainbowPiece = 5;
	// The height of each Lie Platform
	public float heightOfLiePlatform = 15;
	// The height of each platform
	public float heightOfPlatform = 10;
	// How many rainbow pieces we want to spawn
	public int numberOfRainbowPieces = 40;
	// How many platforms we want to spawn
	public int numberOfPlatforms = 150;
	// How many Lie Platforms that will be spawned
	public int numberOfLiePlatforms = 5;
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
	// Sets what Lie platform Object is
	public GameObject liePlatform;

	public Vector3 raycastPosLeft = new Vector3 (0f, 0f, 0f);
	public Vector3 raycastPosRight = new Vector3 (0f, 0f, 0f);




	// Start()
	// 		Runs once at the beginning of the game. Starts two loop statements that check for how many platforms have been built 
	//		and how many rainbow pieces have been built
	// Params:
	//
	// Return:
	// 		void

	void Start () {
		for (int i = 0; i <numberOfRainbowPieces; i++) {
			BuildRainbow();
		}

		for (int i = 0; i < numberOfPlatforms; i++) {
			BuildPlatforms();
		}
		for (int i = 0; i < numberOfLiePlatforms; i++) {
			BuildLiePlatforms();
		}
	}

	// BuildRainbow()
	// 		Run continously with a looping statement and chooses a random rainbow piece and places it vertical based off the height set.
	// Param:
	//
	// Return:
	// 		void	

	private void BuildRainbow(){
		GameObject rainbowPieceToPlace = null;


		rainbowPieceToPlace = rainbowPieceList [Random.Range (0, rainbowPieceList.Count)];

		Instantiate (rainbowPieceToPlace, Vector3.up * heightOfRainbowPiece * rainbowPieceCounter, Quaternion.identity);
		rainbowPieceCounter++;

	
	}

	// BuildPlatforms()
	// 		Runs continously within a looping statement, chooses a random platform from a list and places it vertically based off the height set.
	// 		Also randomly places each piece along the X axis randomly between the min and max set
	//		Checks to see if a platform is directly above another, if so moves said platform along the x Axis to mis.
	// Param:
	//
	// Return:
	// 		void

	private void BuildPlatforms(){
		GameObject platformPieceToPlace = null;

		platformPieceToPlace = platformList [Random.Range (0, platformList.Count)];

		Vector3 platformPlacement = (Vector3.up * heightOfPlatform * platformCounter) + new Vector3 (Random.Range (minPlatformPos, maxPlatformPos), 0, 0);


		Instantiate (platformPieceToPlace, platformPlacement, Quaternion.identity);
		platformCounter++;

		raycastPosLeft = transform.position;
		raycastPosRight = transform.position;

		raycastPosLeft.x = raycastPosLeft.x - 0.5f;
		raycastPosRight.x = raycastPosRight.x + 0.5f;

		if (Physics.Raycast (raycastPosLeft, Vector3.up, 4f)) {
			if (transform.position.x > 0) {
				transform.position = new Vector3 (transform.position.x + -4f, transform.position.y, transform.position.z);
			}
			Debug.DrawRay (raycastPosLeft, Vector3.up);
		}


		if (Physics.Raycast (raycastPosRight, Vector3.up, 4f)) {
			if (transform.position.x < 0) {
				transform.position = new Vector3 (transform.position.x + 4f, transform.position.y, transform.position.z);
			}
			Debug.DrawRay (raycastPosRight, Vector3.up, Color.magenta);
		}

	}


//		RaycastHit hit = Physics.Raycast (this.transform.position, Vector3.up, 3f);
//		if (hit.collider) {
//			MovePlatforms ();
//		}
//	}


//		if (Physics.Raycast (transform.position, Vector3.up, 4f)) {
//			Debug.DrawRay (transform.position, Vector3.up, Color.yellow, 4f);
//			MovePlatforms ();
//
//			}
//



	// BuildLiePlatforms()
	// 		Runs continously within a looping statement, builds one Lie Platform and places it vertically between the other platforms.
	// 		Also randomly places along the X axis randomly between the min and max set
	//		Checks to see if a platform is directly above another, or next to another if so moves said platform along the x Axis and the y Axis to mis.
	// Param:
	//
	// Return:
	// 		void


	private void BuildLiePlatforms(){

		Vector3 liePlatformPlacement =  (new Vector3(0f, 0.5f, 0f) * heightOfLiePlatform * liePlatformCounter) + new Vector3 (Random.Range (minPlatformPos, maxPlatformPos), 0, 0);

		GameObject GO = Instantiate (liePlatform, liePlatformPlacement, Quaternion.identity);
		liePlatformCounter++;

//		raycastPosLeft = transform.position;
//		raycastPosRight = transform.position;
//
//		raycastPosLeft.x = raycastPosLeft.x - 1f;
//		raycastPosRight.x = raycastPosRight.x + 1f;
//
//		if (Physics.Raycast(raycastPosLeft, Vector3.right, 4f)){
//			MoveLiePlatforms ();
//		}
//
//		if (Physics.Raycast(raycastPosLeft, -Vector3.right, 4f)){
//			MoveLiePlatforms ();
//		}

		if(Physics.Raycast(GO.transform.position, Vector3.right, 5f)){
			
			GO.transform.position = new Vector3 (GO.transform.position.x + -6f, GO.transform.position.y + -1f, GO.transform.position.z);
			
		} else if (Physics.Raycast(GO.transform.position, -Vector3.right, 5f)){
			GO.transform.position = new Vector3 (GO.transform.position.x + 6f, GO.transform.position.y + 1f, GO.transform.position.z);
		}
	}


//	private void MovePlatforms(){
//		if (transform.position.x > 0) {
//		transform.position = new Vector3 (transform.position.x + -4f, transform.position.y, transform.position.z);
//			Debug.Log (new Vector3 (transform.position.x + -4f, transform.position.y, transform.position.z));
//
//		} else if (transform.position.x < 0) {
//		transform.position = new Vector3 (transform.position.x + 4f, transform.position.y, transform.position.z);
//		}
//	}

//	private void MoveLiePlatforms(){
//		if (transform.position.x > 0){
//			transform.position = new Vector3 (transform.position.x + -4f, transform.position.y + -1f, transform.position.z);
//		
//		} else if (transform.position.x < 0){
//			transform.position = new Vector3 (transform.position.x + 4f, transform.position.y + 1f, transform.position.z);
//		}
//	}




	// Update()
	//		Runs every frame and checks to see if the player has exceeded the max set in the Start() for loops
	//  	If true adds to the counter so the loop can continue building
	// Param:
	//
	// Return:
	// 		void


	void Update () {
		if (player.transform.position.y > playerPositionCounter){
			playerPositionCounter += heightOfRainbowPiece;
	
			BuildRainbow();
			BuildPlatforms();
			BuildLiePlatforms ();
		}
	}
}
