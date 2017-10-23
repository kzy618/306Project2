using UnityEngine;
using System.Collections;

public class DamageArea : MonoBehaviour {
	public GameObject player;

	private PlayerLifeController plController;
	// Use this for initialization
	void Start () {
		plController = player.GetComponent<PlayerLifeController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider Col){
		plController.takeDamage ();
	}
}
