using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPlatform : MonoBehaviour {

	//Sets the end position of the platform movement
	public Transform end;
	// Sets the speed the platform moves at
	public float speed = 1.0f;
	// The reference for the starting position of the platform
	private Vector3 startMarker;
	// The reference for the ending position of the platform
	private Vector3 endMarker;


	// Start()
	// 	called at the begining of the game and only once sets the starting position of the platform and
	// 	clarifies the endmarker position.
	//Param:
	// 		
	//Return:
	//		void

	void Start () {
		startMarker = new Vector3 (-4.8f, this.transform.position.y, 0f);
		endMarker = end.position;
		
	}

	// Update()
	// 	Called everyframe and tells the platform to move at an increasing speed between two points, continuously (startMarker and endMarker)
	// Param:
	//
	// Return:
	//		void

	void Update (){
		transform.position = Vector3.Lerp (startMarker, endMarker, Mathf.SmoothStep (0f, 0.75f, Mathf.PingPong (Time.time * speed, 1f)));
	}
}
	