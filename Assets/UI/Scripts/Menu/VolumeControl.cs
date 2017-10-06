using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {

    public Slider masterVolumeSlider;

    void Start()
    {
        AudioListener.volume = SaveStateController.controller.masterVol;
        masterVolumeSlider.value = SaveStateController.controller.masterVol;
    } 

    // Updates master volume based on slider value
    public void updateMasterVolume () {
        AudioListener.volume = masterVolumeSlider.value;
        SaveStateController.controller.masterVol = masterVolumeSlider.value;
    }
}
