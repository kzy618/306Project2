using UnityEngine;
using System.Collections;

// Destroys the last door of level 2
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

    // start destruction of door to next level
	public void activate()
	{
		if (!done)
		{
            // make door and button invisible after laser hit
			Destroy (Door);
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
            done = true;
			if (_doorSound != null) {
				_doorSound.Play ();
			}
		}
	}
}
