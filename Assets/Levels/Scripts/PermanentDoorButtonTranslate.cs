using UnityEngine;
using System.Collections;
using System;

public class PermanentDoorButtonTranslate : MonoBehaviour
{
	public GameObject _shedDoor;
	public GameObject positionObj;
	public GameObject _links;

	private Boolean triggered = false;
	private Collider other; 

	private Vector3 defaultPosition;
	private Vector3 pressedPosition;

	private float openDoorHeight;
	private Vector3 doorPosition;
	private Vector3 doorTriggered;
	private Vector3 direction;

	public float doorSpeed = 0.1f;

	void Start()
	{
		defaultPosition = transform.position;
		pressedPosition = transform.position - (transform.up*GetComponent<Renderer>().bounds.size.y/2);


		doorPosition = _shedDoor.transform.position;
		pressedPosition = positionObj.transform.position;
		direction = (doorTriggered - doorPosition).normalized;
		//openDoorHeight = doorPosition.y - (_shedDoor.transform.up*_shedDoor.GetComponent<Renderer> ().bounds.size.y).y;
	}

	void FixedUpdate()
	{
		if (triggered) {
			if ((_shedDoor.transform.position.x - doorTriggered.x)< direction.x*doorSpeed
				&& (_shedDoor.transform.position.y - doorTriggered.y)< direction.y*doorSpeed
				&& (_shedDoor.transform.position.z - doorTriggered.z)< direction.z*doorSpeed) {
				_shedDoor.transform.position = new Vector3 (doorPosition.x, openDoorHeight, doorPosition.z);
			}else {
				_shedDoor.transform.position += direction * doorSpeed;
			}
		} else {
			if ((_shedDoor.transform.position.x - doorPosition.x) < direction.x*doorSpeed
				&& (_shedDoor.transform.position.y - doorPosition.y) < direction.y*doorSpeed
				&& (_shedDoor.transform.position.z - doorPosition.z) < direction.z*doorSpeed) {
				_shedDoor.transform.position = doorPosition;
			} else {
				_shedDoor.transform.position -= direction * doorSpeed;
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		transform.position = pressedPosition;
		this.other = other;
		this.triggered = true;
	}

	void OnTriggerExit(Collider other)
	{
		transform.position = defaultPosition;
		triggered = false;
	}

}
