using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class startcounter : MonoBehaviour {
	public Sprite []images;
	static int i=0;
	float time;
	Image myImageComponent;
	// Use this for initialization
	void Start () {
		myImageComponent = GetComponent<Image>();
		Controlplayer.disablebutton = true;
		camerascript.disablebutton = true;
		AI.disable = true;	
		time = Time.time;
	   
		
		


	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time<time+7) {
			myImageComponent.sprite = images [(int)(Time.time-time)];
		}
		else if (Time.time >time+8) {
			Controlplayer.disablebutton = false;
			camerascript.disablebutton = false;
			AI.disable = false;
			gameObject.SetActive (false);

		}


	}
}
