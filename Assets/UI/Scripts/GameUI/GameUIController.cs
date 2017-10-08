using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;


public class GameUIController : MonoBehaviour {

    public Image escBlur;

    public GameObject settingsPanel;
    public Slider masterVolumeSlider;

    public GameObject confirmPanel;

    public Toggle hintTextToggle;
    public Text hintText;
    public GameObject fpsController;

    private bool escMenuOpen;
    public GameObject a_camera;

    // Use this for initialization
    void Start () {
        AudioListener.volume = SaveStateController.controller.masterVol;
        masterVolumeSlider.value = SaveStateController.controller.masterVol;
        hintTextToggle.isOn = SaveStateController.controller.hintTextToggle;
        // initially not settings panel open
        escMenuOpen = false;
        //a_camera = GameObject.FindGameObjectWithTag("AnotherCamera");
        Debug.Log(a_camera);
    }


    public void reconfigureHintText() {
        hintText.gameObject.SetActive(hintTextToggle.isOn);
        SaveStateController.controller.hintTextToggle = hintTextToggle.isOn;

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
        Time.timeScale = 1;
        fpsController.GetComponent<FirstPersonController>().enabled = true;
        fpsController.GetComponent<FirstPersonController>().getMouseLook().lockCursor = true;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                if (!escMenuOpen)
                {
                    //a_camera.SetActive(true);
                    //fpsController.SetActive(false);
                    fpsController.GetComponent<FirstPersonController>().enabled = false;
                    fpsController.GetComponent<FirstPersonController>().getMouseLook().lockCursor = false;
                    Cursor.visible = true;
                    Time.timeScale = 0;
                    escBlur.gameObject.SetActive(true);
                    escMenuOpen = true;
                    settingsPanel.GetComponent<Animator>().SetTrigger("Open");
                } 
            }
        }
    }
}
