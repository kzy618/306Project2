using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the First Cannon in Route One, Level Three
/// </summary>
public class LevelThreeR1CompletedTooltip : MonoBehaviour {


	public int RouteNumber;

	private bool showTooltip;
	private bool tooltipfinished;
	private GameObject LevelThreeController;
	
	// Use this for initialization
	void Start () {
		LevelThreeController = GameObject.FindWithTag("LevelThreeController");
	}
	
	// Update is called once per frame
	void Update () {
		if (showTooltip)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0) && !tooltipfinished)
			{
				LevelThreeController.GetComponent<LevelThreeController>().CompleteRoute(RouteNumber);
				tooltipfinished = true;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("picked"))
		{
			showTooltip = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("picked"))
		{
			showTooltip = false;
		}
	}

	private void OnGUI()
	{
		if (showTooltip && !tooltipfinished)
		{
			GUI.color = Color.red;
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, Screen.width, Screen.height / 2),
				"Looks like this ancient cannon is still working... (Mouse LB)");
		}
		if (showTooltip && tooltipfinished)
		{
			GUI.color = Color.red;
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, Screen.width, Screen.height / 2),
				"What... There are other towers in this forest.");
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 20, Screen.width, Screen.height / 2),
				"I'd better find another torch somewhere along the path");
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 40, Screen.width, Screen.height / 2),
				"before returning the campsite.");
		}
	}
}
