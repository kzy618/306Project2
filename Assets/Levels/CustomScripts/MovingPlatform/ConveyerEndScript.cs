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
		if(col.gameObject.CompareTag ("conveyerBeltUnit")){
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.CompareTag ("conveyerBeltUnit")){
			manager.GetComponent<ConveyerScript>().removeUnit(col.gameObject);
		}
	}
}
