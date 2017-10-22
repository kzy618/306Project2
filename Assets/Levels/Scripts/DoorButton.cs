using UnityEngine;
using System.Collections;
using System;

public class DoorButton : MonoBehaviour
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

	void Start()
	{
		defaultPosition = transform.position;
		//pressedPosition = new Vector3(defaultPosition.x, defaultPosition.y-(GetComponent<Renderer>().bounds.size.y/2),defaultPosition.z);
		pressedPosition = transform.position - (transform.up*GetComponent<Renderer>().bounds.size.y/2);

		doorPosition = _shedDoor.transform.position;
		openDoorHeight = doorPosition.y - (_shedDoor.transform.up*_shedDoor.GetComponent<Renderer> ().bounds.size.y).y;
	}

    void FixedUpdate()
	{
		if (triggered && !other) {
			transform.position = defaultPosition;
			triggered = false;
		}
		if (triggered) {
			_shedDoor.transform.position = new Vector3 (doorPosition.x, _shedDoor.transform.position.y - doorSpeed, doorPosition.z);
			if (_shedDoor.transform.position.y <= openDoorHeight) {
				_shedDoor.transform.position = new Vector3 (doorPosition.x, openDoorHeight-0.01f, doorPosition.z);
			}

			foreach (Transform childTransform in _links.transform) {
				GameObject child = childTransform.gameObject;
				child.GetComponent<Renderer> ().material = triggerMat;
			}
		} else {
			_shedDoor.transform.position = new Vector3 (doorPosition.x, _shedDoor.transform.position.y + doorSpeed, doorPosition.z);
			if (_shedDoor.transform.position.y >= doorPosition.y) {
				_shedDoor.transform.position = new Vector3 (doorPosition.x, doorPosition.y, doorPosition.z);
			}

            if (_links != null)
            {
                foreach (Transform childTransform in _links.transform)
                {
                    GameObject child = childTransform.gameObject;
                    child.GetComponent<Renderer>().material = untriggerMat;
                }
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
