using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPlatform : MonoBehaviour {

	public Vector3 raycastPosLeft = new Vector3 (0f, 0f, 0f);
	public Vector3 raycastPosRight = new Vector3 (0f, 0f, 0f);

	public bool beginMove = false;
	public bool endPosRight = false;
	public bool endPosLeft = false;

	public float speed = 2;
	public Rigidbody rb;

	public float maxAxisPos = 4.2f;
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
		

	void BeginLeft(){
		if (beginMove == true && transform.position.x < 0) {
			rb.AddForce (-transform.right * speed);
		}
	}

	void BeginRight(){
		if (beginMove == true && transform.position.x > 0) {
			rb.AddForce (transform.right * speed);
		}
	}

	void MoveLeft(){
		if (transform.position.x <= minAxisPos){
			endPosLeft = true;
			beginMove = false;
			rb.AddForce (transform.right * speed);

		}

	}

	void MoveRight(){
		if (transform.position.x >= maxAxisPos){
			endPosRight = true;
			beginMove = false;
			rb.AddForce (-transform.right * speed);
		}
	}
		
	void FixedUpdate (){
	
		BeginLeft();
		BeginRight ();
		MoveLeft ();
		MoveRight ();
		}

}


		
	


		
		

		//transform.position = Vector3.Lerp (startMarker, endMarker, Mathf.SmoothStep (0f, 0.75f, Mathf.PingPong (Time.time * speed, 1f)));


	