using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{

	private bool missingKey = false;
	private bool noPower = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player") && other.GetComponent<InteractionController>().keyFound && GameObject.FindWithTag("panel").GetComponent<ElectoPanelController>().isTurnedOn)
		{
			var thedoor = GameObject.FindWithTag("SF_Door");
			thedoor.GetComponent<Animation>().Play("open");
		}else if (other.CompareTag("Player") && !other.GetComponent<InteractionController>().keyFound)
		{
			missingKey = true;
		}
		else if (!GameObject.FindWithTag("panel").GetComponent<ElectoPanelController>().isTurnedOn)
		{
			noPower = true;
		}
		
	}

	void OnTriggerExit (Collider other) {
		if (other.CompareTag("Player") && other.GetComponent<InteractionController>().keyFound && GameObject.FindWithTag("panel").GetComponent<ElectoPanelController>().isTurnedOn)
		{
			var thedoor = GameObject.FindWithTag("SF_Door");
			thedoor.GetComponent<Animation>().Play("close");
		}
		missingKey = false;
		noPower = false;
	}
	
	void OnGUI()
	{
		if (missingKey){
			GUI.Label (new Rect (Screen.width/2,Screen.height/2,Screen.width/2,Screen.height/2), "you need to find the access card"); 
		}
		else if (noPower)
		{
			GUI.Label (new Rect (Screen.width/2,Screen.height/2,Screen.width/2,Screen.height/2), "power supply for this door is not switched on"); 
		}
	}
}
