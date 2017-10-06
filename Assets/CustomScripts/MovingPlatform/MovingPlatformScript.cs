using UnityEngine;
using System.Collections;

public class MovingPlatformScript : MonoBehaviour {

	private Vector3 defaultPos;
	private float radian = 0f;

	// Use this for initialization
	void Start () {
		defaultPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		radian += 0.01f;
		transform.position = new Vector3 (defaultPos.x + Mathf.Sin(radian)*5f, defaultPos.y, defaultPos.z);
		
	}
}
