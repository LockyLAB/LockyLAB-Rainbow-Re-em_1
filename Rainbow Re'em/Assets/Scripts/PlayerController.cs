using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {

	// TimberBetweenJumps puts a delay of one second between jumps
	public float timerBetweenJumps = 1f;
	// XboxController allow the choice of which controller from the front end
	public XboxController controller;
	// WalkSpeed sets the base value for the player to move at
	public float walkSpeed = 2;
	// JumpSpeed sets the base value for the player to jump at
	public float jumpSpeed = 5;
	// Timer sets the base value for the distance between jumps
	private float timer;
	// The layer the ground is referenced to
	public LayerMask groundLayer;
	// Checks that the player is on the ground || platform
	public bool isGrounded = false;
	// Base position for the Raycast origin
	private Vector3 origin = new Vector3(0, 0, 0);
	// Public reference for the main camera
	public GameObject mainCamera;
	// Checks that the player is in the air 
	public bool isFalling = false;
	// Downforce sets the base drag value of the players jump
	public float downforce;
	// Public reference for the Rigidbody
	public Rigidbody rb;

	//Sets the timer base position
	//Sets rb as the rigidbody
	void Start () {
		timer = Time.time;
		rb = GetComponent <Rigidbody> ();

	}
	

	// Sets the origin position for the Raycast and enables the camera to follow the player
	void Update () {
		origin = transform.position;

		float cameraXpos = 0;
		float cameraYpos = this.transform.position.y + 1.5f;
		float cameraZpos = -9.6f;
		mainCamera.transform.position = new Vector3 (cameraXpos, cameraYpos, cameraZpos);

		}

	// Enables the player to jump and adds drag to slow the jump down
	void Jump(){
		gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * jumpSpeed);

		if (isFalling == true) {
			rb.drag = downforce;
		}


		if (Time.time - timer > timerBetweenJumps)
			timer = Time.time;
	}

	// Shooting Raycast from the player to check if it is touching an object and stoping it from double jumping
	void CheckGround(){
		if (Physics.Raycast(origin,-transform.up, 1f, groundLayer)){
			isGrounded = true;

		}else {
			isGrounded = false;
		}
	}

	// Moving the player along the X and Y axis
	// Mulitplies walkSpeed by one and the input of the joystick (either 0 to 1 or 0 to -1)
	void MovePlayer(){
		

		gameObject.GetComponent<Rigidbody> ().AddForce (transform.right * walkSpeed * XCI.GetAxis (XboxAxis.LeftStickX, controller)); 

	}

	// Upon button A press & player is on the ground, funs Jump.
	void FixedUpdate (){
		CheckGround ();
		MovePlayer ();


		if ( XCI.GetButtonDown(XboxButton.A, controller ) && isGrounded == true){
			isFalling = true;
			Jump ();

		} else {
			isFalling = false;
		}

	}
}



