using UnityEngine;
using System.Collections;

public class PermanentDoorButton : MonoBehaviour {
	public GameObject _shedDoor;

	private bool triggered = false;
	private Collider other; 

	private Vector3 defaultPosition;
	private Vector3 pressedPosition;

	private float openDoorHeight;
	private Vector3 doorPosition;

	public float doorSpeed = 0.1f;

	void Start()
	{
		defaultPosition = transform.position;
		pressedPosition = new Vector3(defaultPosition.x, defaultPosition.y-(GetComponent<Renderer>().bounds.size.y/2),defaultPosition.z);

		doorPosition = _shedDoor.transform.position;
		openDoorHeight = doorPosition.y - _shedDoor.GetComponent<Renderer> ().bounds.size.y;
	}

	void FixedUpdate()
	{
		if (triggered) {
			_shedDoor.transform.position = new Vector3(doorPosition.x, _shedDoor.transform.position.y-doorSpeed, doorPosition.z);
			if (_shedDoor.transform.position.y <= openDoorHeight) {
				_shedDoor.transform.position = new Vector3(doorPosition.x, openDoorHeight, doorPosition.z);
			}
		}

	}


	void OnTriggerEnter (Collider other)
	{
		this.other = other;
		this.triggered = true;
	}

	void OnTriggerExit(Collider other)
	{
		transform.position = defaultPosition;
		triggered = false;
	}
}
