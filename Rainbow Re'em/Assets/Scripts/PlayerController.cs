using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {

	// timberBetweenJumps puts a delay of one second between jumps
	public float timerBetweenJumps = 1f;
	// XboxController allow the choice of which controller from the front end
	public XboxController controller;
	// walkSpeed sets the base value for the player to move at
	public float walkSpeed = 2;
	// jumpSpeed sets the base value for the player to jump at
	public float jumpSpeed = 5;

	private float timer;

	public LayerMask groundLayer;

	private bool isGrounded = false;
	private Vector3 origin = new Vector3(0, 0, 0);

	public GameObject mainCamera;


	// Use this for initialization
	void Start () {
		timer = Time.time;

	

	}
	
	// Update is called once per frame
	void Update () {
		origin = transform.position;

		float cameraXpos = 0;
		float cameraYpos = this.transform.position.y + 1.5f;
		float cameraZpos = -9.6f;
		mainCamera.transform.position = new Vector3 (cameraXpos, cameraYpos, cameraZpos);

		}
	void FixedUpdate (){
		if (Physics.Raycast(origin,-transform.up, 1f, groundLayer)){
			isGrounded = true;

		}else {
			isGrounded = false;
		}

		// Get Component grabs the player rigidbody
		// mulitplies walkSpeed by one and the input of the joystick (either 0 to 1 or 0 to -1)
		gameObject.GetComponent<Rigidbody> ().AddForce (transform.right * walkSpeed * XCI.GetAxis (XboxAxis.LeftStickX, controller));

		// Upon button A press & player is on the ground, Get Component grabs the player and multiplies current position by jumpSpeed
		// Time.time keeps a standard break of one second between button presses
		// canJump only enables the player to jump from a surface 
		if ( XCI.GetButtonDown(XboxButton.A, controller ) && isGrounded == true){
			gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * jumpSpeed);
			if 		(Time.time - timer > timerBetweenJumps)
				timer = Time.time;
		}

	}
}



