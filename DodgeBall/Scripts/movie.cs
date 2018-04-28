using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movie : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//((MovieTexture)GetComponent<Renderer> ().material.mainTexture).Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void NewGameBtn(string newGamelevel)
	{
		SceneManager.LoadScene("OurFinalProject");
	}
}
