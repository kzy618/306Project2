using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextSceneMemory : MonoBehaviour
{
    public string _nextScene;
    public bool _memoryFound;

    void Start()
    {
        _memoryFound = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.ToString());
        if (other.gameObject.CompareTag("Player") && _memoryFound)
        {
            SceneManager.LoadScene(_nextScene);
        }
    }
}
