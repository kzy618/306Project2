using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour {
    public Button continueButton;
    public Button disabledContinueButton;


    // Use this for initialization
    void Start () {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            disabledContinueButton.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            disabledContinueButton.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(false);
        }
    }

}