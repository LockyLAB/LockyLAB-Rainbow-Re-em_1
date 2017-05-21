using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_1Platform : MonoBehaviour {

	public float Timer = 1;

	public LayerMask GroundLayer;
	private bool isGrounded = false;


	void OnTriggerEnter (Collider other){
		if (other.tag == "Player"){
			isGrounded = true;
			}
		if (isGrounded == true){
			Timer -= Time.deltaTime;
			if(Timer == 0){
				gameObject.SetActive (false);
			}
	
		}
	}
}