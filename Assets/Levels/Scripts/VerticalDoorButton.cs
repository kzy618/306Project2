using UnityEngine;
using System.Collections;
using System;

public class VerticalDoorButton : MonoBehaviour
{
	public GameObject _shedDoor;
	public GameObject _links;

	public Material untriggerMat;
	public Material triggerMat;

    private Boolean triggered = false;
    private Collider other; 

	private Vector3 defaultPosition;
	private Vector3 pressedPosition;

	private float openDoorHeight;
	private Vector3 doorPosition;

	public float doorSpeed = 0.1f;

	private AudioSource _doorSound;

	void Start()
	{
		_doorSound = GetComponent<AudioSource> ();
		defaultPosition = transform.position;
		pressedPosition = new Vector3(defaultPosition.x+(GetComponent<Renderer>().bounds.size.x/2), defaultPosition.y,defaultPosition.z);

		doorPosition = _shedDoor.transform.position;
		openDoorHeight = doorPosition.y - _shedDoor.GetComponent<Renderer> ().bounds.size.y;
	}

    void FixedUpdate()
    {
        if(triggered && !other)
        {
			transform.position = defaultPosition;
            triggered = false;
        }
		if (triggered) {
			_shedDoor.transform.position = new Vector3(doorPosition.x, _shedDoor.transform.position.y-doorSpeed, doorPosition.z);
			if (_shedDoor.transform.position.y <= openDoorHeight) {
				_shedDoor.transform.position = new Vector3(doorPosition.x, openDoorHeight, doorPosition.z);
			}

			foreach (Transform childTransform in _links.transform) {
				GameObject child = childTransform.gameObject;
				child.GetComponent<Renderer> ().material = triggerMat;
			}
		} else {
			_shedDoor.transform.position = new Vector3(doorPosition.x, _shedDoor.transform.position.y+doorSpeed, doorPosition.z);
			if (_shedDoor.transform.position.y >= doorPosition.y) {
				_shedDoor.transform.position = new Vector3(doorPosition.x, doorPosition.y, doorPosition.z);
			}

			foreach (Transform childTransform in _links.transform) {
				GameObject child = childTransform.gameObject;
				child.GetComponent<Renderer> ().material = untriggerMat;
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
