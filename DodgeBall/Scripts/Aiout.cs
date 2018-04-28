using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aiout : MonoBehaviour {
	Animator anim ;
	static int score;
	private CharacterController controller;
	public GameObject cube;
	SphereCollider ballobject;
	private int p = 0;
	GameObject [] gettingball;
	Rigidbody r ;
	CapsuleCollider t;
	public GameObject PlayerCamera;
	void Start () {

		anim = GetComponent<Animator> ();
		t = GetComponent<CapsuleCollider> ();
		r = GetComponent<Rigidbody> ();
		score = 1;



	}

	// Update is called once per frame
	void Update () {
		if (score == 0) {
			//SceneManager.LoadScene("win");
		}
	}

	void OnCollisionEnter(Collision col)	
	{

		if (col.gameObject.tag == "ball" || col.gameObject.tag=="Line") {
			gettingball = GameObject.FindGameObjectsWithTag ("holding");
			if (gettingball.Length>0) {
				foreach (GameObject go in gettingball) {
					if ((int)go.transform.position.z == (int)PlayerCamera.transform.position.z) {

						testingballs.holdingBall = false;
						go.transform.position= transform.position;
						break;
					}
				}

			}

			AI.disable = true;
			anim.SetBool("ToForward", false);
			anim.SetBool("ToBackward", false);
			anim.SetBool("ToLeft", false);
			anim.SetBool("ToRight", false);
			anim.SetBool("Toidle", true);
			anim.SetBool ("ToRunForward", false);
			anim.SetBool ("ToRunRight", false);
			anim.SetBool ("ToRunLeft", false);
			Vector3 cubepostion;
			cubepostion = Vector3.zero;
			cubepostion.x = cube.transform.position.x;
			cubepostion.y = transform.position.y;
			cubepostion.z = cube.transform.position.z;
			Debug.Log(cubepostion);
			//r.isKinematic = true;
			transform.position = cubepostion;
			score -= 1;
			//r.isKinematic = false;
		}


	}
}
