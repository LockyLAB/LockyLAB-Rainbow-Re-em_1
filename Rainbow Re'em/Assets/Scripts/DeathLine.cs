using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathLine : MonoBehaviour {



	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			SceneManager.LoadScene ("DeathScreen");

		}
	}
}