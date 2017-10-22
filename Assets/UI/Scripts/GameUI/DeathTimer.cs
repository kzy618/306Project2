using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeathTimer : MonoBehaviour {

    private Text counterText;
	private bool active;

	private float startS, startM;
    public float seconds, minutes;


    void Start () {
		active = false;
        counterText = GetComponent<Text>() as Text;
	}

    // Update is called once per frame
	void Update() {
		startM = (int)(Time.timeSinceLevelLoad/60f);
		startS = (int)(Time.timeSinceLevelLoad % 60f);
		if (active) {
			minutes = (int)((Time.timeSinceLevelLoad / 60f) - startM);
			seconds = (int)((Time.timeSinceLevelLoad % 60f) - startS);
			counterText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
		}
	}

	public void timerActivate(){
		active = true;
	}
}