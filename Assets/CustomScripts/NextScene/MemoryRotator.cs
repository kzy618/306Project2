using UnityEngine;
using System.Collections;

public class MemoryRotator : MonoBehaviour {

    public NextScene _memoryChecker;
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            _memoryChecker._memoryFound = true;
        }
    }
}
