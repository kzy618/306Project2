using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour {
    public Button continueButton;
    public Button disabledContinueButton;

    void Start () {
        // if player data exists, player is able to Continue game and hence the Continue button is enabled
        if (File.Exists(SaveStateController.PLAYER_DATA_FILENAME))
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