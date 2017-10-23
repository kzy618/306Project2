using UnityEngine;
using System.Collections;
using System;

public class PermanentDoorButtonTranslate : MonoBehaviour
{
	public GameObject _shedDoor;
	public GameObject positionObj;
	public GameObject _links;

	public Material untriggerMat;
	public Material triggerMat;

	private Boolean triggered = false;
	private Collider other; 

	private Vector3 defaultPosition;
	private Vector3 pressedPosition;

	private float openDoorHeight;
	private Vector3 doorPosition;
	private Vector3 doorTriggered;
	private Vector3 direction;

	public float doorSpeed = 0.1f;

	private AudioSource _doorSound;

	void Start()
	{
		_doorSound = GetComponent<AudioSource> ();
		defaultPosition = transform.position;
		pressedPosition = transform.position - (transform.up*GetComponent<Renderer>().bounds.size.y);


		doorPosition = _shedDoor.transform.position;
		doorTriggered = positionObj.transform.position;
		direction = (doorTriggered - doorPosition).normalized;
		//openDoorHeight = doorPosition.y - (_shedDoor.transform.up*_shedDoor.GetComponent<Renderer> ().bounds.size.y).y;
	}

	void FixedUpdate()
	{
		if (triggered && !other) {
			transform.position = defaultPosition;
			//triggered = false;
		}
		if (triggered) {
			if ((_shedDoor.transform.position - doorTriggered).magnitude > (direction * doorSpeed).magnitude) {
				_shedDoor.transform.position += direction * doorSpeed;
			} else {
				_shedDoor.transform.position = doorTriggered;
			}

			foreach (Transform childTransform in _links.transform) {
				GameObject child = childTransform.gameObject;
				child.GetComponent<Renderer> ().material = triggerMat;
			}
		} else {
			if ((_shedDoor.transform.position - doorPosition).magnitude > (direction * doorSpeed).magnitude) {
				_shedDoor.transform.position -= direction * doorSpeed;
			} else {
				_shedDoor.transform.position = doorPosition;
			}

			foreach (Transform childTransform in _links.transform) {
				GameObject child = childTransform.gameObject;
				child.GetComponent<Renderer> ().material = untriggerMat;
			}
		}/*
		if (triggered) {
			_shedDoor.transform.position += direction * doorSpeed;
			if ((_shedDoor.transform.position.x - doorTriggered.x)< direction.x*doorSpeed
				&& (_shedDoor.transform.position.y - doorTriggered.y)< direction.y*doorSpeed
				&& (_shedDoor.transform.position.z - doorTriggered.z)< direction.z*doorSpeed) {
				_shedDoor.transform.position = doorTriggered;
			}
		} else {
			_shedDoor.transform.position -= direction * doorSpeed;
			if ((_shedDoor.transform.position.x - doorPosition.x) < direction.x*doorSpeed
				&& (_shedDoor.transform.position.y - doorPosition.y) < direction.y*doorSpeed
				&& (_shedDoor.transform.position.z - doorPosition.z) < direction.z*doorSpeed) {
				_shedDoor.transform.position = doorPosition;
			}
		}*/
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("pickable")) {
			openDoorSound ();
			transform.position = pressedPosition;
			this.other = other;
			this.triggered = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("pickable")) {
			openDoorSound ();
			transform.position = defaultPosition;
		}
		//triggered = false;
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
