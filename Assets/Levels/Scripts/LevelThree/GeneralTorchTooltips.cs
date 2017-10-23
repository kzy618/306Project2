using UnityEngine;
using System.Collections;

/// <summary>
/// Tooltips for non-interactable torches
/// </summary>
public class GeneralTorchTooltips : MonoBehaviour {


	private bool interacting;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("General Torch");
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
		if (interacting)
		{
			GUI.color = Color.red;
			GUI.Label(new Rect(Screen.width / 2 - 125, Screen.height / 2, Screen.width, Screen.height / 2),
				"Seems like this one does not resonate with my magic...");
		}
	}
}
