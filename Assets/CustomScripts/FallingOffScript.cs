using UnityEngine;
using System.Collections;

public class FallingOffScript : MonoBehaviour {
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.constraints = RigidbodyConstraints.FreezePosition;

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider col){
		rb.constraints = RigidbodyConstraints.None;
	}
}
