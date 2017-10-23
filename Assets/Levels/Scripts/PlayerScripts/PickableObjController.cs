using UnityEngine;
using System.Collections;

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
