using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_1Platform : MonoBehaviour {
	
	// Timer indicates how long a counter will last for
	public float timer = 1;
	// platform is a reference to the location of the model of the platform
	public GameObject platform;
	// startColor is the color the objects material begins at
	public Color startColor = Color.cyan;
	// newColor is the color the object changes to
	public Color newColor = Color.red;
	// GroundLayer is the allocation of a layer to which is independent from others
	public LayerMask GroundLayer;
	// isGrounded is a reference to the player either ebing on the ground or not
	public bool isGrounded = false;
	// mat is link to getting an objects material
	private Material mat;



	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// Start()
	// Called at the start of the game and called once
	// mat gets the components renderer mat.color sets the start color. 
	// Param:
	// Return:
	//		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void Start(){
		mat = platform.GetComponent<Renderer> ().material;
		mat.color = startColor;
	}



	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// DestroyObject() 
	// Called every frame, checks to see if the player is grounded then starts the timer counting down.
	// Once timer is less than 0, it will destory the objects parent.
	// Also runs ChangeColor()
	// Param:
	// Return:
	//		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void DestoryObject(){
		if (isGrounded == true) {
			timer -= Time.deltaTime;
			if (timer < 0) {
				this.transform.parent.gameObject.SetActive (false);
			}
			ChangeColor ();
		}
	}



	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// ChangeColor()
	// Called only if player is grounded, checks everyframe
	// Changes object material once timer is below 0.5
	// Param:
	// Return:
	//		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void ChangeColor(){
		if (timer < 0.5f){
			mat.color = newColor;
		}
	}



	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// Update()
	// Called everyframe and runs DestroyObject()
	// Param:
	// Return
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void Update(){
			DestoryObject();
	}



	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// OnTriggerEnter()
	// Called once a tagged object passes through it 
	// Makes the player grounded
	// Param:
	//		Collider other - a collider not its own
	// Return:
	//		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player"){
			isGrounded = true;
			}
	}
}