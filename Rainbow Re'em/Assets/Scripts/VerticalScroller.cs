using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroller : MonoBehaviour {

	public float scrollingSpeed = 1f;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = startPosition += Vector3.up * scrollingSpeed;

	}
}
