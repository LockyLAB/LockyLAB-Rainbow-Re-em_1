using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	// This script controls the behaviour for the platform script

public class Platform : MonoBehaviour {


	// Sets a reference for counter regarding collider generation
	private float floorCounter = 0f;
	// Object reference for collider activation	
	public GameObject floor;



	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// OnTriggerEnter()
	// 	Called once a tagged object passes through it 
	// 	Makes the player grounded
	// 	Begins a counter, once counter is greater than 2 will activate a collider which the player can stand on
	// Param:
	//		Collider other - a collider not its own
	// Return:
	//		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			floorCounter++;
			if(floorCounter >= 2f){
				floor.gameObject.SetActive (true);
			}
		}
	}
}
