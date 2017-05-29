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




	// Start()
	// 		Called once at the beginning of the game sets the timer to count in normal time. 
	// 		short hand for grabing the player Rigidbody and sets the base value for drag at 0
	// Param:
	//
	// Return:
	// 		void

	void Start () {
		timer = Time.time;
		rb = GetComponent <Rigidbody> ();
		rb.drag = 0;

	}


	// Jump()
	// 	Runs when the player presses A and moves the player vertically with physics.
	//	Also sets a timer of a set value between jumps, to limit jump spaming.
	// Params:
	//
	// Return:
	// 		void

	void Jump(){
		rb.AddForce (transform.up * jumpSpeed);
			
		if (Time.time - timer > timerBetweenJumps) {
			timer = Time.time;
		}
	}


	// CheckGround()
	// 	Runs every frame and shoots an invisible line from below the player to check if the player is on the ground or in the air
	// Params:
	//
	// Return:
	//		void

	void CheckGround(){
		if (Physics.Raycast(origin,-transform.up, 1f, groundLayer)){
			isGrounded = true;
			isFalling = false;

		}else {
			isGrounded = false;
			isFalling = true;
		}
	}


		
	// MovePlayer()
	//  Called when the player moves the left jopystick along the X axis
	//  Multiplies movement by a set value
	// Params:
	//
	// Return:
	// 		void

	void MovePlayer(){
		rb.AddForce (transform.right * walkSpeed * XCI.GetAxis (XboxAxis.LeftStickX, controller));

	}




//	void OnCollisionEnter (Collision other){
//		if(other.gameObject.tag == "Moving"){
//			rb.velocity = target.GetComponent<Rigidbody> ().velocity;
//			Debug.Log (target.GetComponent<Rigidbody> ().velocity);
//
//		}
//	}



	// Update()
	// 	Runs once every frame, sets the origin position of the player so the raycast can reset. 
	// 	Camera follows the player along the Y Axis
	// Params:
	//
	// Return:
	// 		void

	void Update () {
		origin = transform.position;

		float cameraXpos = 0;
		float cameraYpos = this.transform.position.y + 1.5f;
		float cameraZpos = -9.6f;
		mainCamera.transform.position = new Vector3 (cameraXpos, cameraYpos, cameraZpos);

	}


	// FixedUpdate()
	//	Runs last every frame, runs CheckGround and Moveplayer.
	// 	enables the player to jump by pressing A, then runs Jump
	// 	Checks to see if the player is in the air, if so adds negative velocity to the player to make it fall quicker and
	//  Also releases drag upon jump to increase mid air movement
	// Params:
	//
	// Return:
	//		void
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



