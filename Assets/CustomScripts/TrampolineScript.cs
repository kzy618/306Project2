using UnityEngine;
using System.Collections;

public class TrampolineScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		Debug.Log ("TAMPOLINE on "+col.gameObject.tag);
		Rigidbody rb = col.gameObject.GetComponent<Rigidbody> ();
		if (col.gameObject.CompareTag ("Player")) {
			CharacterController cc = col.gameObject.GetComponent<CharacterController> ();
			cc.SimpleMove(new Vector3 (0f, 5000f, 0f));
		}else if (rb != null) {
			Debug.Log ("Jump");
			rb.velocity = new Vector3 (0f, 30f, 10f);

			if(col.gameObject.CompareTag("Player"))
			Debug.Log(rb.velocity.ToString ("F3"));
		} else {
			if(col.gameObject.CompareTag("Player")){
				Debug.Log ("RB is null");
			}
		}
	}

	void OnTriggerExit(Collider col){
		Debug.Log ("TAMPOLINE off "+col.gameObject.tag);
		Rigidbody rb = col.gameObject.GetComponent<Rigidbody> ();
		if (rb != null) {
			Debug.Log ("EXIT - "+rb.velocity.ToString ("F3"));
		}
	}
}
