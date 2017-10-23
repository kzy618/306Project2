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

	/// <summary>
	/// Damages the player when they touch the invisible damage area
	/// </summary>
	/// <param name="Col">Col.</param>
	void OnTriggerStay(Collider Col){
		if(Col.gameObject.CompareTag("Player")){
			plController.takeDamage ();
		}
	}
}
