    using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Spawning a Cube at the position where this throwable object hits the ground.
/// Any game object whose tag is included inside the IF-Statement will be considered as 'ground'.
/// </summary>
public class ThrowableController : MonoBehaviour
{

    private GameObject _fpsController;
	private Material Material;
	private Queue<GameObject> cubes;
	private int maxNumCube;


	private void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "ground" || other.gameObject.tag == "conveyerBeltUnit" || other.gameObject.tag == "Platform" || other.gameObject.tag == "LevelThreeRedStone" || other.gameObject.tag == "RouteStarter")
		{
			makeCube();
		} else
        {
            Destroy(gameObject);
        }
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "ground" || other.gameObject.tag == "conveyerBeltUnit" || other.gameObject.tag == "Platform" || other.gameObject.tag == "LevelThreeRedStone" || other.gameObject.tag == "RouteStarter")
		{
			makeCube();
		}
	}

	public void setMaterial(Material material)
	{
		Material = material;
	}

	public void passOnQueue(Queue<GameObject> queue)
	{
		cubes = queue;
	}

	public void setMaxNum(int max)
	{
		maxNumCube = max;
	}

	private void makeCube()
	{
		gameObject.SetActive(false);
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
        cube.transform.forward = _fpsController.transform.forward;
        Renderer rend = cube.GetComponent<Renderer>();
		rend.material = Material;
		cube.AddComponent<Rigidbody>();
		cube.AddComponent<PickableObjController>();
		cube.tag = "pickable";
		cubes.Enqueue(cube);
		Debug.Log(cubes.Count + " / " + maxNumCube);
		if (cubes.Count > maxNumCube)
		{
			GameObject cubeToBeDestroyed = cubes.Dequeue();
			Destroy(cubeToBeDestroyed);
		}
		Destroy(gameObject);
	}

    public GameObject FpsController
    {
        set
        {
            _fpsController = value;
        }
    }
}
