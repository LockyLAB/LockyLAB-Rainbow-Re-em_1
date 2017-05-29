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
	// Weight sets the base value for load onto the player
	public float weight;
	// Public reference for the Rigidbody
	private Rigidbody rb;
	//Plaform target for velocity change
	public GameObject target;
	// Platform target for velocity change
	public GameObject altTarget;
	//Downforce sets the base value for drag when jumping 
	public float downforce;
	//Resistence sets the base value for drag when walking
	public float Resistence;




	//Sets the timer base position
	//Sets rb as the rigidbody
	void Start () {
		timer = Time.time;
		rb = GetComponent <Rigidbody> ();
		rb.drag = 0;

	}


	// Enables the player to jump
	void Jump(){
		rb.AddForce (transform.up * jumpSpeed);
			
		if (Time.time - timer > timerBetweenJumps) {
			timer = Time.time;
		}
	}


	// Shooting Raycast from the player to check if it is touching an object and stoping it from double jumping
	void CheckGround(){
		if (Physics.Raycast(origin,-transform.up, 1f, groundLayer)){
			isGrounded = true;
			isFalling = false;

		}else {
			isGrounded = false;
			isFalling = true;
		}
	}


		

	// Moving the player along the X and Y axis
	// Mulitplies walkSpeed by one and the input of the joystick (either 0 to 1 or 0 to -1)
	void MovePlayer(){
		rb.AddForce (transform.right * walkSpeed * XCI.GetAxis (XboxAxis.LeftStickX, controller));

	}


	void OnCollisionEnter (Collision other){
		if(other.gameObject.tag == "Moving"){
			rb.velocity = target.GetComponent<Rigidbody> ().velocity;
			Debug.Log (target.GetComponent<Rigidbody> ().velocity);

		}
	}



	// Sets the origin position for the Raycast and enables the camera to follow the player
	void Update () {
		origin = transform.position;

		float cameraXpos = 0;
		float cameraYpos = this.transform.position.y + 1.5f;
		float cameraZpos = -9.6f;
		mainCamera.transform.position = new Vector3 (cameraXpos, cameraYpos, cameraZpos);

	}


	// Upon button A press & player is grounded, runs Jump, Check Ground and MovePlayer.
	// Is Falling checks to see if player is in the air if so adds velocity to speed up fall.
	void FixedUpdate (){

		if (XCI.GetButtonDown (XboxButton.A, controller) && isGrounded == true) {
			Jump ();
		}

		if (isFalling == true) {
			rb.velocity += new Vector3 (0f, -weight, 0f);
			rb.drag = downforce;
		} else {
			rb.drag = Resistence;
		}
			
		CheckGround ();
		MovePlayer ();
	}
}



