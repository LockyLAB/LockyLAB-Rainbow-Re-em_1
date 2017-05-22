using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour {

	public float jumpBoost = 150;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.GetComponent<Rigidbody> ().AddForce (other.transform.up * jumpBoost, ForceMode.Impulse);
		}
	}
}