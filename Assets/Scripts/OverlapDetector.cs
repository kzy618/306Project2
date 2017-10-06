using UnityEngine;
using System.Collections;

public class OverlapDetector : MonoBehaviour
{

	private bool isOverlap = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "picked" && other.gameObject.tag != "ground")
		{
 
			isOverlap = true;
 
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "picked" && other.gameObject.tag != "ground")
		{
 
			isOverlap = false;
 
		}
	}
	
	public bool isOverlapping()
	{
		return isOverlap;
	}
}
