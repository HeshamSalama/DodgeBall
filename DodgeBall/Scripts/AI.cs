using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AI : MonoBehaviour {

	public GameObject PlayerHand;
	public float checkRedius;
	public float ballDistance = 8f;
	public float ballThrowingForce = 100f;
	private bool holdingBall = false;
	private bool shooting = false;
	public LayerMask checkBallLayer;
	public LayerMask checkPlayerLayer;
	public Transform NonPlayerTransform;
	public Collider[] BallColliders;
	public Collider[] PlayerColliders;
	float timer = 0;
	float timer2 = 0;
	float shootTimer = 0;
	float step = 5.0f;
	public bool Done = false;
	public bool Done2 = false;
	Vector3 temp;
	Vector3 temp2;
	public Animator anim;
	public int Ball_Number = 0;
	public static bool disable=false;
	void Start()
	{
		anim = GetComponent<Animator>();
		temp = transform.position;
		temp2 = transform.position;
	}
	// Update is called once per frame
	void Update()
	{
		if (disable == false) {
			//-----------
			if (!holdingBall) {
				timer2 += Time.deltaTime;
				//Debug.Log("NotHolding");
				BallColliders = Physics.OverlapSphere (transform.position, checkRedius, checkBallLayer);
				Array.Sort (BallColliders, new DistanceCompare (transform));
				//Debug.Log(BallColliders.Length);
				//---------------------------------
				//------------------move randomly-----------------
				if (BallColliders.Length == 0) {

					if ((int)timer2 % 10 == 0) {          //change position every 10 sec
						if (!Done2) {
							Debug.Log ("Random");
							temp2 = new Vector3 (UnityEngine.Random.Range (-7f, 11.5f), -10.78f, UnityEngine.Random.Range (11f,18.5f));
							Done2 = true;
						}
					}
					if ((int)timer2 == 11) { //to apply random move each 11 sec
						Done2 = false;
						timer2 = 0;
					}
					transform.LookAt (temp2);
					movementControl ("WalkingForward");
					transform.position = Vector3.MoveTowards (transform.position, temp2, step * Time.deltaTime);
					if (transform.position == temp2) {
						transform.LookAt (new Vector3 (3.7f, -10.7f, 4.95f));
						movementControl ("idle");
					}
				}
			//--------------------------------
			else if (BallColliders [0].tag == "ball" /*&& BallColliders[0].transform.position.x > 41.1*/) {
					//Debug.Log("in!!");
					float dist = Vector3.Distance (BallColliders [0].transform.position, transform.position);
					if (dist >= 1.0f) {
						anim.SetBool ("ToRunForward", true);
						transform.LookAt (BallColliders [0].transform.position);
						transform.Translate (Vector3.forward * 5 * Time.deltaTime);
						//movementControl("RunningForward");
						if (dist <= 2f) {
							//anim.SetBool("ToRunForward", false);
							//movementControl("idle");
							BallColliders [0].GetComponent<Rigidbody> ().useGravity = false;
							anim.SetTrigger ("Holding");
							BallColliders [0].tag = "holding";
							//BallColliders[0].transform.position = PlayerHand.transform.position; ;
							//movementControl("idle");

						}
					}
				}

			}
		//------------------------
		else if (holdingBall) {   //else 3adi
				timer += Time.deltaTime;
				shootTimer += Time.deltaTime;
				if (shootTimer >= 7) {
					shooting = true;
				}
				PlayerColliders = Physics.OverlapSphere (transform.position, checkRedius, checkPlayerLayer);
				Array.Sort (PlayerColliders, new DistanceCompare (transform));
				BallColliders [0].transform.position = PlayerHand.transform.position;
				//------------------move randomly-----------------
				if ((int)timer % 10 == 0) {          //change position every 10 sec
					if (!Done) {
						Debug.Log ("Random");
						temp = new Vector3 (UnityEngine.Random.Range (-7f, 11.5f),-10.78f, UnityEngine.Random.Range (11f,18.5f));
						Done = true;
					}
				}
				if ((int)timer == 11) { //to apply random move each 11 sec
					Done = false;
					timer = 0;
				}
				transform.LookAt (temp);
				movementControl ("WalkingForward");
				transform.position = Vector3.MoveTowards (transform.position, temp, step * Time.deltaTime);
				if (transform.position == temp) {
					transform.LookAt (PlayerColliders [0].transform.position);
					movementControl ("idle");
				}
				//--------------------------------
				if (shooting) {
					anim.SetTrigger ("Throw");
					shootTimer = 0;
					shooting = false;
					//anim.SetBool("Toidle", true);
				}
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, checkRedius);
	}
	IEnumerator waiting()
	{
		yield return new WaitForSeconds(5);
	}
	void throwball()
	{
		holdingBall = false;
		BallColliders[0].GetComponent<Rigidbody>().useGravity = true;
		BallColliders[0].GetComponent<Rigidbody>().AddForce(transform.forward * ballThrowingForce);
		BallColliders[0].tag = "ball";
	}
	void Holding()
	{
		holdingBall = true;
		BallColliders[0].transform.position = PlayerHand.transform.position;
	}
	void movementControl(string state)
	{
		switch (state)
		{
		case "WalkingForward":
			anim.SetBool("ToForward", true);
			anim.SetBool("ToBackward", false);
			anim.SetBool("ToLeft", false);
			anim.SetBool("ToRight", false);
			anim.SetBool("Toidle", false);
			anim.SetBool("ToRunForward", false);
			anim.SetBool("ToRunBackward", false);
			anim.SetBool("ToRunRight", false);
			anim.SetBool("ToRunLeft", false);
			break;
		case "WalkingBackward":
			anim.SetBool("ToForward", false);
			anim.SetBool("ToLeft", false);
			anim.SetBool("ToBackward", true);
			anim.SetBool("ToRight", false);
			anim.SetBool("Toidle", false);
			anim.SetBool("ToRunForward", false);
			anim.SetBool("ToRunBackward", false);
			anim.SetBool("ToRunRight", false);
			anim.SetBool("ToRunLeft", false);

			break;
		case "idle":
			anim.SetBool("ToForward", false);
			anim.SetBool("ToBackward", false);
			anim.SetBool("ToLeft", false);
			anim.SetBool("ToRight", false);
			anim.SetBool("Toidle", true);
			anim.SetBool("ToRunForward", false);
			anim.SetBool("ToRunRight", false);
			anim.SetBool("ToRunLeft", false);
			anim.SetBool("ToRunBackward", false);
			break;
		case "WalkingLeft":

			anim.SetBool("ToForward", false);
			anim.SetBool("ToBackward", false);
			anim.SetBool("ToLeft", true);
			anim.SetBool("ToRight", false);
			anim.SetBool("Toidle", false);
			anim.SetBool("ToRunForward", false);
			anim.SetBool("ToRunBackward", false);
			anim.SetBool("ToRunRight", false);
			anim.SetBool("ToRunLeft", false);
			break;
		case "WalkingRight":
			anim.SetBool("ToForward", false);
			anim.SetBool("ToBackward", false);
			anim.SetBool("ToLeft", false);
			anim.SetBool("ToRight", true);
			anim.SetBool("Toidle", false);
			anim.SetBool("ToRunForward", false);
			anim.SetBool("ToRunBackward", false);
			anim.SetBool("ToRunRight", false);
			anim.SetBool("ToRunLeft", false);

			break;
		case "RunningForward":
			anim.SetBool("ToForward", false);
			anim.SetBool("ToBackward", false);
			anim.SetBool("ToLeft", false);
			anim.SetBool("ToRight", false);
			anim.SetBool("Toidle", false);
			anim.SetBool("ToRunBackward", false);
			anim.SetBool("ToRunForward", true);
			anim.SetBool("ToRunRight", false);
			anim.SetBool("ToRunLeft", false);
			break;
		case "RunningBackward":
			anim.SetBool("ToForward", false);
			anim.SetBool("ToBackward", false);
			anim.SetBool("ToLeft", false);
			anim.SetBool("ToRight", false);
			anim.SetBool("Toidle", false);
			anim.SetBool("ToRunForward", false);
			anim.SetBool("ToRunBackward", true);
			anim.SetBool("ToRunRight", false);
			anim.SetBool("ToRunLeft", false);
			break;
		case "RunningRight":
			anim.SetBool("ToForward", false);
			anim.SetBool("ToBackward", false);
			anim.SetBool("ToLeft", false);
			anim.SetBool("ToRight", false);
			anim.SetBool("Toidle", false);
			anim.SetBool("ToRunForward", false);
			anim.SetBool("ToRunBackward", false);
			anim.SetBool("ToRunRight", true);
			anim.SetBool("ToRunLeft", false);

			break;
		case "RunningLeft":
			anim.SetBool("ToForward", false);
			anim.SetBool("ToBackward", false);
			anim.SetBool("ToLeft", false);
			anim.SetBool("ToRight", false);
			anim.SetBool("Toidle", false);
			anim.SetBool("ToRunForward", false);
			anim.SetBool("ToRunBackward", false);
			anim.SetBool("ToRunRight", false);
			anim.SetBool("ToRunLeft", true);
			break;
		}
	}
	void OnTriggerEnter(Collider other)	{
		if (other.tag == "ball"&& other.transform.position.y>0) {
			movementControl ("WalkingRight");
			transform.Translate (new Vector3(transform.position.x+2,transform.position.y,transform.position.z));
					}	
	}
			

}


