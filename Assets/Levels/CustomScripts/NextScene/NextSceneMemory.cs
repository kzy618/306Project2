using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextSceneMemory : MonoBehaviour
{
    public string _nextScene;
    public bool _memoryFound;
    private bool _loaded;

    void Start()
    {
        _memoryFound = false;
        _loaded = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.ToString());
        if (other.gameObject.CompareTag("Player") && _memoryFound && !_loaded)
        {
            SceneManager.LoadSceneAsync(_nextScene);
            _loaded = true;
        }
    }
}
