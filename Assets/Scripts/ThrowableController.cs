using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThrowableController : MonoBehaviour
{

	private Material Material;
	private Queue<GameObject> cubes;
	private int maxNumCube;


	private void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "ground")
		{
			makeCube();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "ground")
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
}
