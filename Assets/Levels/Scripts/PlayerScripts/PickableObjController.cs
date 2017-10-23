using UnityEngine;
using System.Collections;

/// <summary>
/// PickableObjController determine whether or not the object currently being held is overlapping with other objects.
/// (Excluding 'Player', 'picked', 'ground', etc.)
/// If overlapping occurs, throwing or releasing the Cube will not be allowed.
/// </summary>
public class PickableObjController : MonoBehaviour 
{

	private bool refusethrow = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Player" && 
		    other.gameObject.tag != "picked" && 
		    other.gameObject.tag != "ground" && 
		    other.gameObject.tag != "potion" && 
		    other.gameObject.tag != "memoryFragment" &&
		    other.gameObject.tag != "LevelThreeRedStone" &&
		    other.gameObject.tag != "RouteStarter")
		{
 
			Debug.Log(refusethrow);
			refusethrow = true;
 
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag != "Player" && 
		    other.gameObject.tag != "picked" && 
		    other.gameObject.tag != "ground" && 
		    other.gameObject.tag != "potion" && 
		    other.gameObject.tag != "memoryFragment" &&
		    other.gameObject.tag != "LevelThreeRedStone" &&
		    other.gameObject.tag != "RouteStarter")
		{
 
			refusethrow = false;
 
		}
	}

	public bool isRefusethrow()
	{
		return refusethrow;
	}
}
