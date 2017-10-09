using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class NextSceneCredits : NextSceneMemory
{
    public GameObject fpsController;

    public override void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.ToString());
        if (other.gameObject.CompareTag("Player") && _memoryFound && !_loaded)
        {
            // save player's data here
            SaveStateController.controller.lastCheckpoint = _nextScene;
            SaveStateController.controller.SavePlayerData();
            fpsController.GetComponent<FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadSceneAsync(_nextScene);
            _loaded = true;
        }
    }
}
