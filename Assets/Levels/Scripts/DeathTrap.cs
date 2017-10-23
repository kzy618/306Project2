using UnityEngine;
using System.Collections;

public class DeathTrap : MonoBehaviour {

	public GameObject posObj;
	public float movementSpeed = 0.1f;

	private Vector3 direction;
	private bool activated = false;
	// Use this for initialization
	void Start () {
		direction = (posObj.transform.position - transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			if ((transform.position - posObj.transform.position).magnitude > movementSpeed) {
				transform.position += direction * movementSpeed;
			} else {
				activated = false;
			}
		}
	}

	public void activate(){
		activated = true;
	}
}
