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

	private AudioSource _doorSound;

	void Start()
	{
		_doorSound = GetComponent<AudioSource> ();
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
			openDoorSound ();
			transform.position = pressedPosition;
			this.other = other;
			this.triggered = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("pickable"))
		{
			openDoorSound ();
			transform.position = defaultPosition;
			triggered = false;
		}
	}

	// Play door sound if audio source exists 
	void openDoorSound() {
		if (_doorSound != null) {
			// start playuing the door sound as it opens
			_doorSound.Play();
		}
	}

	// Play door sound if audio source exists 
	void stopOpenDoorSound() {
		if (_doorSound != null) {
			// stop the door sound if it's still playing
			if(_doorSound.isPlaying){
				_doorSound.Stop();
			}
		}
	}

}
