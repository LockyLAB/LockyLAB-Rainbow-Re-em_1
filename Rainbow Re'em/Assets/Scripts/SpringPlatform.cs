using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	// This script Controls the behaviour for the spring platform

public class SpringPlatform : MonoBehaviour {
	
	// Sets the base value for the spring jump
	public float springBoost = 20;
	// Sets a reference for counter regarding collider generation
	private float floorCounter = 0f;
	// Object reference for collider activation	
	public GameObject launch;





	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// OnTriggerEnter()
	// 	When player enters launches player vertically by a value multiplied by a set value
	// 	Begins a counter, once counter is greater than 2 will activate a collider which the player can stand on
	// Params:
	// 	Collider other -  a collider not its own
	// Return:
	// 		void
	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player"){
			launch.gameObject.SetActive (true);
			floorCounter++;
			if (floorCounter >= 2f) {
				other.GetComponent<Rigidbody> ().AddForce (other.transform.up * springBoost, ForceMode.Impulse);
			}
		}
	}

}
	