using UnityEngine;
using System.Collections;

public class ShedFloor : MonoBehaviour {

	public GameObject _btn;
    private Collider _other;

    void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player") || other.CompareTag ("pickable")) {
			Debug.Log ("ENTER FLOOR");
			_btn.GetComponent<DoorButton>().enabled = false;
            _other = other;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Player") || other.CompareTag ("pickable")) {
			Debug.Log ("EXIT FLOOR");
			_btn.GetComponent<DoorButton>().enabled = true;
		}
	}

    void FixedUpdate() {
        if (!_other)
        {
            _btn.GetComponent<DoorButton>().enabled = true;
        }
    }
}
