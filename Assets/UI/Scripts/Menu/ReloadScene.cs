using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * Class for loading a specific scene
 */
public class ReloadScene : MonoBehaviour
{

    public void Reload()
    {
        Debug.Log("ts1");
        Time.timeScale = 1;
        SaveStateController.controller.health = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}