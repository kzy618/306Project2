using UnityEngine;
using System.Collections;

public class PotionController : MonoBehaviour {

	private bool _healed;

	// Use this for initialization
	void Start () {
		_healed = false;
		transform.position = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
		transform.eulerAngles = new Vector3(30, 45, 45);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (30, 45, 0) * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && !_healed)
		{
			_healed = true;
			GameObject player = other.gameObject;
			player.GetComponent<PlayerLifeController>().healing();
			Debug.Log ("healing");
			Destroy(gameObject);
		}
	}
}
