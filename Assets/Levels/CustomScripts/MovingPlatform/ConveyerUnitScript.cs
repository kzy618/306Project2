using UnityEngine;
using System.Collections;

public class ConveyerUnitScript : MonoBehaviour {

	public GameObject manager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(!col.gameObject.CompareTag("staticPosition") && !col.gameObject.CompareTag("picked")){
			
		}
	}

	void OnTriggerExit(Collider col){
		if(!col.gameObject.CompareTag("staticPosition") && !col.gameObject.CompareTag("picked")){
			
		}
	}
}
