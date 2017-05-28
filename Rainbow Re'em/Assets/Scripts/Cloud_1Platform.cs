using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_1Platform : MonoBehaviour {

	public float timer = 1;

	public Color startColor = Color.cyan;
	public Color newColor = Color.red;
	public LayerMask GroundLayer;
	public bool isGrounded = false;
	private Renderer rend;

	void Start(){
		rend = GetComponent<Renderer> ();
		rend.material.color = startColor;
	}

	void DestoryObject(){
		if (isGrounded == true) {
			timer -= Time.deltaTime;
			if (timer < 0) {
				this.transform.parent.gameObject.SetActive (false);
			}
			ChangeColor ();
		}
	}

	void ChangeColor(){
		if (timer < 1f){
			startColor =  newColor;

		}
	}

	void Update(){
			DestoryObject();
			

		}


		void OnTriggerEnter (Collider other){
		if (other.tag == "Player"){
			isGrounded = true;
			}
	}
}