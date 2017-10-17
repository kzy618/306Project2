using UnityEngine;
using System.Collections;
using System;

public class CafeTrampolineRotation : MonoBehaviour {

    public GameObject trampoline1; // second level most left trampoline 
    public GameObject trampoline2; // second level most right trampoline 
    public GameObject trampoline3; // third level most left trampoline 
    public GameObject trampoline4; // third level most right trampoline 

    private Quaternion defaultRotation1;
    private Quaternion defaultRotation2;
    private Quaternion defaultRotation3;
    private Quaternion defaultRotation4;

    private Boolean triggered = false;
    private Collider other;

    private Vector3 defaultButtonPosition;
    private Vector3 pressedButtonPosition;

    void Start()
    {
        defaultButtonPosition = transform.position;
        pressedButtonPosition = transform.position - (transform.up * GetComponent<Renderer>().bounds.size.y / 2);

        defaultRotation1 = trampoline1.transform.rotation;
        defaultRotation2 = trampoline2.transform.rotation;
        defaultRotation3 = trampoline3.transform.rotation;
        defaultRotation4 = trampoline4.transform.rotation;
    }

    void FixedUpdate()
    {
        if (triggered && !other)
        {
            transform.position = defaultButtonPosition;
            triggered = false;
        }
        if (!triggered)
        {
            this.moveToDefaultTrampolinePosition();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickable"))
        {
            transform.position = pressedButtonPosition;
            this.other = other;
            this.triggered = true;
            moveToNewTrampolinePosition();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pickable"))
        {
            transform.position = defaultButtonPosition;
            triggered = false;
        }
    }

    void moveToDefaultTrampolinePosition()
    {
        trampoline1.transform.rotation = defaultRotation1;
        trampoline2.transform.rotation = defaultRotation2;
        trampoline3.transform.rotation = defaultRotation3;
        trampoline4.transform.rotation = defaultRotation4;
    }
    void moveToNewTrampolinePosition()
    {
        trampoline1.transform.Rotate(0, 90, 0, Space.World);
        trampoline2.transform.Rotate(0, -90, 0, Space.World);
        trampoline3.transform.Rotate(0, 180, 0, Space.World);
        trampoline4.transform.Rotate(0, 180, 0, Space.World);
    }
}
