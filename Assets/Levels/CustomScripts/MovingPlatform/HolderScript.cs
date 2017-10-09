using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HolderScript : MonoBehaviour {

	private List<GameObject> objects;
	private Vector3	prevPos;
	private Vector3 delta;

	void Start(){
		prevPos = transform.position;
		objects = new List<GameObject> ();
	}

	void OnTriggerEnter(Collider col){
		if(!col.gameObject.CompareTag("staticPosition")){
			objects.Add (col.transform.gameObject);
			//col.transform.parent = gameObject.transform;
		}
	}

	void OnTriggerExit(Collider col){
		if(!col.gameObject.CompareTag("staticPosition")){
			objects.Remove (col.transform.gameObject);
			//col.transform.parent = null;
		}
	}

	void FixedUpdate(){
		Vector3 currPos = transform.position;
		delta = new Vector3(currPos.x-prevPos.x, currPos.y-prevPos.y, currPos.z-prevPos.z);

		foreach(GameObject obj in objects){
			if (obj != null) {
				Vector3 objPos = obj.transform.position;
				Vector3 nextPos = new Vector3 (delta.x + objPos.x, delta.y + objPos.y, delta.z + objPos.z);

				obj.transform.position = nextPos;
			}
		}

		prevPos = currPos;
	}

}
