using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters;

/// <summary>
/// Tooltips for interactable stones.
/// </summary>
public class LevelThreeStoneTooltip : MonoBehaviour {

	private Camera fpsCam;

	private bool stoneTooltipR1;
	private bool stoneTooltipGeneral;
	
	// Use this for initialization
	void Start () {
		fpsCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
		RaycastHit hit;
		if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, 20f))
		{
			if (hit.collider.gameObject.CompareTag("LevelThreeRedStone"))
			{
				stoneTooltipR1 = true;
			}
			else if (hit.collider.gameObject.CompareTag("RouteStarter"))
			{
				stoneTooltipGeneral = true;
			}
			else
			{
				stoneTooltipR1 = false;
				stoneTooltipGeneral = false;
			}
			
		}
		else
		{
			stoneTooltipR1 = false;
			stoneTooltipGeneral = false;
		}
	}
	
	void OnGUI()
	{
		if (stoneTooltipR1)
		{
			GUI.color = Color.black;
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2, Screen.width, Screen.height / 2),
				"A magic stone over there...");
			GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 20, Screen.width, Screen.height / 2),
				"That should be one of the sources of magic.");
			GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 40, Screen.width, Screen.height / 2),
				"Maybe it can interact with my ice cube.");
		}else if (stoneTooltipGeneral)
		{
			GUI.color = Color.black;
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2, Screen.width, Screen.height / 2),
				"A magic stone over there...");
			GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 20, Screen.width, Screen.height / 2),
				"That should be one of the sources of magic.");
			GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 40, Screen.width, Screen.height / 2),
				"Maybe it can interact with my ice cube.");
			GUI.Label(new Rect(Screen.width / 2 - 120, Screen.height / 2 + 60, Screen.width, Screen.height / 2),
				"Emmmm... this one seems to require some other sources to be activated first.");
		}
	}
}
