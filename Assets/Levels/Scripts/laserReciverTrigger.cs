using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class laserReciverTrigger : MonoBehaviour {
	public Image screen;
	public GameObject StopingMovingPlat;
	public Sprite movieImage;

	// Update is called once per frame
	void Update () {
		StopingMovingPlat.SetActive (true);
		screen = GetComponent<Image>();
		screen.sprite = movieImage;
	}

	public void activate(){
		
	}
}
