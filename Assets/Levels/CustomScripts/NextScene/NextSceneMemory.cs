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
            // save player's data here
            SaveStateController.controller.lastCheckpoint = _nextScene;
            SaveStateController.controller.SavePlayerData();

            SceneManager.LoadSceneAsync(_nextScene);
            _loaded = true;
        }
    }
}
