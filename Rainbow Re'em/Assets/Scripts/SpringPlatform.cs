using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour {

	public float springBoost = 20;

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player"){
			other.GetComponent<Rigidbody> ().AddForce (other.transform.up * springBoost, ForceMode.Impulse);
		}
	}
}		
		