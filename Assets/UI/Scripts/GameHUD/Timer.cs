using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    private Text counterText;

    public float seconds, minutes;
	// Use this for initialization
	void Start () {
        counterText = GetComponent<Text>() as Text;
	}

    // Update is called once per frame
    void Update() {
        minutes = (int)(Time.timeSinceLevelLoad/60f);
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
            counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
	}
}