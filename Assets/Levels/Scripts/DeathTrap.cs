using UnityEngine;
using System.Collections;

public class DeathTrap : MonoBehaviour {

	public float targetHeight = 1f;
	public float movementSpeed = 0.1f;
	private bool activated = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			if (transform.position.y > targetHeight) {

			}
		}
	}

	public void activate(){
		activated = true;
	}
}
