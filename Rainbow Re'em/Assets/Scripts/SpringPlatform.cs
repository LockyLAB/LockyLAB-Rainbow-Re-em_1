using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour {
	// Sets the base value for the spring jump
	public float springBoost = 20;


	// OnTriggerEnter()
	// 		When player enters launches player vertically by a value multiplied by a set value
	// Params:
	// 		Collider other -  a collider not its own
	// Return:
	// 		void

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player"){
			other.GetComponent<Rigidbody> ().AddForce (other.transform.up * springBoost, ForceMode.Impulse);

		}
	}
}		
		