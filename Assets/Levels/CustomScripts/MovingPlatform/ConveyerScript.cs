using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConveyerScript : MonoBehaviour {
	
	public GameObject start;
	public GameObject end;
	public float conveyerSpeed = 0.05f;

	private Vector3 direction;
	private GameObject currentConveyerUnit; //conveyer unit that is currently on this gameobject
	private List<GameObject> conveyerUnits;

	// Use this for initialization
	void Start () {
		conveyerUnits = new List<GameObject> ();
		direction = (end.transform.position - start.transform.position).normalized;

		GameObject startPlatform = Instantiate (Resources.Load ("ConveyerPlatform")) as GameObject;
		/*startPlatform.transform.position = start.transform.position;
		startPlatform.transform.rotation = start.transform.rotation;*/
		Rigidbody rb = startPlatform.GetComponent<Rigidbody> ();
		//rb.MovePosition (start.transform.position+transform.position);
		rb.transform.position = startPlatform.transform.position+transform.position;
		rb.MoveRotation (start.transform.rotation);
		startPlatform.tag = "conveyerBeltUnit";
		conveyerUnits.Add (startPlatform);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach (GameObject unit in conveyerUnits) {
			//unit.transform.position = unit.transform.position + (direction * conveyerSpeed);
			Rigidbody rb = unit.GetComponent<Rigidbody> ();
			rb.MovePosition(rb.transform.position + (direction * conveyerSpeed));
			rb.MoveRotation (start.transform.rotation);
		}
	}

	public void newUnit(){
		GameObject startPlatform = Instantiate (Resources.Load ("ConveyerPlatform")) as GameObject;
		/*startPlatform.transform.position = start.transform.position;
		startPlatform.transform.rotation = start.transform.rotation;*/
		Rigidbody rb = startPlatform.GetComponent<Rigidbody> ();
		//rb.MovePosition (start.transform.position+transform.position);
		rb.transform.position = startPlatform.transform.position+transform.position;
		rb.MoveRotation (start.transform.rotation);
		startPlatform.tag = "conveyerBeltUnit";
		conveyerUnits.Add (startPlatform);
	}

	public void removeUnit(GameObject cUnit){
		conveyerUnits.Remove (cUnit);
		Destroy (cUnit);
	}
}
