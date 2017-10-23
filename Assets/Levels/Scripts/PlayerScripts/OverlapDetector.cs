using UnityEngine;
using System.Collections;

/// <summary>
/// OverlapDetector detects whether or not the holding place is overlapping with other objects.
/// (Excluding 'Player', 'picked', and 'ground')
/// If the overlapping occurs, players will not be allowed to spawn a Ice Cube.
/// </summary>
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
