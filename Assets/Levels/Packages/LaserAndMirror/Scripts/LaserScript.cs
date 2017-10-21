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

        // NOTE: 'reflectCount + 1' refers to the last vertex in the line renderer (e.g. the last line to be rendered)

        // keep iterating as long as the laser hits something
        while (Physics.Raycast(ray, out hit, 1000))
        {
            // render laser between previous hit point and newest hit point.
            _lineRenderer.SetPosition(reflectCount + 1, hit.point);

            GameObject hitObject = hit.collider.gameObject;

            // checks if the hit object should reflect the laser
            if (hitObject.CompareTag("Reflective Surface"))
            {

                reflectCount++;

                // increment vertex count to allow additional lines to be renderered
                _lineRenderer.SetVertexCount(2 + reflectCount); 

                // ok I don't think this actually does anything but I'm too scared to change it
                if (reflectCount >= 6)
                {
                    _lineRenderer.SetPosition(reflectCount + 1, hit.point);
                    break;
                }

                // calculate the new direction the reflected laser should travel
                Vector3 reflectedPos = Vector3.Reflect(ray.direction, hit.normal);


                // render the reflected laser
                _lineRenderer.SetPosition(reflectCount + 1, hit.point + reflectedPos * 1000f);

                // reset ray to check for further hits with the reflected laser in next iteration
                ray = new Ray(hit.point, reflectedPos);
                
            } 

            else if (hitObject.CompareTag("pickable"))
            {
                // increase count by 2 as we are rendering two extra lines here
                reflectCount += 2;

                _lineRenderer.SetVertexCount(2 + reflectCount);

                // render laser to reach center of the ice block
                _lineRenderer.SetPosition(reflectCount, hitObject.GetComponent<Renderer>().bounds.center);

                // render laser to project in the direction of the ice block
                _lineRenderer.SetPosition(reflectCount + 1, hitObject.transform.forward * 1000f);

                // reset ray to check for further hits with the redirected laser in the next iteration
                ray = new Ray(hitObject.GetComponent<Renderer>().bounds.center, hitObject.transform.forward);
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
				if(hitObject.GetComponent<LaserReceiverController>() != null)
                	hitObject.GetComponent<LaserReceiverController>().activate();
				if(hitObject.GetComponent<LaserReceiverControllerTranslate>() != null)
					hitObject.GetComponent<LaserReceiverControllerTranslate>().activate();
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
