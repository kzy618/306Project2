using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractionController : MonoBehaviour
{
    private bool hasKey = false;
    private bool hasTurnedOnPower = false;
    private bool isLoaded = false;

    public bool keyFound = false;
    public bool panelFound = false;

    public Material CubeMaterial;

    public float PickableRange = 2f;
    public int throwingForce = 8000;
    public GameObject holdingPlace;

    private Camera fpsCam;

    private Vector3 objectPos;
    private Quaternion objectRot;
    private GameObject pickObj;

    private bool canpick = true;
    private bool picking = false;
    private bool guipick = false;
    private bool picked = false;

    private bool canSwitchPlaces = true;

    private Vector3 respawnPoint = new Vector3(0.0f, 0.25f, 0.0f);

    public int spawnBoxLimit = 1; // initialized as 1s
    private List<GameObject> cubes;

    private int c;

    private GameObject pickref;

    // Use this for initialization
    void Start () {
        pickref = GameObject.FindWithTag("pickedref");
        pickObj = pickref;
        fpsCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        cubes = new List<GameObject>();
    }
	
    // Update is called once per frame
    void Update () {
        if (transform.position.y < -200f)
        {
            transform.position = respawnPoint;
        }
        else if (Input.GetKeyDown(KeyCode.F) )
        {
            Debug.Log("can create cubes");
            if (cubes.Count >= spawnBoxLimit)
            {
                GameObject removeThisCube = cubes[0];
                DestroyObject(removeThisCube);
                cubes.Remove(removeThisCube);
            }
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.AddComponent ("BoxCollider");
			var boxCollider = cube.collider;
			if(boxCollider != null){
				boxCollider.size = new Vector (1.1f, 1.1f, 1.1f);
			}
            cube.transform.position = holdingPlace.transform.position;
            Renderer rend = cube.GetComponent<Renderer>();
            rend.material = CubeMaterial;
            cube.AddComponent<Rigidbody>();
            cube.AddComponent<PickableObjController>();
            cube.tag = "pickable";
            cubes.Add(cube);
        }
        else if (canSwitchPlaces && !picked && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("try switch places");
            if(cubes.Count != 0)
            {
                GameObject latestCube = cubes[cubes.Count - 1];
                Vector3 latestCubePosition = new Vector3(latestCube.transform.position.x, latestCube.transform.position.y + 0.25f, latestCube.transform.position.z);

                transform.position = latestCubePosition;

                DestroyObject(latestCube);
                cubes.Remove(latestCube);


            }
        }
        else
        {
            Debug.Log("can pick up cubes");
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, PickableRange))
            {
                Debug.DrawRay(rayOrigin, fpsCam.transform.forward * PickableRange, Color.red);
                if (hit.collider.gameObject.CompareTag("pickable"))
                {
                    Debug.Log("can reach cubes");
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

            }
		
            if(Input.GetKeyDown(KeyCode.Mouse0) && !canpick && !pickObj.GetComponent<PickableObjController>().isRefusethrow()){
                
                pickObj.GetComponent<Rigidbody>().useGravity = true;

                pickObj.GetComponent<Rigidbody>().isKinematic = false;

                pickObj.transform.parent = null;

                pickObj.GetComponent<Collider>().isTrigger = false;
  
                pickObj.GetComponent<Rigidbody>().AddForce (holdingPlace.transform.forward * throwingForce);
			
                pickObj = pickref;
 
                picked = false;
                
                
                canpick = true;
			
            }
		
            if(Input.GetKeyDown(KeyCode.Mouse1) && !canpick && !pickObj.GetComponent<PickableObjController>().isRefusethrow()){
                
                pickObj.GetComponent<Rigidbody>().useGravity = true;

                pickObj.GetComponent<Rigidbody>().isKinematic = false;

                pickObj.transform.parent = null;

                pickObj.GetComponent<Collider>().isTrigger = false;
			
                pickObj = pickref;
			
                picked = false;
                
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