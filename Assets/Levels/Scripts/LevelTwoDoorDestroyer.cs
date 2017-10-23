using UnityEngine;
using System.Collections;

public class LevelTwoDoorDestroyer : MonoBehaviour {

	public GameObject Door;

	private bool done;

	public AudioSource _doorSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void activate()
	{
		if (!done)
		{
			Destroy (Door);
			done = true;
			if (_doorSound != null) {
				_doorSound.Play ();
			}
		}
	}
}
