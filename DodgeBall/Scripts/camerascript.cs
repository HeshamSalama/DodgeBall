using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour {
	private const float Y_ANGLE_Min = 20.0f;
	private const float Y_ANGLE_MAX = 50.0f;
	public Transform LookAt;
	public Transform camTransform;
	private Camera cam;
	private float distance =4.5f;
	private float currentX= 0.0f;
	private float currentY = 0.0f;
	private float sensivityx =4.0f;
	private float sensivityy=1.0f;
	public static bool disablebutton = false;
	// Use this for initialization
	void Start () {
		camTransform = transform;
		cam = Camera.main;
		currentX = Input.GetAxis ("Mouse X");
		currentY = Input.GetAxis ("Mouse Y");
		currentY = Mathf.Clamp (currentY, Y_ANGLE_Min, Y_ANGLE_MAX);

	}
	private void LateUpdate()
	{
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);
		camTransform.position = LookAt.position + rotation * dir;
		camTransform.LookAt(LookAt.position);


	}
	// Update is called once per frame
	void Update () {
		if (disablebutton==false) {
			currentX += Input.GetAxis ("Mouse X");
			currentY += Input.GetAxis ("Mouse Y");
			currentY = Mathf.Clamp (currentY, Y_ANGLE_Min, Y_ANGLE_MAX);
		}
	}
}
