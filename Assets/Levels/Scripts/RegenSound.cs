using UnityEngine;
using System.Collections;

public class RegenSound : MonoBehaviour {

	public void Play()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
