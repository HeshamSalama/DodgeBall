using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {
	float time;
	// Use this for initialization
	void Start () {
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= time + 3f) {
			SceneManager.LoadScene("MenuScreen");
		}
	}
}
