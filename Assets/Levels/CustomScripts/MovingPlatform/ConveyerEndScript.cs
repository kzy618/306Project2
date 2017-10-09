using UnityEngine;
using System.Collections;

public class ConveyerEndScript : MonoBehaviour {

	public GameObject manager;

	private Vector3 direction;
	private GameObject currentConveyerUnit; //conveyer unit that is currently on this gameobject

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Player")) {
			Debug.Log ("Player Enter End!");
		}
			
		if(col.gameObject.CompareTag ("conveyerBeltUnit")){
			Debug.Log ("Conveyer Enter End!");
			//currentConveyerUnit = col.gameObject;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.CompareTag ("Player")) {
			Debug.Log ("Player Exit End!");
		}
		if(col.gameObject.CompareTag ("conveyerBeltUnit")){
			Debug.Log ("Conveyer Exit End!");
			//currentConveyerUnit = null;
			manager.GetComponent<ConveyerScript>().removeUnit(col.gameObject);
		}
	}
}
