using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponentInChildren<Text>().text = SaveStateController.controller.playerName;
	}
}
