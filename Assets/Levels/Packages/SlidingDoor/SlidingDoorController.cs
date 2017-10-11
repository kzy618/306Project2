using UnityEngine;
using System.Collections;

public class SlidingDoorController : MonoBehaviour {

    public GameObject leftDoor;
    public GameObject rightDoor;
    public DoorButtonController doorButtonController;
    public float speed;

    private float leftDoorOpenPosition;
    private float rightDoorOpenPosition;
    private float leftDoorClosePosition;
    private float rightDoorClosePosition;



    // Use this for initialization
    void Start () {
        leftDoorClosePosition = leftDoor.transform.localPosition.x;
        rightDoorClosePosition = rightDoor.transform.localPosition.x;

        leftDoorOpenPosition = leftDoorClosePosition - 5.1f;
        rightDoorOpenPosition = rightDoorClosePosition + 5.1f;
        
	}
	
	// Update is called once per frame
	void Update () {
        float delta = Time.deltaTime;
        Vector3 leftDoorPos = leftDoor.transform.localPosition;
        Vector3 rightDoorPos = rightDoor.transform.localPosition;

        if (doorButtonController.IsPressed)
        {
            float newLeftX = leftDoor.transform.localPosition.x - (speed * delta);
            float newRightX = rightDoor.transform.localPosition.x + (speed * delta);

            if (newLeftX < leftDoorOpenPosition)
            {
                newLeftX = leftDoorOpenPosition;
                newRightX = rightDoorOpenPosition;
            }

            leftDoor.transform.localPosition = new Vector3(newLeftX, leftDoorPos.y, leftDoorPos.z);
            rightDoor.transform.localPosition = new Vector3(newRightX, rightDoorPos.y, rightDoorPos.z);
        }

        else
        {
            float newLeftX = leftDoor.transform.localPosition.x + (speed * delta);
            float newRightX = rightDoor.transform.localPosition.x - (speed * delta);

            if (newLeftX > leftDoorClosePosition)
            {
                newLeftX = leftDoorClosePosition;
                newRightX = rightDoorClosePosition;
            }

            leftDoor.transform.localPosition = new Vector3(newLeftX, leftDoorPos.y, leftDoorPos.z);
            rightDoor.transform.localPosition = new Vector3(newRightX, rightDoorPos.y, rightDoorPos.z);
        }

	}

}
