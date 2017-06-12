using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour {
	
	// Sets the base value for the spring jump
	public float springBoost = 20;
	private float floorCounter = 0f;

	public GameObject launch;





	//----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	// OnTriggerEnter()
	// 		When player enters launches player vertically by a value multiplied by a set value
	// Params:
	// 		Collider other -  a collider not its own
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
	