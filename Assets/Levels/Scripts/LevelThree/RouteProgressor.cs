using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the interactions around this object (the special torch).
/// Informs LevelThreeController if this object is interacted in a particular way.
/// </summary>
public class RouteProgressor : MonoBehaviour {

	public int RouteNumber;

	private bool hasTorch;
	private bool interacting;
	private bool finished;
	private GameObject LevelThreeController;
	
	// Use this for initialization
	void Start () {
		LevelThreeController = GameObject.FindWithTag("LevelThreeController");
	}
	
	// Update is called once per frame
	void Update ()
	{
		hasTorch = LevelThreeController.GetComponent<LevelThreeController>().TorchInHand.activeInHierarchy;
		if (interacting && hasTorch)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0) && !finished)
			{
				LevelThreeController.GetComponent<LevelThreeController>().ProgressRoute(RouteNumber);
				finished = true;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("picked"))
		{
			interacting = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("picked"))
		{
			interacting = false;
		}
	}
	
	private void OnGUI()
	{
		if (interacting && finished)
		{
			GUI.color = Color.red;
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, Screen.width, Screen.height / 2),
				"This magic torch has been activated.");
			GUI.Label(new Rect(Screen.width / 2 - 120, Screen.height / 2 + 20, Screen.width, Screen.height / 2),
				"... Looks like something up there on the tower.");
		}
		else if (interacting && hasTorch)
		{
			GUI.color = Color.red;
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, Screen.width, Screen.height / 2),
				"Maybe I can light it up with my torch... (Mouse LB)");
		}
		else if (interacting && !hasTorch)
		{
			GUI.color = Color.red;
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, Screen.width, Screen.height / 2),
				"I can't light it up without a torch...");
		}
	}

}
