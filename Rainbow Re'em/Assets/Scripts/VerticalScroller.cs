using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	// This script controls the moving of the death line

public class VerticalScroller : MonoBehaviour {
	// Sets the base value for the speed of the scroller
	public float scrollingSpeed = 1f;
	// Gives a reference for the current speed
	public float currentSpeed = 0f;
	// Sets a goal for the speed to slowly reach
	public float targetSpeed = 30f;
	// Sets the starting position of the scroller
	private Vector3 startPosition;

	// Start()
	//		Runs at the start of the game only once, sets the starting position to its current position at the beginning of the game
	// Params:
	// 
	// Return:
	// 		void

	void Start () {
		startPosition = transform.position;
	}
	
	// Update()
	//		Runs every frame and moves the object vertically by a factor 1 multiplied by the set value
	// 		checks to see if it away from the target speed, if it is increases speed by 0.2 every frame
	// Params:
	//
	// Return:
	// 		void

	void Update () {
		transform.position = startPosition += Vector3.up * scrollingSpeed * Time.deltaTime;

		if(currentSpeed < targetSpeed){
			currentSpeed += Time.deltaTime;

		}
	}
}
