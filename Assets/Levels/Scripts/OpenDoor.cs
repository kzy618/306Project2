using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

    public GameObject _door;
	
	void Start () {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        _door.SetActive(false);
    }
}
