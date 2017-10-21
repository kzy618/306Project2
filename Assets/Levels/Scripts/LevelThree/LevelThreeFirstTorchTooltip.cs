using UnityEngine;
using System.Collections;

public class LevelThreeFirstTorchTooltip : MonoBehaviour
{

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
				LevelThreeController.GetComponent<LevelThreeController>().ProgressRoute(RouteNumber);
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
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2, Screen.width, Screen.height / 2),
				"Maybe I should light it up with my torch. (Mouse LB)");
		}
		if (showTooltip && tooltipfinished)
		{
			GUI.color = Color.red;
			GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height / 2, Screen.width, Screen.height / 2),
				"I need to find another torch somewhere around. But I have to check the tower first. It's so weird.");
		}
	}
}
