using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeathTimer : MonoBehaviour {

    private Text counterText;
	private bool active;

	private float startTime;
	public float seconds, minutes;
	public float countDown = 120f;
	public GameObject deathTrap;

    void Start () {
		active = false;
		counterText = GetComponent<Text>() as Text;

	}

    // Update is called once per frame
	void Update() {
		
		if (active) {
			minutes = (int)((countDown - (Time.timeSinceLevelLoad - startTime)) / 60f);
			seconds = (int)((countDown - (Time.timeSinceLevelLoad - startTime)) % 60f);
			counterText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
			if (countDown - (Time.timeSinceLevelLoad - startTime) < 0f) {
				active = false;
				counterText.text = "00:00";
				deathTrap.GetComponent<DeathTrap> ().activate ();
			}
				
		} else {
			startTime = Time.timeSinceLevelLoad;
		}
	}

	public void timerActivate(){
		active = true;
	}
}