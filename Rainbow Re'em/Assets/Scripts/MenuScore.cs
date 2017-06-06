using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour {


	public Text finalScoreOutputText;


	void Awake(){
		finalScoreOutputText.text = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Score> ().distance.ToString();
		}
		
}