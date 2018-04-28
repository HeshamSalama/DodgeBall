using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balleffect : MonoBehaviour {
	Animator anim ;
	private CharacterController controller;
	public GameObject cube;
	public GameObject PlayerCamera;
	SphereCollider ballobject;
	private int p = 0;
	GameObject [] gettingball;
	Rigidbody r ;
	CapsuleCollider t;
	public GameObject obj;
	float time = 100f;
	static int changing=0;
	public chathead chat; 
	void Start () {
		
		anim = GetComponent<Animator> ();
		t = GetComponent<CapsuleCollider> ();
		r = GetComponent<Rigidbody> ();




	}

	// Update is called once per frame
	void Update () {
		if (Time.time > time + 5f && changing==1) {
			SceneManager.LoadScene("gameover");
			changing = 0;

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

			Controlplayer.disablebutton = true;
			anim.SetBool ("Jummping", false);
			anim.SetBool("ToForward", false);
			anim.SetBool("ToBackward", false);
			anim.SetBool("ToLeft", false);
			anim.SetBool("ToRight", false);
			anim.SetBool("Toidle", true);
			anim.SetBool ("ToRunForward", false);
			anim.SetBool ("ToRunRight", false);
			anim.SetBool ("ToRunLeft", false);
			t.height = 2;
			Vector3 cubepostion;
			cubepostion = Vector3.zero;
			cubepostion.x = cube.transform.position.x;
			cubepostion.y = transform.position.y;
			cubepostion.z = cube.transform.position.z;
			Debug.Log(cubepostion);
			//r.isKinematic = true;
			anim.SetBool("Sad",true);
			transform.position = cubepostion;
			transform.LookAt (obj.transform.position);
			chat.appear ();
			changing = 1;
			time = Time.time;
			//r.isKinematic = false;
			}
	

	}

}
