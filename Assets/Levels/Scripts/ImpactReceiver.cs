using UnityEngine;
using System.Collections;

public class ImpactReceiver : MonoBehaviour {

	public float mass = 3.0F; // defines the character mass
	Vector3 impact = Vector3.zero;
	private CharacterController character;
	private int framesPerImpact = 120;
	private int frame = 0;
	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController>();
	}
         
	// Update is called once per frame
	void Update () {
		frame++;
		// apply the impact force:
		if (impact.magnitude > 0.2F) character.Move(impact * Time.deltaTime);
		// consumes the impact energy each cycle:
		impact = Vector3.Lerp(impact, Vector3.zero, 5*Time.deltaTime);
	}
	
	// call this function to add an impact force:
	public void AddImpact(Vector3 dir, float force){
		if (frame >= framesPerImpact) {
			dir.Normalize ();
			if (dir.y < 0)
				dir.y = -dir.y; // reflect down force on the ground
			impact += dir.normalized * force / mass;
			frame = 0;
		}
	}
}
