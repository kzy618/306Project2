using UnityEngine;
using System.Collections;

public class LaserReceiverController : MonoBehaviour {

	public GameObject _door;
	public GameObject _links;
    public float _speed;

	public Material untriggerMat;
	public Material triggerMat;

    private float _doorOpenPosition;
    private float _doorClosePosition;
    private bool _isClosing;

	// sound to play when door opens
	public AudioSource _doorSound;

    private void Start()
    {
        _isClosing = true;

        _doorClosePosition = _door.transform.localPosition.y;
		_doorOpenPosition = _doorClosePosition + (_door.GetComponent<Renderer>().bounds.size.y);
    }

    private void Update()
    {
        float delta = Time.deltaTime;
        Vector3 doorPos = _door.transform.localPosition;

        // move door down
        if (_isClosing)
        {
			Debug.log ("door close");
			stopOpenDoorSound ();
            float newY = _door.transform.localPosition.y - (_speed * delta);

            // ensures that door doesn't go below a certain position
            if (newY < _doorClosePosition)
            {
                newY = _doorClosePosition;
            }

            _door.transform.localPosition = new Vector3(doorPos.x, newY, doorPos.z);

			if(_links != null)
			foreach (Transform childTransform in _links.transform) {
				GameObject child = childTransform.gameObject;
				child.GetComponent<Renderer> ().material = untriggerMat;
			}
        }

        // move door up
        else
        {
			Debug.log ("door open");
			openDoorSound();
            float newY = _door.transform.localPosition.y + (_speed * delta);

            // ensures that door doesn't go above a certain position
            if (newY > _doorOpenPosition)
            {
                newY = _doorOpenPosition;
            }

            _door.transform.localPosition = new Vector3(doorPos.x, newY, doorPos.z);
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
