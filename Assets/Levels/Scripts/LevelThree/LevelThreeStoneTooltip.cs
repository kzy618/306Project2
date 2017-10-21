using UnityEngine;
using System.Collections;

public class LevelThreeStoneTooltip : MonoBehaviour {

	private Camera fpsCam;

	private bool stoneTooltip;
	
	// Use this for initialization
	void Start () {
		fpsCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
		RaycastHit hit;
		if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, 20f))
		{
			if (hit.collider.gameObject.CompareTag("LevelThreeRedStone"))
			{
				stoneTooltip = true;
			}
			else
			{
				stoneTooltip = false;
			}
		}
		else
		{
			stoneTooltip = false;
		}
	}
	
	void OnGUI()
	{
		if (stoneTooltip)
		{
			GUI.color = Color.red;
			GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2, Screen.width, Screen.height / 2),
				"A magic stone over there. Maybe it can interact with my ice cube.");
		}
	}
}
