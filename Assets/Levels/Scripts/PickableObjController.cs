using UnityEngine;
using System.Collections;

public class PickableObjController : MonoBehaviour 
{

	private bool refusethrow = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "picked" && other.gameObject.tag != "ground")
		{
 
			refusethrow = true;
 
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "picked" && other.gameObject.tag != "ground")
		{
 
			refusethrow = false;
 
		}
	}

	public bool isRefusethrow()
	{
		return refusethrow;
	}
}
