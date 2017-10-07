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
		if (rb != null) {
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
}
