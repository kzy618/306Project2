using UnityEngine;
using System.Collections;

public class DeathLaser : MonoBehaviour {

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
			if (hitObject.CompareTag("Player"))
			{
				// make player take damage and render laser
				hitObject.GetComponent<PlayerLifeController>().Death ();
				break;
			}

			// checks if a laser receiver was hit
			else if (hitObject.CompareTag("laser receiver"))
			{
				// activate the BonfireController, used in level three only
				if(hitObject.GetComponent<BonfireController>() != null)
					hitObject.GetComponent<BonfireController>().activate(gameObject.tag);
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
