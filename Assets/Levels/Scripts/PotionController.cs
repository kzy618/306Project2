using UnityEngine;
using System.Collections;

public class PotionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
		transform.eulerAngles = new Vector3(30, 45, 45);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (30, 45, 0) * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			GameObject player = other.gameObject;
			player.GetComponent<PlayerLifeController>().healing();
			Destroy(gameObject);
		}
	}
}
