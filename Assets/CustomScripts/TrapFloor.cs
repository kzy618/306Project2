using UnityEngine;
using System.Collections;

public class TrapFloor : MonoBehaviour {

    public GameObject _trapFloor;

    void OnTriggerEnter(Collider other)
    {
        _trapFloor.SetActive(false);
    }
}
