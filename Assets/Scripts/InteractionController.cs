using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InteractionController : MonoBehaviour {

	private bool isLoaded = false;
	
	public Material CubeMaterial;
	public Material CapsuleMaterial;
	
	public float PickableRange = 3.5f;
	public int throwingForce = 8000;
	
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
	
	// Use this for initialization
	void Start () {
		pickref = GameObject.FindWithTag("pickedref");
		throwref = GameObject.FindWithTag("throwref");
		pickObj = pickref;
		fpsCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		nextSpawn = 0;
		cubes = new Queue<GameObject>();
        // set spawn point as check point initially, have to update as user  progress
        respawnPoint = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        // if fell out of map, respawn to check point
        if (transform.position.y < -200f)
        {
            transform.position = respawnPoint;
        }
        if (canSwitchPlaces && !picked && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("try switch places");
            if (cubes.Count != 0)
            {
                GameObject latestCube = cubes.Last();
                Vector3 latestCubePosition = new Vector3(latestCube.transform.position.x, latestCube.transform.position.y + 0.25f, latestCube.transform.position.z);

                transform.position = latestCubePosition;

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
            
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(spawningPlace.transform.position.x, spawningPlace.transform.position.y, spawningPlace.transform.position.z);
            Renderer rend = cube.GetComponent<Renderer>();
            rend.material = CubeMaterial;
            cube.AddComponent<Rigidbody>();
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
		else if (Input.GetKeyDown(KeyCode.R) && !isLoaded  && Time.time > nextSpawn)
		{
			GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			capsule.transform.position = new Vector3(throwref.transform.position.x, throwref.transform.position.y, throwref.transform.position.z);
			capsule.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			Renderer rend = capsule.GetComponent<Renderer>();
			rend.material = CapsuleMaterial;
			capsule.AddComponent<Rigidbody>();
			ThrowableController throwableController = capsule.AddComponent<ThrowableController>();
			throwableController.setMaterial(CubeMaterial);
			throwableController.passOnQueue(cubes);
			throwableController.setMaxNum(maxNumCube);
			capsule.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			capsule.GetComponent<Rigidbody>().AddForce (throwref.transform.forward * throwingForce);
			nextSpawn = Time.time + spawningInterval;
		}
        else
        {
            
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, PickableRange))
            {
                Debug.DrawRay(rayOrigin, fpsCam.transform.forward * PickableRange, Color.red);
                if (hit.collider.gameObject.CompareTag("pickable"))
                {
                    guipick = true;
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
            
            objectPos = holdingPlace.transform.position;
            objectRot = holdingPlace.transform.rotation;
            
            rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
            if (Input.GetKeyDown(KeyCode.Mouse0) && canpick && Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, PickableRange) && hit.collider.gameObject.CompareTag("pickable"))
            {
                picking = true;
                
                pickObj = hit.collider.gameObject;

                hit.rigidbody.useGravity = false;

                hit.rigidbody.isKinematic = true;

                hit.collider.isTrigger = true;

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
                
                pickObj.GetComponent<Rigidbody>().useGravity = true;

                pickObj.GetComponent<Rigidbody>().isKinematic = false;

                pickObj.transform.parent = null;

                pickObj.GetComponent<Collider>().isTrigger = false;
  
                pickObj.GetComponent<Rigidbody>().AddForce (holdingPlace.transform.forward * throwingForce);
			
                pickObj = pickref;
 
                picked = false;
                
                isLoaded = false;
                
                canpick = true;
			
            }
		
            if(Input.GetKeyDown(KeyCode.Mouse1) && !canpick && !pickObj.GetComponent<PickableObjController>().isRefusethrow()){
                
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
	
	void OnGUI()
	{
		if (guipick && canpick){
			GUI.Label (new Rect (Screen.width/2,Screen.height/2,Screen.width/2,Screen.height/2), "press Mouse LB to pick"); 
		}
		else if (picked)
		{
			GUI.Label (new Rect (Screen.width/2,Screen.height/2,Screen.width/2,Screen.height/2), "press Mouse LB to throw or Mouse RB to release"); 
		}
	}
}
