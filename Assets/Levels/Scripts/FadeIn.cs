using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {
	public float timeToFade = 1f;
	private bool hasFaded;
	// Use this for initialization
	void Start () {
		hasFaded = false;
		GetComponent<CanvasGroup> ().alpha = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasFaded) {
			GetComponent<CanvasRenderer> ().SetAlpha (Mathf.Lerp (1f, 0f, Time.timeSinceLevelLoad / timeToFade));
			if (Time.timeSinceLevelLoad > timeToFade) {
				hasFaded = true;
				Debug.Log ("faded");
			}
		} else {
			GetComponent<CanvasRenderer> ().SetAlpha (0f);
		}

	}
}
