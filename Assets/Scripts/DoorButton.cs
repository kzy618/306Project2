using UnityEngine;
using System.Collections;
using System;

public class DoorButton : MonoBehaviour
{

    public GameObject _shedDoor;

    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Button triggered: on");
        transform.Translate(0, -(GetComponent<Renderer>().bounds.size.y), 0);
        _shedDoor.gameObject.SetActive(false);
    }

    void OnTriggerExit (Collider other)
    {
        Debug.Log("Button triggered: off");
        transform.Translate(0, GetComponent<Renderer>().bounds.size.y, 0);
        _shedDoor.gameObject.SetActive(true);
    }
}
