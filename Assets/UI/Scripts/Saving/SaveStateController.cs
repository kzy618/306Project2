using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveStateController : MonoBehaviour {

    // static so that it's a Singleton class
    public static SaveStateController controller;

    public int health;

    // When the object gets loaded
    void Awake () {
        if (controller == null)
        {
            print("one");
            DontDestroyOnLoad(gameObject); // make the obj stay around forever
            controller = this; // the first created game controller will be the singleton
        }
        else if (controller != this)
        {
            print("two");
            // remove any other instances controller that's not the first one
            Destroy(gameObject);
        }
	}

    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        
        PlayerData data = new PlayerData(health);

        // serialize player data and store it to a file
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;

        }
    }

    public void Delete() {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/playerInfo.dat");
            health = 0;
        }
    }

}

// inner class that's serializable
[Serializable]
class PlayerData {
    public int health;
    public PlayerData(int healtData) {
        health = healtData;
    }
}
