using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * Class for loading a specific scene
 */ 
public class LoadOnScreenClick : MonoBehaviour
{
    public string sceneName;
    public void LoadByIndex()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}