using UnityEngine;
using System.Collections;

public class DroppingWallScript : MonoBehaviour {
	public float timerSec = 180f;
	public GameObject front;
	public GameObject back;
	public GameObject left;
	public GameObject right;
	public GameObject roof;
	public GameObject red;
	public GameObject deathTimer;
	public GameObject sfx;
	public GameObject preBgm;
	// Use this for initialization

	public float speed;
	private float antiScale;
	private float generic;
	private bool activated = false;

	void Start () {
		preBgm.GetComponent<AudioSource> ().Play ();
		red.SetActive (false);
		antiScale = 1f;
		speed = .05f;
		generic = 90f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!activated) {
			
		}else if(timerSec > 0f){

			timerSec -= Time.time;
			if (timerSec <= 0f) {
				preBgm.GetComponent<AudioSource> ().Stop ();
				sfx.GetComponent<AudioSource> ().Play ();
			}
		} else if (generic >= 0) {
			front.transform.Rotate (new Vector3 (-speed, 0f, 0f));
			back.transform.Rotate (new Vector3 (speed, 0f, 0f));
			left.transform.Rotate (new Vector3 (0f, 0f, speed));
			right.transform.Rotate (new Vector3 (0f, 0f, -speed));
			roof.transform.localScale = roof.transform.localScale/(antiScale);
			speed *= 1.05f;
			antiScale *= 1.001f;
			generic -= speed;
		} else {
			Destroy (front);
			Destroy (back);
			Destroy (left);
			Destroy (right);
			Destroy (roof);
			red.SetActive (true);
			deathTimer.GetComponent<DeathTimer> ().timerActivate();
		}
	}

	void OnTriggerEnter(Collider col){
		activated = true;
	}
}
