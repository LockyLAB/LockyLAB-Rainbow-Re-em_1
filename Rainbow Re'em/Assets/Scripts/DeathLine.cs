using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathLine : MonoBehaviour {

	public Text gameOverText;


	void OnTriggerEnter (Collider other){
		if(other.tag == "Player"){
			gameOverText.text += "GAME-OVER";
			Debug.Log ("DIE");
		}
	}
}