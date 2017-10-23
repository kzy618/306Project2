using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
/// ImpactReceiver simulate forces on the CharacterController.
/// It uses lerp to simulate a smoothy effect of translation.
/// </summary>
public class ImpactReceiver : MonoBehaviour {

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
		if (impact.y > 1f) {
			character.Move (impact * Time.deltaTime);
			impact = Vector3.Lerp (impact, Vector3.zero, .05f);
		} else {
			impact = Vector3.zero;
		}

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
