using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linescript : MonoBehaviour {
	BoxCollider box;
	// Use this for initialization
	void Start () {
		box = GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		box.enabled = true;
	}
	void OnColliderEnter(Collision col)
	{
		//Debug.Log (col.gameObject.name);
		if (col.gameObject.tag == "ourplayer") {
		}

	}


}
