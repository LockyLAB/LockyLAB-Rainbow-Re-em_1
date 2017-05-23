using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	
	public float distance;
	public Transform player;
	public Text scoreOutputText; 
	public float multiplier;
	private Vector3 playerPos = new Vector3 (0, 0, 0);
	private Vector3 startPos = new Vector3 (0, 0, 0);


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ScoreCount();
	
	}

	void ScoreCount(){
		playerPos = new Vector3 (0, player.position.y, 0);
		startPos = new Vector3 (0, transform.position.y, 0);
		distance =  Mathf.Round(Vector3.Distance(playerPos, startPos) * multiplier);
		scoreOutputText.text = distance.ToString();
	}
}
