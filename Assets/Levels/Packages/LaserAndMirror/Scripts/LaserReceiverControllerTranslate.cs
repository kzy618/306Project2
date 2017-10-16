using UnityEngine;
using System.Collections;

public class LaserReceiverControllerTranslate : MonoBehaviour {

	public GameObject _door;
	public GameObject positionObj;
	public GameObject _links;
    public float doorSpeed;

	public Material untriggerMat;
	public Material triggerMat;

    private float _doorOpenPosition;
    private float _doorClosePosition;
    private bool _isClosing;


	private Vector3 doorPosition;
	private Vector3 doorTriggered;
	private Vector3 direction;

    private void Start()
    {
        _isClosing = true;

		doorPosition = _door.transform.position;
		doorTriggered = positionObj.transform.position;
		direction = (doorTriggered - doorPosition).normalized;
        //_doorClosePosition = _door.transform.localPosition.y;
		//_doorOpenPosition = _doorClosePosition + (_door.GetComponent<Renderer>().bounds.size.y);
    }

    private void Update()
    {
        float delta = Time.deltaTime;
        Vector3 doorPos = _door.transform.localPosition;

        // move door down
        if (_isClosing)
        {
			if ((_door.transform.position - doorPosition).magnitude > (direction * doorSpeed).magnitude) {
				_door.transform.position -= direction * doorSpeed;
			} else {
				_door.transform.position = doorPosition;
			}

			if(_links != null)
			foreach (Transform childTransform in _links.transform) {
				GameObject child = childTransform.gameObject;
				child.GetComponent<Renderer> ().material = untriggerMat;
			}
        }

        // move door up
        else
        {
			if ((_door.transform.position - doorTriggered).magnitude > (direction * doorSpeed).magnitude) {
				_door.transform.position += direction * doorSpeed;
			} else {
				_door.transform.position = doorTriggered;
			}


            _isClosing = true; // set to true in case the laser is no longer being received


			if(_links != null)
			foreach (Transform childTransform in _links.transform) {
				GameObject child = childTransform.gameObject;
				child.GetComponent<Renderer> ().material = triggerMat;
			}
        }
    }

    public void activate()
    {
        _isClosing = false;
    }

}
