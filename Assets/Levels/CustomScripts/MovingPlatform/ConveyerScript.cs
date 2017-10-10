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
	private List<GameObject> heldObjects;

	// Use this for initialization
	void Start () {
		conveyerUnits = new List<GameObject> ();
		heldObjects = new List<GameObject> ();
		direction = (end.transform.position - start.transform.position).normalized;

		GameObject startPlatform = Instantiate (Resources.Load ("ConveyerPlatform")) as GameObject;
		/*startPlatform.transform.position = start.transform.position;
		startPlatform.transform.rotation = start.transform.rotation;*/
		Rigidbody rb = startPlatform.GetComponent<Rigidbody> ();
		//rb.MovePosition (start.transform.position+transform.position);
		rb.transform.position = startPlatform.transform.position+start.transform.position;
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

		/*Vector3 currPos = transform.position;
		//delta = new Vector3(currPos.x-prevPos.x, currPos.y-prevPos.y, currPos.z-prevPos.z);

		foreach(GameObject obj in heldObjects){
			if (obj != null) {
				//Vector3 objPos = obj.transform.position;
				Vector3 nextPos = obj.transform.position + (direction * conveyerSpeed);//new Vector3 (delta.x + objPos.x, delta.y + objPos.y, delta.z + objPos.z);

				obj.transform.position = nextPos;
			}
		}*/
	}

	public void newUnit(){
		GameObject startPlatform = Instantiate (Resources.Load ("ConveyerPlatform")) as GameObject;
		/*startPlatform.transform.position = start.transform.position;
		startPlatform.transform.rotation = start.transform.rotation;*/
		Rigidbody rb = startPlatform.GetComponent<Rigidbody> ();
		//rb.MovePosition (start.transform.position+transform.position);
		rb.transform.position = startPlatform.transform.position+start.transform.position;
		rb.MoveRotation (start.transform.rotation);
		startPlatform.tag = "conveyerBeltUnit";
		conveyerUnits.Add (startPlatform);
	}

	public void removeUnit(GameObject cUnit){
		conveyerUnits.Remove (cUnit);
		Destroy (cUnit);
	}

	public void addHeldObj(GameObject obj){
		heldObjects.Add (obj);
	}

	public void removeHeldObj(GameObject obj){

		heldObjects.Remove (obj);
	}
}
