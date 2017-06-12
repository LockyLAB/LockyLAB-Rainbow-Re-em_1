using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	private float floorCounter = 0f;
	private bool isGrounded = true;


	public GameObject floor;




	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			//playerEntered = true;
			floorCounter++;
			if(floorCounter >= 2f){
				floor.gameObject.SetActive (true);
				isGrounded = true;
				Debug.Log (floorCounter >= 2f);
			}
		}
	}
}
