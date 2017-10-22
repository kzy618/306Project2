using System;
using UnityEngine;
using System.Collections;

public class BonfireController : MonoBehaviour
{

	private int hitCount;
	private bool isLightedUp;

	private bool r1Hit;
	private bool r2Hit;
	private bool r3Hit;
	private bool r4Hit;
	private bool r5Hit;
	
	private GameObject LevelThreeController;

	// Use this for initialization
	void Start () {
		LevelThreeController = GameObject.FindWithTag("LevelThreeController");
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLightedUp)
		{
			if (r1Hit && r2Hit && r3Hit && r4Hit && r5Hit)
			{
				LevelThreeController.GetComponent<LevelThreeController>().AllDone = true;
				isLightedUp = true;
			}
		}
	}
	
	public void activate(String tag)
	{
		if (tag.Equals("LaserR1"))
		{
			r1Hit = true;
		}
		else if (tag.Equals("LaserR2"))
		{
			r2Hit = true;
		}
		else if (tag.Equals("LaserR3"))
		{
			r3Hit = true;
		}
		else if (tag.Equals("LaserR4"))
		{
			r4Hit = true;
		}
		else if (tag.Equals("LaserR5"))
		{
			r5Hit = true;
		}
	}
}
