using UnityEngine;
using System.Collections;

public class AccessKeyPicker : MonoBehaviour
{

	private bool isSeen = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		//Debug.Log("he sees the key now");
		if (other.CompareTag("Player"))
		{
			isSeen = !isSeen;
			other.GetComponent<InteractionController>().keyFound = true;
			Debug.Log("he sees the key now");
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.CompareTag("Player"))
		{
			isSeen = !isSeen;
			other.GetComponent<InteractionController>().keyFound = false;
			Debug.Log("he leaves");
		}
	}
	
	void OnGUI()
	{
		if (isSeen){
			GUI.Label (new Rect (Screen.width/2,Screen.height/2,Screen.width/2,Screen.height/2), "press F to pick"); 
		}
	}
}
