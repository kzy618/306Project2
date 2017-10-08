using UnityEngine;
using System.Collections;

public class LaserReceiverController : MonoBehaviour {

    public GameObject door;
    public float speed;

    private float doorOpenPosition;
    private float doorClosePosition;
    private bool isClosing;

    private void Start()
    {
        isClosing = true;

        doorClosePosition = door.transform.localPosition.y;
        doorOpenPosition = doorClosePosition + 2.8f;
    }

    private void Update()
    {
        float delta = Time.deltaTime;
        Vector3 doorPos = door.transform.localPosition;

        if (isClosing)
        {
            float newY = door.transform.localPosition.y - (speed * delta);

            if (newY < doorClosePosition)
            {
                newY = doorClosePosition;
            }

            door.transform.localPosition = new Vector3(doorPos.x, newY, doorPos.z);
        }

        else
        {
            float newY = door.transform.localPosition.y + (speed * delta);

            if (newY > doorOpenPosition)
            {
                newY = doorOpenPosition;
            }

            door.transform.localPosition = new Vector3(doorPos.x, newY, doorPos.z);
            isClosing = true;
        }
    }

    public void activate()
    {
        isClosing = false;
        //print("Receiving Laser!!");
    }

}
