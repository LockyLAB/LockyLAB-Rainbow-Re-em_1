using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlatform : MonoBehaviour {
	// Reference for the player
	public GameObject target;
	// Base value set for out pushing velocity side to side
	public float outforceX;
	// Base value set for out pushing velocity vertically
	public float outforceY;


	void OnCollisionEnter (Collision other){
		if(other.gameObject.tag == "Player"){
			if (gameObject.transform.position.x < 0) {
				target.GetComponent<Rigidbody> ().velocity += new Vector3 (outforceX, outforceY, 0f);

			} else if (gameObject.transform.position.x > 0){
				target.GetComponent<Rigidbody> ().velocity += new Vector3 (-outforceX, outforceY, 0f);
			}


		}
		
	}
}
