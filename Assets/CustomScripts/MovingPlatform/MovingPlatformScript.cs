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
		radian += 0.005f;
		transform.position = new Vector3 (defaultPos.x + Mathf.Pow(Mathf.Sin(radian), 2)*25f, defaultPos.y, defaultPos.z);
		
	}
}
