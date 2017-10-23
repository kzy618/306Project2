using UnityEngine;
using System.Collections;


/**
 * TrapFloor is a simple class that sets active property of the specified GameObject _trapFloor as false
 * 
 * */
public class TrapFloor : MonoBehaviour {

    public GameObject _trapFloor;

    void OnTriggerEnter(Collider other)
    {
        _trapFloor.SetActive(false);
    }
}
