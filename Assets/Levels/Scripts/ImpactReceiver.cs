using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class ImpactReceiver : MonoBehaviour {

	/*public float mass = 1.0F; // defines the character mass
	Vector3 impact = Vector3.zero;
	private CharacterController character;
	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController>();
	}
         
	// Update is called once per frame
	void Update () {
		Debug.Log ("time "+Time.time);
		Debug.Log ("deltaTime "+Time.deltaTime);
		// apply the impact force:
		if (impact.magnitude > 0.2F) character.Move(impact * Time.deltaTime);
		// consumes the impact energy each cycle:
		impact = Vector3.Lerp(impact, Vector3.zero, 10*Time.deltaTime);
	}
	
	// call this function to add an impact force:
	public void AddImpact(Vector3 dir, float force){
		dir.Normalize();
		if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
		impact = dir.normalized * force / mass;
	}*/

	public float mass = 1.0F; // defines the character mass
	Vector3 impact = Vector3.zero;
	Vector3 initialImpact = Vector3.zero;
	private CharacterController character;
	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		// apply the impact force:

		// consumes the impact energy each cycle:
			/*if (impact.magnitude > 0.4F)
				character.Move (impact * Time.deltaTime);
			impact = Vector3.Lerp (impact, Vector3.zero, .085f);*/

		if (impact.y > 1f) {
			character.Move (impact * Time.deltaTime);
			impact = Vector3.Lerp (impact, Vector3.zero, .05f);
		} else {
			impact = Vector3.zero;
		}
		/*if (frame > frameDelay && frame <= framesPerJump + frameDelay) {
			//if (impact.magnitude > 0.2F)
			//impact -= initialImpact / framesPerJump;
			impact = Vector3.Lerp(initialImpact, Vector3.zero, 1-Mathf.Pow(2,frame));
			character.Move (impact * Time.deltaTime);
		} else if (frame >= framesPerJump + frameDelay) {
			impact = Vector3.zero;
		}
		frame++;*/


	}

	// call this function to add an impact force:
	public void AddImpact(Vector3 dir, float force){

		dir.Normalize ();
		if (dir.y < 0)
			dir.y = -dir.y; // reflect down force on the ground
		impact = dir.normalized * force / mass;
		GetComponent<FirstPersonController>().resetVertical();
	}
}
