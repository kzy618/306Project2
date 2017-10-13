using UnityEngine;
using System.Collections;

public class ShedFloor : MonoBehaviour {

	public GameObject _btn;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player") || other.CompareTag ("pickable")) {
			Debug.Log ("ENTER FLOOR");
			_btn.GetComponent<DoorButton> ().enabled = false;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Player") || other.CompareTag ("pickable")) {
			Debug.Log ("EXIT FLOOR");
			_btn.GetComponent<DoorButton> ().enabled = true;
		}
	}
}
