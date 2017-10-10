using UnityEngine;
using System.Collections;
using System;

public class PickableObjController : MonoBehaviour 
{

	private bool refusethrow = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "picked" && other.gameObject.tag != "ground" && other.gameObject.tag != "potion" && other.gameObject.tag != "memoryFragment")
		{
 
			Debug.Log(refusethrow);
			refusethrow = true;
 
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "picked" && other.gameObject.tag != "ground" && other.gameObject.tag != "potion" && other.gameObject.tag != "memoryFragment")
		{
 
			refusethrow = false;
 
		}
	}

	public bool isRefusethrow()
	{
		return refusethrow;
	}
}
