using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlplayer : MonoBehaviour {
	public bool isGrounded;
	private float speed;
	public float rotSpeed;
	public float jumpHeight;
	private float rot_speed = 0.05f;
	private float w_speed = 0.05f;
	private float r_speed = 0.09f;
	Rigidbody rb;
	private static int change = 0;
	public static bool disablebutton = false;
	CapsuleCollider capsule;
	Animator anim;
	void Start () {
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		capsule = GetComponent<CapsuleCollider> ();
		isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(disablebutton==false)
		{
		if (isGrounded) {
				if (Input.GetKey (KeyCode.W)) {

					change = 1;
					if (Input.GetKey (KeyCode.LeftShift)) {
						speed = r_speed;
						movementControl ("RunningForward");
						if (Input.GetKey (KeyCode.Space)) {
							jumpHeight = 2;
							movementControl ("Jumpping");
							rb.AddForce(0, jumpHeight * Time.deltaTime, 0);
							isGrounded = false;

						}

					}
					 
					else {
						speed = w_speed;
						movementControl ("WalkingForward");
					}

				} else if (Input.GetKey (KeyCode.S)) {
					change = 1;
					if (Input.GetKey (KeyCode.LeftShift)) {
						speed = r_speed;
						movementControl ("RunningBackward");
					} else {
						speed = w_speed;
						movementControl ("WalkingBackward");
					}

				} else if (Input.GetKey (KeyCode.A)) {
					change = 2;
			
					if (Input.GetKey (KeyCode.LeftShift)) {
						rot_speed = r_speed;
						movementControl ("RunningLeft");
					} else {
						rotSpeed = rot_speed;
						movementControl ("WalkingLeft");
						
					}

				} else if (Input.GetKey (KeyCode.D)) {
					change = 2;
				
					if (Input.GetKey (KeyCode.LeftShift)) {
						rot_speed = r_speed;
						movementControl ("RunningRight");					
					} else {
						rotSpeed = rot_speed;
						movementControl ("WalkingRight");
					}
				} else if (Input.GetKey (KeyCode.Space)) {
					jumpHeight = 2;
					movementControl ("Jumpping");
					rb.AddForce(0, jumpHeight * Time.deltaTime, 0);
					isGrounded = false;

				}
			else {
				movementControl ("idle");
					capsule.height = 2;
					jumpHeight = 0;

			}
				/*if (Input.GetKey (KeyCode.LeftShift)) {
					if (change == 1) {
						speed = r_speed;
						movementControl ("RunningForward");
					} else if (change == 2) {
						speed = r_speed;
						movementControl ("RunningBackward");
					} else if (change == 3) {
						rot_speed = r_speed;
						movementControl ("RunningRight");
					} else if (change == 4) {
						rot_speed = r_speed;
						movementControl ("RunningLeft");
					}

				}*/

		}
		float mouseInput = Input.GetAxis("Mouse X");
		Vector3 lookhere = new Vector3(0,mouseInput,0);
		transform.Rotate(lookhere);
			if (change == 1) {
				var z = Input.GetAxis ("Vertical") * speed;
				transform.Translate (0, 0, z);
			} else if (change == 2) {
				var x = Input.GetAxis ("Horizontal") *rot_speed;
				transform.Translate (x, 0, 0);
			}
		
		//var y = Input.GetAxis ("Vertical") *jumpHeight;
		//transform.Rotate (0,y,0);
		}
	}
	void collidjump()
	{
		capsule.height = 1;
	}
	void backcollid()
	{
		capsule.height = 2;
		isGrounded = true;
	
	}
	void movementControl(string state)
	{
		switch (state)
		{
		case "WalkingForward":
			anim.SetBool ("ToForward", true);
			anim.SetBool ("ToBackward", false);
			anim.SetBool ("ToLeft", false);
			anim.SetBool ("ToRight", false);
			anim.SetBool ("Toidle", false);
			anim.SetBool ("ToRunForward", false);
			anim.SetBool ("ToRunBackward", false);
			anim.SetBool ("ToRunRight", false);
			anim.SetBool ("ToRunLeft", false);
			break;
		case "WalkingBackward":
			anim.SetBool("ToForward", false);
			anim.SetBool("ToLeft", false);
			anim.SetBool("ToBackward", true);
			anim.SetBool("ToRight", false);
			anim.SetBool("Toidle", false);
			anim.SetBool ("ToRunForward", false);
			anim.SetBool ("ToRunBackward", false);
			anim.SetBool ("ToRunRight", false);
			anim.SetBool ("ToRunLeft", false);

			break;
		case "idle":
			anim.SetBool ("ToForward", false);
			anim.SetBool ("ToBackward", false);
			anim.SetBool ("ToLeft", false);
			anim.SetBool ("ToRight", false);
			anim.SetBool ("Toidle", true);
			anim.SetBool ("ToRunForward", false);
			anim.SetBool ("ToRunRight", false);
			anim.SetBool ("ToRunLeft", false);
			anim.SetBool ("ToRunBackward", false);
			anim.SetBool ("Jummping", false);
			break;
		case "WalkingLeft":
			
			anim.SetBool ("ToForward", false);
			anim.SetBool ("ToBackward", false);
			anim.SetBool ("ToLeft", true);
			anim.SetBool ("ToRight", false);
			anim.SetBool ("Toidle", false);
			anim.SetBool ("ToRunForward", false);
			anim.SetBool ("ToRunBackward", false);
			anim.SetBool ("ToRunRight", false);
			anim.SetBool ("ToRunLeft", false);
			break;
		case "WalkingRight":
			anim.SetBool ("ToForward", false);
			anim.SetBool ("ToBackward", false);
			anim.SetBool ("ToLeft", false);
			anim.SetBool ("ToRight", true);
			anim.SetBool ("Toidle", false);
			anim.SetBool ("ToRunForward", false);
			anim.SetBool ("ToRunBackward", false);
			anim.SetBool ("ToRunRight", false);
			anim.SetBool ("ToRunLeft", false);

			break;
		case "RunningForward":
			anim.SetBool ("ToForward", false);
			anim.SetBool ("ToBackward", false);
			anim.SetBool ("ToLeft", false);
			anim.SetBool ("ToRight", false);
			anim.SetBool ("Toidle", false);	
			anim.SetBool ("ToRunBackward", false);
			anim.SetBool ("ToRunForward", true);
			anim.SetBool ("ToRunRight", false);
			anim.SetBool ("ToRunLeft", false);
			anim.SetBool ("Jummping", false);
			break;
		case "RunningBackward":
			anim.SetBool ("ToForward", false);
			anim.SetBool ("ToBackward", false);
			anim.SetBool ("ToLeft", false);
			anim.SetBool ("ToRight", false);
			anim.SetBool ("Toidle", false);	
			anim.SetBool ("ToRunForward", false);
			anim.SetBool ("ToRunBackward", true);
			anim.SetBool ("ToRunRight", false);
			anim.SetBool ("ToRunLeft", false);
			break;
		case "RunningRight":
			anim.SetBool ("ToForward", false);
			anim.SetBool ("ToBackward", false);
			anim.SetBool ("ToLeft", false);
			anim.SetBool ("ToRight", false);
			anim.SetBool ("Toidle", false);	
			anim.SetBool ("ToRunForward", false);
			anim.SetBool ("ToRunBackward", false);
			anim.SetBool ("ToRunRight", true);
			anim.SetBool ("ToRunLeft", false);	

			break;
		case "RunningLeft":
			anim.SetBool ("ToForward", false);
			anim.SetBool ("ToBackward", false);
			anim.SetBool ("ToLeft", false);
			anim.SetBool ("ToRight", false);
			anim.SetBool ("Toidle", false);	
			anim.SetBool ("ToRunForward", false);
			anim.SetBool ("ToRunBackward", false);
			anim.SetBool ("ToRunRight", false);
			anim.SetBool ("ToRunLeft", true);	
			break;
		case "Jumpping":
			anim.SetBool ("ToRunForward", false);
			anim.SetBool ("Toidle", false);
			anim.SetBool ("Jummping", true);
			break;
		}
	}
}
