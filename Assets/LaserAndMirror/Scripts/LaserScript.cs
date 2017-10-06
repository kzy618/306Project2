using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

    private LineRenderer line;

	// Use this for initialization
	void Start ()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        StartCoroutine("FireLaser");
	}

    IEnumerator FireLaser()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        int hitCount = 0;

        line.SetPosition(0, ray.origin);
        line.SetVertexCount(2);

        while (Physics.Raycast(ray, out hit, 1000))
        {
            line.SetPosition(hitCount + 1, hit.point);

            GameObject hitObject = hit.collider.gameObject;
            print("Laser is hitting: " + hitObject.name);

            if (hitObject.CompareTag("Reflective Surface") || hitObject.CompareTag("pickable"))
            {

                hitCount++;

                line.SetVertexCount(2 + hitCount);

                if (hitCount == 4)
                {
                    line.SetPosition(hitCount + 1, hit.point);
                }

                Vector3 reflectedPos = Vector3.Reflect(ray.direction, hit.normal);
                line.SetPosition(hitCount + 1, hit.point + reflectedPos * 1000f);
                print("Hit mirror: " + hitCount);

                ray = new Ray(hit.point, reflectedPos);
                
            } 

            else if (hitObject.CompareTag("Player"))
            {
                hitObject.GetComponent<PlayerLifeController>().takeDamage();
                line.SetPosition(hitCount + 1, hit.point);
                break;
            }

            else if (hitObject.CompareTag("laser receiver"))
            {
                hitObject.GetComponent<LaserReceiverController>().activate();
                line.SetPosition(hitCount + 1, hit.point);
                break;
            }

            else
            {
                print("No reflection");
                line.SetPosition(hitCount + 1, hit.point);
                break;
            }
        }

        if (!Physics.Raycast(ray, out hit, 1000))
        {
            line.SetPosition(hitCount + 1, ray.GetPoint(1000));
        }
        

        yield return null;
    }
}
