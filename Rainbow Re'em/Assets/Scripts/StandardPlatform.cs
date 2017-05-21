using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPlatform : MonoBehaviour {

	public Transform startMarker;
	public Transform endMarker;
	public float speed = 1.0f;

	private float startTime;



	// Use this for initialization
	void Start () {
		StartCoroutine (MovePlatform (startMarker.position));
	
	}


	private IEnumerator MovePlatform(Vector3 endPosition){
		float currentLerpTime = 0f;
	

		Vector3 startPosition = transform.position;

	while(currentLerpTime <=speed){
		currentLerpTime += Time.deltaTime;

		transform.position = Vector3.Lerp(startPosition, endPosition, currentLerpTime / speed);
		yield return null;
	}
	
		transform.position = endPosition;
		Vector3 nextPosition = Vector3.zero;
		if(transform.position == startMarker.position){
		nextPosition = endMarker.position;
	} else {
		nextPosition = startMarker.position;
	}
		StartCoroutine (MovePlatform (nextPosition));

	}

}