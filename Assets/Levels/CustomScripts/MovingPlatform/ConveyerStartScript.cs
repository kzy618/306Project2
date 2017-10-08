using UnityEngine;
using System.Collections;

public class ConveyerStartScript : MonoBehaviour {

	public GameObject end;
	public float conveyerSpeed = 1f;

	private Vector3 direction;
	private GameObject currentConveyerUnit; //conveyer unit that is currently on this gameobject

	// Use this for initialization
	void Start () {
		direction = (end.transform.position - transform.position).normalized;
		GameObject startPlatform = Instantiate (Resources.Load ("ConveyerPlatform")) as GameObject;
		startPlatform.transform.position = transform.position;
		startPlatform.transform.rotation = transform.rotation;
		Rigidbody startRb = startPlatform.GetComponent<Rigidbody> ();
		startRb.velocity = direction * conveyerSpeed;
		Debug.Log ("hi");
		BoxCollider startBc  = startPlatform.GetComponent<BoxCollider> ();

		currentConveyerUnit = startPlatform;

	}

	// Update is called once per frame
	void FixedUpdate () {

	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("conveyerBeltUnit")){

			Debug.Log ("Conveyer Enter!");
			currentConveyerUnit = col.gameObject;
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.CompareTag("conveyerBeltUnit")){
			Debug.Log ("Conveyer Exit!");
			currentConveyerUnit = null;


			GameObject startPlatform = Instantiate (Resources.Load ("ConveyerPlatform")) as GameObject;
			startPlatform.transform.position = transform.position;
			startPlatform.transform.rotation = transform.rotation;
			Rigidbody startRb = startPlatform.GetComponent<Rigidbody> ();
			startRb.velocity = direction * conveyerSpeed;
			Debug.Log (startRb.velocity);
		}
	}
}
