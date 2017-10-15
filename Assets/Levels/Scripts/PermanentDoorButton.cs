using UnityEngine;
using System.Collections;

public class PermanentDoorButton : MonoBehaviour {
	public GameObject _shedDoor;
	public GameObject _links;

	public Material untriggerMat;
	public Material triggerMat;

	public GameObject recedingGlass;
	public float glassRecedeRate = 0.3f;
	private Vector3 triggeredGlassPos;

	private bool triggered = false;
	private Collider other; 

	private Vector3 defaultPosition;
	private Vector3 pressedPosition;

	private float openDoorHeight;
	private Vector3 doorPosition;

	public float doorSpeed = 0.1f;

	void Start()
	{
		foreach (Transform childTransform in _links.transform) {
			GameObject child = childTransform.gameObject;
			child.GetComponent<Renderer> ().material = untriggerMat;
		}

		defaultPosition = transform.position;
		pressedPosition = new Vector3(defaultPosition.x, defaultPosition.y-(GetComponent<Renderer>().bounds.size.y/2),defaultPosition.z);

		doorPosition = _shedDoor.transform.position;
		openDoorHeight = doorPosition.y - _shedDoor.GetComponent<Renderer> ().bounds.size.y;

		if(recedingGlass != null)
		triggeredGlassPos = recedingGlass.transform.position + new Vector3(-25.25f, 0f, 0f);
	}

	void FixedUpdate()
	{
		if (triggered) {
			_shedDoor.transform.position = new Vector3(doorPosition.x, _shedDoor.transform.position.y-doorSpeed, doorPosition.z);
			if (_shedDoor.transform.position.y <= openDoorHeight) {
				_shedDoor.transform.position = new Vector3(doorPosition.x, openDoorHeight, doorPosition.z);
			}

			if(recedingGlass != null)
			if (recedingGlass.transform.position.x >= triggeredGlassPos.x) {
				recedingGlass.transform.position -= new Vector3 (glassRecedeRate, 0f, 0f);
			} else {
				recedingGlass.transform.position = triggeredGlassPos;
			}
		}

	}


	void OnTriggerEnter (Collider other)
	{
		this.other = other;
		this.triggered = true;

		foreach (Transform childTransform in _links.transform) {
			GameObject child = childTransform.gameObject;
			child.GetComponent<Renderer> ().material = triggerMat;
		}
	}
}
