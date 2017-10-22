using UnityEngine;
using System.Collections;
using System;

public class DoorButtonTranslate : MonoBehaviour
{
	public GameObject _shedDoor;
	public GameObject positionObj;
	public GameObject _links;

	private Boolean triggered = false;
	private Collider other; 

	private Vector3 defaultPosition;
	private Vector3 pressedPosition;

	private Vector3 doorPosition;
	private Vector3 doorTriggered;
	private Vector3 direction;

	public float doorSpeed = 0.1f;

	void Start()
	{
		defaultPosition = transform.position;
		pressedPosition = transform.position - (transform.up*GetComponent<Renderer>().bounds.size.y/2);


		doorPosition = _shedDoor.transform.position;
		doorTriggered = positionObj.transform.position;
		direction = (doorTriggered - doorPosition).normalized;
		//openDoorHeight = doorPosition.y - (_shedDoor.transform.up*_shedDoor.GetComponent<Renderer> ().bounds.size.y).y;
	}

	void FixedUpdate()
	{
		if (triggered && !other) {
			transform.position = defaultPosition;
			triggered = false;
		}
		if (triggered) {
			if ((_shedDoor.transform.position - doorTriggered).magnitude > (direction * doorSpeed).magnitude) {
				_shedDoor.transform.position += direction * doorSpeed;
			} else {
				_shedDoor.transform.position = doorTriggered;
			}
		} else {
			if ((_shedDoor.transform.position - doorPosition).magnitude > (direction * doorSpeed).magnitude) {
				_shedDoor.transform.position -= direction * doorSpeed;
			} else {
				_shedDoor.transform.position = doorPosition;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("pickable"))
		{
			transform.position = pressedPosition;
			this.other = other;
			this.triggered = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("pickable"))
		{
			transform.position = defaultPosition;
			triggered = false;
		}
	}

}
