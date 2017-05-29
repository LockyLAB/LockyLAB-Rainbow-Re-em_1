using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_1Platform : MonoBehaviour {

	public float timer = 1;

	public GameObject platform;
	public Color startColor = Color.cyan;
	public Color newColor = Color.red;
	public LayerMask GroundLayer;
	public bool isGrounded = false;
	private Material mat;

	void Start(){
		mat = platform.GetComponent<Renderer> ().material;
		mat.color = startColor;
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
		if (timer < 0.5f){
			mat.color = newColor;
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