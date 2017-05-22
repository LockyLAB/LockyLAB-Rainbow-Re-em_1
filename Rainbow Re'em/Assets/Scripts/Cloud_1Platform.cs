using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_1Platform : MonoBehaviour {

	public float timer = 1;


	public LayerMask GroundLayer;
	public bool isGrounded = false;

	void Update(){
		if (isGrounded == true) {
			timer -= Time.deltaTime;
			if (timer < 0) {
				this.transform.parent.gameObject.SetActive (false);
			}
		}
	}


		void OnTriggerEnter (Collider other){
		if (other.tag == "Player"){
			isGrounded = true;
			}
	}
}