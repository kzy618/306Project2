using UnityEngine;
using System.Collections;

public class PickUpTorch : MonoBehaviour {

	private GameObject LevelThreeController;
	
	// Use this for initialization
	void Start () {
		LevelThreeController = GameObject.FindWithTag("LevelThreeController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("picked"))
		{
			LevelThreeController.GetComponent<LevelThreeController>().TorchInHand.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
