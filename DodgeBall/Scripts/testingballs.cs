using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class testingballs : MonoBehaviour {
	public Image powerbar;
	public Image basicbar;
	public GameObject balll;
	GameObject ball;
	public GameObject PlayerCamera;
	public GameObject leg;
	public float ballDistance = 1f;
	public float ballThroeingForce = 200f;
	public static bool holdingBall = false;
	public GameObject head;
	Animator anim;
	GameObject[] gos;
	public float power =0.0f;
	public float firerate=0.5f;
	public float nextfire = 0.0f;
	private float maxpower = 100f;
	static int x =0;
	static int force=1;
	// Use this for initialization
	void Start()
	{
		//ball.GetComponent<Rigidbody>().useGravity = false;
		anim = GetComponent<Animator> ();
		basicbar.gameObject.SetActive (false);

	}
	// Update is called once per frame
	void Update()
	{  
		if (Input.GetButtonDown ("Fire1") && holdingBall == false) {
			float angle = 30;
			ball = FindCloset (leg, balll);
			float dist = Vector3.Distance (ball.transform.position, leg.transform.position);
			if (dist <= 1.5f && Vector3.Angle (leg.transform.forward, ball.transform.position - leg.transform.position) < angle) {
				ball.tag="holding";
				anim.SetTrigger ("Holding");

			}
		}
		if (holdingBall)
		{
			ball.transform.position = PlayerCamera.transform.position;
			/*if(Input.GetMouseButtonDown(0)){
				anim.SetBool("Toidle", false);
				anim.SetTrigger ("Throw");

			}*/
			if (Input.GetMouseButtonDown (0)) {
				basicbar.gameObject.SetActive (true);
				power += Time.deltaTime;
				x = 1;
				force++;
			}

			if(Input.GetMouseButtonUp(0))
				{
				x = 0;
				basicbar.gameObject.SetActive (false);
				powerbar.fillAmount = 0;
				anim.SetBool("Toidle", false);
				nextfire = (force/5) + firerate;
				anim.SetTrigger ("Throw");
				force = 1;

				}
			if (x == 1) {
				if (powerbar.fillAmount < 1) {
					force++;
				}
				powerbar.fillAmount = force/maxpower;

			}
				
		}

	}

	void throwball()
	{
		holdingBall = false;
		ball.GetComponent<Rigidbody>().useGravity = true;
		//ball.transform.position =head.transform.forward;
		Debug.Log(nextfire);
		ball.GetComponent<Rigidbody> ().velocity =head.transform.forward* nextfire;
		ball.GetComponent<Rigidbody> ().freezeRotation = false;
		ball.tag="ball";


	}
	void Holding()
	{
		holdingBall = true;
		ball.GetComponent<Rigidbody> ().freezeRotation = true;
		ball.transform.position = PlayerCamera.transform.position;



	}

	public GameObject FindCloset(GameObject leg,GameObject ball)
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag ("ball");
		GameObject closest = null;

		foreach (GameObject go in gos) {
			float dist = Vector3.Distance(go.transform.position,leg.transform.position);
			if (dist <= 1.5f) {
				closest = go;
				break;
			}

		}
		if (closest == null) {
			return ball;
		} else {
			return closest;
		}

	}

}
