using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameUIController : MonoBehaviour {

    public Image escBlur;

    public GameObject settingsPanel;
    public Slider masterVolumeSlider;

    public GameObject confirmPanel;

    private bool escMenuOpen;


    // Use this for initialization
    void Start () {
        AudioListener.volume = SaveStateController.controller.masterVol;
        masterVolumeSlider.value = SaveStateController.controller.masterVol;
        // initially not settings panel open
        escMenuOpen = false;
    }

    // Updates master volume based on slider value
    public void updateMasterVolume()
    {
        AudioListener.volume = masterVolumeSlider.value;
        SaveStateController.controller.masterVol = masterVolumeSlider.value;
    }

    // called to set proper flag value instead of just closing the settings panel
    public void closeSettingsPanel() {
        settingsPanel.GetComponent<Animator>().SetTrigger("Close");
        escBlur.gameObject.SetActive(false);
        escMenuOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!escMenuOpen)
            {
                escBlur.gameObject.SetActive(true);
                escMenuOpen = true;
                settingsPanel.GetComponent<Animator>().SetTrigger("Open");
            }
        }
    }
}
