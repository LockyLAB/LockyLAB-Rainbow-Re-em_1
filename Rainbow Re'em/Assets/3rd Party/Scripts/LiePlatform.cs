using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiePlatform : MonoBehaviour {

	// List of all available materials for this object
	public List <Material> liePlatformMaterialList = new List <Material> ();
	// Reference to the object that is require to change materials
	public GameObject platform;

	// Start()
	//	Happens only once at the begining of the game and runs ChooseColour
	// Params:
	//
	// Return:
	//		void
	void Start(){
		ChooseColour ();

	}


	// ChooseColour()
	//	Happens only once at the begining of the game and sets what material the object will have
	// 	Randomly selects a material from one within the set list
	// Params:
	//
	// Return:
	//		void
	void ChooseColour(){
		platform.GetComponent<Renderer> ().material = liePlatformMaterialList [Random.Range(0, liePlatformMaterialList.Count)];
	}
}
