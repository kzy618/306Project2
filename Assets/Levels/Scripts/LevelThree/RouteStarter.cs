using System;
using UnityEngine;
using System.Collections;

public class RouteStarter : MonoBehaviour
{

	public int RouteNumber;

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
		if (other.CompareTag("pickable"))
		{
			LevelThreeController.GetComponent<LevelThreeController>().StartRoute(RouteNumber, gameObject);
		}
	}
}
