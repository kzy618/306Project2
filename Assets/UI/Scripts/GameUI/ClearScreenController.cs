using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClearScreenController : MonoBehaviour {

    public Text clearText;
    // Use this for initialization
    void Start()
    {
        clearText.text = "Clear Time : " + SaveStateController.controller.clearTime + "s";
        SaveStateController.controller.DeletePlayerData();
    }
}
