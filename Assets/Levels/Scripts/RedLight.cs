using UnityEngine;
using System.Collections;

public class RedLight : MonoBehaviour {
	public float duration = 1f;
	public Light lt;
	public float maxIntensity = 2f;
	// Use this for initialization
	void Start () {
		lt = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		float phi = Time.time / duration * 2 * Mathf.PI;
		float amplitude = Mathf.Cos (phi) * 0.5f + 0.5f;
		lt.intensity = amplitude* maxIntensity;
	}

}
