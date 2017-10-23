using UnityEngine;
using System.Collections;


/**
 * 	OpenDoor is a simple class
 * 	that imitates the opening of a door by setting the door gameobject as inactive
 * 
 * 
 * */
public class OpenDoor : MonoBehaviour {

    public GameObject _door;
	
	void Start () {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        _door.SetActive(false);
    }
}
