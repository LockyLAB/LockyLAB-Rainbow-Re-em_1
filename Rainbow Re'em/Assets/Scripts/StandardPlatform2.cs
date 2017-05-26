using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPlatform2 : MonoBehaviour {
	//Sets the end position of the platform movement
	public Transform end;
	// Sets the speed the platform moves at
	public float speed = 1.0f;
	// The reference for the starting position of the platform
	private Vector3 startMarker;
	// The reference for the ending position of the platform
	private Vector3 endMarker;


	// Use this for initialization
	void Start () {
		startMarker = new Vector3 (6f, this.transform.position.y, 0f);
		endMarker = end.position;

	}


	void Update (){
		transform.position = Vector3.Lerp (startMarker, endMarker, Mathf.SmoothStep (0f, 0.75f, Mathf.PingPong (Time.time * speed, 1f)));
	}
}