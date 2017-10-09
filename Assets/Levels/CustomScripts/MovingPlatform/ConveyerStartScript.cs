using UnityEngine;
using System.Collections;

public class ConveyerStartScript : MonoBehaviour {

	public GameObject manager;

	private GameObject currentConveyerUnit; //conveyer unit that is currently on this gameobject

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {

	}

	void OnTriggerEnter(Collider col){
		Debug.Log ("Anything Enter Start!");
		if(col.gameObject.CompareTag ("conveyerBeltUnit")){
			Debug.Log ("Conveyer Enter Start!");
			//currentConveyerUnit = col.gameObject;
		}
	}

	void OnTriggerExit(Collider col){
		Debug.Log ("Anything Exit Start!");
		if(col.gameObject.CompareTag ("conveyerBeltUnit")){
			Debug.Log ("Conveyer Exit Start!");
			//currentConveyerUnit = null;
			manager.GetComponent<ConveyerScript>().newUnit();
		}
	}
}
