using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class TrampolineScript : MonoBehaviour
{

	private Camera mainCamera;


	public float bouncingForce;

	// Use this for initialization
	void Start ()
	{
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Player")) {
			GameObject player = col.gameObject;
			//Vector3 up = mainCamera.transform.up;
			//Vector3 forward = mainCamera.transform.forward;
			//projectile equation might be wrong
			//Vector3 projectile = new Vector3 ((float)Math.Sqrt (up.x * up.x + forward.x * forward.x), (float)Math.Sqrt (up.y * up.y + forward.y * forward.y), (float)Math.Sqrt (up.z * up.z + forward.z * forward.z));
			//player.GetComponent<FirstPersonController>().resetVertical();
			player.GetComponent<ImpactReceiver> ().AddImpact (transform.up, bouncingForce);
			Debug.Log ("add force on player");
		} else {

			Rigidbody rb = col.gameObject.GetComponent<Rigidbody> ();
			if (rb != null) {
				rb.velocity += new Vector3 (0f, bouncingForce*100, 0f);
			}
		}
	}

	private void originalImplementation(Collider col)
	{
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
}
