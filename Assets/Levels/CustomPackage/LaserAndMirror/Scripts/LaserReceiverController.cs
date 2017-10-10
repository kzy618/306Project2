using UnityEngine;
using System.Collections;

public class LaserReceiverController : MonoBehaviour {

    public GameObject _door;
    public float _speed;

    private float _doorOpenPosition;
    private float _doorClosePosition;
    private bool _isClosing;

    private void Start()
    {
        _isClosing = true;

        _doorClosePosition = _door.transform.localPosition.y;
        _doorOpenPosition = _doorClosePosition + 2.8f;
    }

    private void Update()
    {
        float delta = Time.deltaTime;
        Vector3 doorPos = _door.transform.localPosition;

        // move door down
        if (_isClosing)
        {
            float newY = _door.transform.localPosition.y - (_speed * delta);

            // ensures that door doesn't go below a certain position
            if (newY < _doorClosePosition)
            {
                newY = _doorClosePosition;
            }

            _door.transform.localPosition = new Vector3(doorPos.x, newY, doorPos.z);
        }

        // move door up
        else
        {
            float newY = _door.transform.localPosition.y + (_speed * delta);

            // ensures that door doesn't go above a certain position
            if (newY > _doorOpenPosition)
            {
                newY = _doorOpenPosition;
            }

            _door.transform.localPosition = new Vector3(doorPos.x, newY, doorPos.z);
            _isClosing = true; // set to true in case the laser is no longer being received
        }
    }

    public void activate()
    {
        _isClosing = false;
    }

}
