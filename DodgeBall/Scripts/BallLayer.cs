using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLayer : MonoBehaviour {
    public GameObject ball;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ball.tag == "ball" && transform.position.z >=10)
            {
                ball.layer = 10;
            }
		else if (ball.tag == "ball" && transform.position.x <= 10)
        {
            ball.layer = 11;
        }
	}
}
