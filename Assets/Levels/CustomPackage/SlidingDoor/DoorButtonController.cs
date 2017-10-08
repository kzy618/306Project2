using UnityEngine;
using System.Collections;

public class DoorButtonController : MonoBehaviour {

    private Vector3 originalPosition;
    private Vector3 pushedDownPosition;
    private Animator animator;

    private bool isPressed;

    // Use this for initialization
    void Start()
    {
        originalPosition = transform.localPosition;
        pushedDownPosition = new Vector3(originalPosition.x, originalPosition.y - 0.25f, originalPosition.z);
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.CompareTag("Player"))
        {
            transform.localPosition = pushedDownPosition;
            isPressed = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
		if (other.gameObject.CompareTag("Player"))
        {
            transform.localPosition = originalPosition;
            isPressed = false;
        }
    }

    public bool IsPressed
    {
        get { return isPressed; }
    }
}
