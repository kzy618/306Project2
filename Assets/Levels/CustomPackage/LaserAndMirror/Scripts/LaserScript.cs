using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

    private LineRenderer _lineRenderer;

	// Use this for initialization
	void Start ()
    {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
        _lineRenderer.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        StartCoroutine("FireLaser");
	}

    IEnumerator FireLaser()
    {
        // Create ray shooting forward
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        int reflectCount = 0; // keep count of amount of reflections

        _lineRenderer.SetPosition(0, ray.origin); // set start point of laser
        _lineRenderer.SetVertexCount(2);

        // keep iterating as long as the laser hits something
        while (Physics.Raycast(ray, out hit, 1000))
        {
            // render laser between previous hit point and newest hit point.
            _lineRenderer.SetPosition(reflectCount + 1, hit.point);

            GameObject hitObject = hit.collider.gameObject;

            // checks if the hit object should reflect the laser
            if (hitObject.CompareTag("Reflective Surface") || hitObject.CompareTag("pickable"))
            {

                reflectCount++;

                // increment vertex count to allow additional lines to be renderered
                _lineRenderer.SetVertexCount(2 + reflectCount); 

                // ok I don't think this actually does anything but I'm too scared to change it
                if (reflectCount == 4)
                {
                    _lineRenderer.SetPosition(reflectCount + 1, hit.point);
                }

                // calculate the new direction the reflected laser should travel
                Vector3 reflectedPos = Vector3.Reflect(ray.direction, hit.normal);


                // render the reflected laser
                _lineRenderer.SetPosition(reflectCount + 1, hit.point + reflectedPos * 1000f);

                // reset ray to check for further hits with the reflected laser in next iteration
                ray = new Ray(hit.point, reflectedPos);
                
            } 

            // checks if the laser hit the Player
            else if (hitObject.CompareTag("Player"))
            {
                // make player take damage and render laser
                hitObject.GetComponent<PlayerLifeController>().takeDamage();
                _lineRenderer.SetPosition(reflectCount + 1, hit.point);
                break;
            }

            // checks if a laser receiver was hit
            else if (hitObject.CompareTag("laser receiver"))
            {
                // activate the laser receiver and render laser
                hitObject.GetComponent<LaserReceiverController>().activate();
                _lineRenderer.SetPosition(reflectCount + 1, hit.point);
                break;
            }

            // normal surface hit
            else
            {
                _lineRenderer.SetPosition(reflectCount + 1, hit.point);
                break;
            }
        }

        // for when the laser doesn't hit a surface (or reflected laser doesn't hit a surface)
        if (!Physics.Raycast(ray, out hit, 1000))
        {
            _lineRenderer.SetPosition(reflectCount + 1, ray.GetPoint(1000));
        }
        

        yield return null;
    }
}
