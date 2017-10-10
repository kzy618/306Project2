using UnityEngine;
using System.Collections;

public class ImpactReceiver : MonoBehaviour {

	public float mass = 1.0F; // defines the character mass
	Vector3 impact = Vector3.zero;
	private CharacterController character;
	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController>();
	}
         
	// Update is called once per frame
	void Update () {
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
	}
	/*
	public float mass = 1.0F; // defines the character mass
	Vector3 impact = Vector3.zero;
	Vector3 initialImpact = Vector3.zero;
	private CharacterController character;
	private int framesPerJump = 10;
	private int frameDelay = 2;
	private int frame = 0;
	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		frame++;
		// apply the impact force:

		// consumes the impact energy each cycle:
		//impact = Vector3.Lerp(impact, Vector3.zero, 50*Time.deltaTime);
		if (frame >= frameDelay && frame <= framesPerJump + frameDelay) {
			if (impact.magnitude > 0.2F)
				character.Move (impact * Time.deltaTime);
			//impact -= initialImpact / framesPerJump;
			impact = Vector3.Lerp(impact, Vector3.zero, 1.0/framesPerJump);
		} else if (frame >= framesPerJump + frameDelay) {
			impact = Vector3.zero;
		}
		frame++;


	}

	// call this function to add an impact force:
	public void AddImpact(Vector3 dir, float force){

		dir.Normalize ();
		if (dir.y < 0)
			dir.y = -dir.y; // reflect down force on the ground
		impact = dir.normalized * force / mass;
		initialImpact = impact;
		frame = 0;
	}*/
}
