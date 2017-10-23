using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// InteractionController manages the in-game interaction between Protagonist and Ice Cubes.
/// InteractionController implpements serveral interactions, including:
/// spawning a Ice Cube, picking up a Ice Cube, throwing a Ice Cube, throwing a Ice Cube Spawner,
/// releasing a Ice Cube gently, and interacting with the Memory Fragment.
/// </summary>
public class InteractionController : MonoBehaviour {

	private bool isLoaded = false;
	
	public Material CubeMaterial;
	public Material CapsuleMaterial;
	
	public float PickableRange = 3.5f;
	public float throwingForce = 10f;
	
	public GameObject holdingPlace;
	public GameObject spawningPlace;

	public float spawningInterval;

	public int maxNumCube;
	
	private Camera fpsCam; 
 
	private Vector3 objectPos;
	private Quaternion objectRot;
	private GameObject pickObj;
 	
	private bool canpick = true;
	private bool picking = false;
	private bool guipick = false;
	private bool picked = false;

	private GameObject pickref;
	private GameObject throwref;
	private float nextSpawn;

    private Vector3 respawnPoint;
    public bool canSwitchPlaces = false;

    private Queue<GameObject> cubes;
    // how many memories are found
    public int _memories;


    // Acquire references of important objects
    void Start () {
		pickref = GameObject.FindWithTag("pickedref");
		throwref = GameObject.FindWithTag("throwref");
		pickObj = pickref; // placeholder for pickable objects.
		fpsCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		nextSpawn = 0; //spawning interval
		cubes = new Queue<GameObject>();
        // set spawn point as check point initially, have to update as user  progress
        respawnPoint = transform.position;
        _memories = 0;
    }
	
	// Update is called once per frame
	void Update () {
		// if fell out of map, respawn to check point
		if ((int)Time.timeScale != 0)
		{
			if (transform.position.y < -200f)
			{
				transform.position = respawnPoint;
			}
			if ( Input.GetKeyDown(KeyCode.T)&& canSwitchPlaces && !picked)
			{
				Debug.Log("try switch places");
				if (cubes.Count != 0)
				{
					GameObject latestCube = cubes.Last();
					Vector3 latestCubePosition = new Vector3(latestCube.transform.position.x, latestCube.transform.position.y + 0.25f, latestCube.transform.position.z);

					transform.parent.position = latestCubePosition;
					//transform.parent.position = latestCubePosition;

					DestroyObject(latestCube);
					Queue<GameObject> temp = new Queue<GameObject>();
					for (int i = 0; i < cubes.Count-1; i++)
					{
						temp.Enqueue(cubes.Dequeue());
					}
					cubes = temp;

				}
			}else 
			if (Input.GetKeyDown(KeyCode.F) && !isLoaded && !spawningPlace.GetComponent<OverlapDetector>().isOverlapping() && Time.time > nextSpawn)
			{
            	//make a Ice Cube
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.position = new Vector3(spawningPlace.transform.position.x, spawningPlace.transform.position.y, spawningPlace.transform.position.z);
                cube.transform.forward = gameObject.transform.forward;
				Renderer rend = cube.GetComponent<Renderer>();
				rend.material = CubeMaterial;
				cube.AddComponent<Rigidbody>();
				//cube.GetComponent<BoxCollider> ().size = new Vector3 (2f, 2f, 2f);
				//cube.AddComponent<BoxCollider> ();
				cube.AddComponent<PickableObjController>();
				cube.tag = "pickable";
				nextSpawn = Time.time + spawningInterval;
				cubes.Enqueue(cube);
				if (cubes.Count > maxNumCube)
				{
					GameObject cubeToBeDestroyed = cubes.Dequeue();
					Destroy(cubeToBeDestroyed);
				}
			}
			else if (Input.GetKeyDown(KeyCode.R) && !isLoaded  && Time.time > nextSpawn) //throw a capsule which will spawn a Ice Cube for you at the position where it hits the ground.
			{
				GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				capsule.transform.position = new Vector3(throwref.transform.position.x, throwref.transform.position.y, throwref.transform.position.z);
				capsule.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				capsule.tag = "Capsule";
				Renderer rend = capsule.GetComponent<Renderer>();
				rend.material = CapsuleMaterial;
				capsule.AddComponent<Rigidbody>();
				ThrowableController throwableController = capsule.AddComponent<ThrowableController>();
                throwableController.FpsController = gameObject;
				throwableController.setMaterial(CubeMaterial);
				throwableController.passOnQueue(cubes);
				throwableController.setMaxNum(maxNumCube);
				capsule.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
				capsule.GetComponent<Rigidbody>().velocity = throwref.transform.forward * throwingForce;
				nextSpawn = Time.time + spawningInterval;
			}
			else
			{
            	//try detecting a pickable object
				Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
				RaycastHit hit;
				if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, PickableRange))
				{
					Debug.DrawRay(rayOrigin, fpsCam.transform.forward * PickableRange, Color.red);
					if (hit.collider.gameObject.CompareTag("pickable"))
					{
						guipick = true; //show tooltip on the screen
					}
					else
					{
						guipick = false;
					}
				}
				else
				{
					guipick = false;
				}
            	//get the transform details of the holding place
				objectPos = holdingPlace.transform.position;
				objectRot = holdingPlace.transform.rotation;
            
				rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
				if (Input.GetKeyDown(KeyCode.Mouse0) && canpick && Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, PickableRange) && hit.collider.gameObject.CompareTag("pickable"))
				{
					//move the pickable object to the holding place
					
					picking = true;
                
					pickObj = hit.collider.gameObject;

					hit.rigidbody.useGravity = false;

					hit.rigidbody.isKinematic = true;

					hit.collider.isTrigger = false;

					hit.transform.parent = holdingPlace.transform;

					hit.transform.position = objectPos;
   
					hit.transform.rotation = objectRot;
                
				}
		
				if(Input.GetKeyUp(KeyCode.Mouse0) && picking){

					picking = false;
                
					canpick = false;

					picked = true;

					isLoaded = true;
				}
		
				if(Input.GetKeyDown(KeyCode.Mouse0) && !canpick && !pickObj.GetComponent<PickableObjController>().isRefusethrow()){
                
					//throw the object being held
					
					pickObj.GetComponent<Rigidbody>().useGravity = true;

					pickObj.GetComponent<Rigidbody>().isKinematic = false;

					pickObj.transform.parent = null;

					pickObj.GetComponent<Collider>().isTrigger = false;
  
					pickObj.GetComponent<Rigidbody>().velocity = holdingPlace.transform.forward * throwingForce; //add force to the object
			
					pickObj = pickref;
 
					picked = false;
                
					isLoaded = false;
                
					canpick = true;
			
				}
		
				if(Input.GetKeyDown(KeyCode.Mouse1) && !canpick && !pickObj.GetComponent<PickableObjController>().isRefusethrow()){
                
					//release the object simply without applying additional force.
					
					pickObj.transform.position = new Vector3(pickObj.transform.position.x, pickObj.transform.position.y, pickObj.transform.position.z);
	            
					pickObj.GetComponent<Rigidbody>().useGravity = true;

					pickObj.GetComponent<Rigidbody>().isKinematic = false;

					pickObj.transform.parent = null;

					pickObj.GetComponent<Collider>().isTrigger = false;
			
					pickObj = pickref;
			
					picked = false;
                
					isLoaded = false;
                
					canpick = true;
                
				}
			}
		}
	}
	
	void OnGUI()
	{
		if (guipick && canpick)
		{
			GUI.color = Color.red;
			GUI.Label (new Rect (Screen.width/2 - 50,Screen.height*3/4,Screen.width,Screen.height/2), "Press LMB to pick up"); 
		}
		else if (picked)
		{
			GUI.color = Color.red;
			GUI.Label (new Rect (Screen.width/2 - 50,Screen.height*3/4,Screen.width,Screen.height/2), "LMB to throw. RMB to drop"); 
		}
	}

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.ToString());
        if (other.gameObject.CompareTag("memoryFragment"))
        {
            other.gameObject.SetActive(false);
            _memories++;
        }
    }

}
