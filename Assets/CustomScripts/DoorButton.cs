using UnityEngine;
using System.Collections;
using System;

public class DoorButton : MonoBehaviour
{
    public GameObject _shedDoor;

    private Boolean triggered = false;
    private Collider other; 

    void Update()
    {
        if(triggered && !other)
        {
            Debug.Log("Button triggered: off");
            transform.Translate(0, GetComponent<Renderer>().bounds.size.y, 0);
            _shedDoor.gameObject.SetActive(true);
            triggered = false;
        }
    }
    

    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Button triggered: on");
        transform.Translate(0, -(GetComponent<Renderer>().bounds.size.y), 0);
        _shedDoor.gameObject.SetActive(false);
        this.other = other;
        this.triggered = true;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Button triggered: off");
        transform.Translate(0, GetComponent<Renderer>().bounds.size.y, 0);
        _shedDoor.gameObject.SetActive(true);
        triggered = false;
    }

}
