using UnityEngine;
using System.Collections;

/// <summary>
/// Shows tooltips at the beginning of level three
/// </summary>
public class OpenningTooltip : MonoBehaviour
{

	public float TooltipDuration;

	private float deletionTime;
	private bool showTooltip;

	// Use this for initialization
	void Start ()
	{
		deletionTime = Time.time + TooltipDuration;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time <= deletionTime)
		{
			Debug.Log(Time.time);
			showTooltip = true;
		}
		else
		{
			showTooltip = false;
		}
	}

	private void OnGUI()
	{
		if (showTooltip && Time.timeScale != 0)
		{
			GUI.color = Color.red;
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2, Screen.width, Screen.height / 2),
				"This forest is somehow enchanted...");
			GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 20, Screen.width, Screen.height / 2),
				"I can feel the sources of magic surrounding this campsite.");
			GUI.Label(new Rect(Screen.width / 2 - 170, Screen.height / 2 + 40, Screen.width, Screen.height / 2),
				"I need to go find those sources to figure out what's going on here.");
		}
	}
}
