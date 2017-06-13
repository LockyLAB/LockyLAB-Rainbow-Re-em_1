using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

	// This script controls the collider that kils the player and initiates the death menu
public class DeathLine : MonoBehaviour {

	// OnTriggerEnter()
	// 		Checks if an object marked Player runs through it. If so runs a new scene
	// Params: 
	// 		Collider other - a collider not its own
	// Return:
	// 	void

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			SceneManager.LoadScene ("DeathScreen");

		}
	}
}