using UnityEngine;
using System.Collections;
using System;

public class StopingMovingPlat : MonoBehaviour {

	public GameObject position1;
	public GameObject position2;

	private Vector3 defaultPos; //the center between two positions
	private Vector3 posDiff; //vector between the two positions
	private float radian = 0f;
	public float radiansPerFrame = 0.005f;
	private Collider other;
	private Boolean IceCubeCollide;

	// Use this for initialization
	void Start () {
		IceCubeCollide = false;

		//defaultPos = transform.position;
		defaultPos = new Vector3 ((position1.transform.position.x + position2.transform.position.x)/2,
			(position1.transform.position.y + position2.transform.position.y)/2,
			(position1.transform.position.z + position2.transform.position.z)/2);
		posDiff = new Vector3 ((position1.transform.position.x - position2.transform.position.x)/2,
			(position1.transform.position.y - position2.transform.position.y)/2,
			(position1.transform.position.z - position2.transform.position.z)/2);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(IceCubeCollide && !other){
			IceCubeCollide = false;
		}

		if(!IceCubeCollide){
			radian +=  radiansPerFrame;
		}
			//transform.position = new Vector3 (defaultPos.x + Mathf.Pow(Mathf.Sin(radian), 2)*25f, defaultPos.y, defaultPos.z);
		transform.position = new Vector3 (defaultPos.x + Mathf.Sin (radian) * posDiff.x,
			defaultPos.y + Mathf.Sin (radian) * posDiff.y,
			defaultPos.z + Mathf.Sin (radian) * posDiff.z);
	}

	void OnTriggerStay(Collider other){
		if (other.CompareTag ("pickable")) {
			this.other = other;
			IceCubeCollide = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.CompareTag ("pickable")){
			IceCubeCollide = false;
		}
}
}