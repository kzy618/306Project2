using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnScreenClick : MonoBehaviour
{
    public int sceneNo;
    public void LoadByIndex()
    {
        SceneManager.LoadScene(sceneNo);
    }
}