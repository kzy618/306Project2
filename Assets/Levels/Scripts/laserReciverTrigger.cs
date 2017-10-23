using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class laserReciverTrigger : MonoBehaviour {
	public Image screen;
	public GameObject StopingMovingPlat;
	public Sprite movieImage;

	void start(){
		
	}

	void update(){
		Debug.Log("aaaaaaaa");

		var bc = StopingMovingPlat.GetComponent<StopingMovingPlat> ();
		bc.enabled = true;

		screen = GetComponent<Image>();
		screen.sprite = movieImage;
	}
		
	public void activate(){
		Debug.Log("aaaaaaaa");

		var bc = StopingMovingPlat.GetComponent<StopingMovingPlat> ();
		bc.enabled = true;
	}
}
