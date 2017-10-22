using UnityEngine;
using System.Collections;
using System;

public class CafeLaserRotation : MonoBehaviour {

    public MovingPlatformScript platform;
    public GameObject laser1; 
    public GameObject laser2; 
    public float radiansPerFrame = 0.01f;
    private float defaultRadianssPerFrame;

    private Quaternion defaultRotation1;
    private Quaternion defaultRotation2;

    private Boolean triggered = false;
    private Collider other;

    private Vector3 defaultButtonPosition;
    private Vector3 pressedButtonPosition;

	public GameObject laserTip1;
	public GameObject laserTip2;

    void Start()
    {
        defaultButtonPosition = transform.position;
        pressedButtonPosition = transform.position - (transform.up * GetComponent<Renderer>().bounds.size.y / 2);

        defaultRotation1 = laser1.transform.rotation;
        defaultRotation2 = laser2.transform.rotation;
        defaultRadianssPerFrame = platform.radiansPerFrame;
    }

    void FixedUpdate()
    {
        if (triggered && !other)
        {
            transform.position = defaultButtonPosition;
            triggered = false;
        }
        if (!triggered)
        {
            this.rotateDefaultLasterPosition();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickable"))
        {
            transform.position = pressedButtonPosition;
            this.other = other;
            this.triggered = true;
            this.rotateNewLasterPosition();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pickable"))
        {
            transform.position = defaultButtonPosition;
            triggered = false;
        }
    }

    void rotateDefaultLasterPosition()
    {
        platform.radiansPerFrame = defaultRadianssPerFrame;
        laser1.transform.rotation = defaultRotation1;
        laser2.transform.rotation = defaultRotation2;
		this.enableLaserScript();
    }
    void rotateNewLasterPosition()
    {
        platform.radiansPerFrame = radiansPerFrame;
        laser1.transform.Rotate(0, 90, 0, Space.World);
        laser2.transform.Rotate(0, -90, 0, Space.World);
		this.enableCafeLaserScript();
    }

	void enableCafeLaserScript(){
		laserTip1.GetComponent<LaserScript>().enabled = false;
		laserTip1.GetComponent<CafeLaserScript>().enabled = true;
		laserTip2.GetComponent<LaserScript>().enabled = false;
		laserTip2.GetComponent<CafeLaserScript>().enabled = true;
	}
	void enableLaserScript(){
		laserTip1.GetComponent<CafeLaserScript>().enabled = false;
		laserTip1.GetComponent<LaserScript>().enabled = true;
		laserTip2.GetComponent<CafeLaserScript>().enabled = false;
		laserTip2.GetComponent<LaserScript>().enabled = true;
	}
}
