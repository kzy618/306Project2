using UnityEngine;
using System.Collections;

public class CrateController : MonoBehaviour {
	
	public GameObject PotionGameObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("pickable"))
		{
			Debug.Log(other.gameObject.tag);
			float chance = Random.Range(0f, 1f);
			Debug.Log(chance);
			if (chance > 0f)
			{
				gameObject.SetActive(false);
				GameObject potion = (GameObject) Instantiate(PotionGameObject, transform.position, transform.rotation);
				Debug.Log(potion.tag);
				potion.AddComponent<Rigidbody>().isKinematic = true;
				potion.AddComponent<BoxCollider>().isTrigger = true;
				potion.AddComponent<PotionController>();
			}
			Destroy(gameObject);
		}
	}
}
