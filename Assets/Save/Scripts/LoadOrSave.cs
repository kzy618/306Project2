using UnityEngine;
using System.Collections;

/*
 * Class for loading and saving player data and preferences 
 */ 
public class LoadOrSave : MonoBehaviour {

	public void LoadPlayerData () {
        SaveStateController.controller.LoadPlayerData();
    }

    public void SavePlayerData () {
        SaveStateController.controller.SavePlayerData();
    }

    public void DeletePlayerData()
    {
        SaveStateController.controller.DeletePlayerData();
    }

    public void LoadPlayerPref()
    {
        SaveStateController.controller.LoadPlayerPref();
    }

    public void SavePlayerPref()
    {
        SaveStateController.controller.SavePlayerPref();
    }

    public void DeletePlayerPref()
    {
        SaveStateController.controller.DeletePlayerPref();
    }

}
