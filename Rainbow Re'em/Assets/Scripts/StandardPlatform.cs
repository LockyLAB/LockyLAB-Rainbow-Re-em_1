using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	// This script controls the behaviour of the moving platform

public class StandardPlatform : MonoBehaviour {

	// Sets a reference to see if the platform has started moving
	public bool beginMove = false;
	// Sets a reference to see if the platform has reach it's furthest position along the X axis
	public bool endPosRight = false;
	// Sets a reference to see if the platform has reach it's closest position along the X axis
	public bool endPosLeft = false;
	// Sets a reference for counter regarding collider generation
	private float floorCounter = 0f;
	// Base value for platform movement speed
	public float speed = 2;
	// Short hand reference for component
	public Rigidbody rb;
	// Player object reference for platforms velocity to match
	public GameObject target;
	// Object reference for collider activation	
	public GameObject floor;
	// Maximum reference to enable a platform to move left
	public float maxAxisPos = 4.2f;
	// Minimum reference to enable a platform to move right
	public float minAxisPos = -4f;

	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// Start()
	// 	called at the begining of the game and only once sets the starting position of the platform and
	// 	clarifies the endmarker position.
	//Param:
	// 		
	//Return:
	//		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void Start () {
		beginMove = true;
		rb = GetComponent<Rigidbody> ();
		}
		


	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// BeginLeft()
	// 	Called every frame and checks to see if the platform has spawned left of screen centre
	// 	If platform has then moves platform left of screen at a rate designated by speed value
	//Param:
	// 		
	//Return:
	//		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void BeginLeft(){
		if (beginMove == true && transform.position.x < 0) {
			rb.AddForce (-transform.right * speed);
		}
	}





	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// BeginRight()
	// 	Called every frame and checks to see if the platform has spawned right of screen centre
	// 	If platform has then moves platform right of screen at a rate designated by speed value
	//Param:
	// 		
	//Return:
	//		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void BeginRight(){
		if (beginMove == true && transform.position.x > 0) {
			rb.AddForce (transform.right * speed);
		}
	}


	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// MoveLeft()
	// 	Called every frame and checks to see if the platform has reached its minimum position set along the X axis
	// 	If so then it will shift its movement to the right along the X axis only by a rate designated by the speed value
	//Param:
	// 		
	//Return:
	//		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void MoveLeft(){
		if (transform.position.x <= minAxisPos){
			endPosLeft = true;
			beginMove = false;
			rb.AddForce (transform.right * speed);

		}

	}

	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// MoveRight()
	// 	Called every frame and checks to see if the platform has reached its maximum position set along the X axis
	// 	If so then it will shift its movement to the left along the X axis only by a rate designated by the speed value
	//Param:
	// 		
	//Return:
	//		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void MoveRight(){
		if (transform.position.x >= maxAxisPos){
			endPosRight = true;
			beginMove = false;
			rb.AddForce (-transform.right * speed);
		}
	}

	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// OnTriggerEnter()
	// 	Called once the player touches this object
	// 	Begins a counter, once counter is greater than 2 will activate a collider which the player can stand on
	//Param:
	// 		If it hits a collider other than itself
	//Return:
	//		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			//playerEntered = true;
			floorCounter++;
			if(floorCounter >= 2f){
				floor.gameObject.SetActive (true);
				Debug.Log (floorCounter >= 2f);
			}
		}
	}



	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// FixedUpdate()
	// 	Called last at the end of every frame
	// 	Runs all functions to enable platform movement
	//Param:
	// 		
	//Return:
	//		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void FixedUpdate (){
	
		BeginLeft();
		BeginRight ();
		MoveLeft ();
		MoveRight ();
		}

}