using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/*
 * Singleton class that stores the player's state and preferences
 * - allows for querying of state
 * - allows for saving/loading/deleting of player data/preferences 
 */
public class SaveStateController : MonoBehaviour {

    // static so that it's a Singleton class
    public static SaveStateController controller;

    public static string PLAYER_DATA_FILENAME = Application.persistentDataPath + "/playerInfo.dat";
    public static string PLAYER_PREFERENCES_FILENAME = Application.persistentDataPath + "/playerPref.dat";

    // PLAYER DATA
    // player's health
    public string playerName;
    public int health;

    // PLAYER PREFERENCES
    // master volume
    public float masterVol;

    // When the object gets loaded
    void Awake () {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject); // make the obj stay around forever
            controller = this; // the first created game controller will be the singleton
                               
            LoadPlayerPref(); // loads player preferences at the start
        }
        else if (controller != this)
        {
            // remove any other instances controller that's not the first one
            Destroy(gameObject);
        }
	}

    public void SavePlayerData() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(PLAYER_DATA_FILENAME);
        
        PlayerData data = new PlayerData();
        // Save the data here
        data.health = health;
        data.playerName = playerName;

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadPlayerData() {
        if (File.Exists(PLAYER_DATA_FILENAME)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(PLAYER_DATA_FILENAME, FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            // Load the data here
            health = data.health;
            playerName = data.playerName;

        }
    }

    public void DeletePlayerData() {
        if (File.Exists(PLAYER_DATA_FILENAME))
        {
            File.Delete(PLAYER_DATA_FILENAME);
            health = 0;
        }
    }

    public void SavePlayerPref()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(PLAYER_PREFERENCES_FILENAME);

        PlayerPref pref = new PlayerPref();

        // Save the data here
        pref.masterVol = masterVol;

        bf.Serialize(file, pref);
        file.Close();
    }

    public void LoadPlayerPref()
    {
        if (File.Exists(PLAYER_PREFERENCES_FILENAME))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(PLAYER_PREFERENCES_FILENAME, FileMode.Open);
            PlayerPref pref = (PlayerPref)bf.Deserialize(file);
            file.Close();

            // Load the data here
            masterVol = pref.masterVol;

        }
    }

    public void DeletePlayerPref()
    {
        if (File.Exists(PLAYER_PREFERENCES_FILENAME))
        {
            File.Delete(PLAYER_PREFERENCES_FILENAME);

            // Reset the data here
            masterVol = 1;
        }
    }
}

[Serializable]
class PlayerData {
    public int health;
    public string playerName;
}

[Serializable]
class PlayerPref
{
    public float masterVol;
}

