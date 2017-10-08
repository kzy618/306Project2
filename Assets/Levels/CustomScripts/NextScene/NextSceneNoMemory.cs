using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextSceneNoMemory : MonoBehaviour {

    public string _nextScene;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            SceneManager.LoadScene(_nextScene);
        }
    }
}
