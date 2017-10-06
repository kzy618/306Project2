using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * Class for loading a specific scene
 */ 
public class LoadOnScreenClick : MonoBehaviour
{
    public int sceneNo;
    public void LoadByIndex()
    {
        SceneManager.LoadScene(sceneNo);
    }
}