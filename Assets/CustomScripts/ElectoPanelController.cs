using UnityEngine;
using System.Collections;

public class ElectoPanelController : MonoBehaviour {

	private bool isReachable = false;
	public bool isTurnedOn = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player") && !isTurnedOn)
		{
			isReachable = !isReachable;
			other.GetComponent<InteractionController>().panelFound = true;
			Debug.Log("he can touch the panel now");
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.CompareTag("Player") && !isTurnedOn)
		{
			isReachable = !isReachable;
			other.GetComponent<InteractionController>().panelFound = false;
			Debug.Log("he leaves");
		}
	}
	
	void OnGUI()
	{
		if (isReachable && !isTurnedOn){
			GUI.Label (new Rect (Screen.width/2,Screen.height/2,Screen.width/2,Screen.height/2), "press F to turn on the power"); 
		}
	}
}
