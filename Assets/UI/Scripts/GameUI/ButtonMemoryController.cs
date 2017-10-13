using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonMemoryController : MonoBehaviour {

    public string _sceneName;

	public void replayScene()
    {
        // If the player has collected the memory then they are allowed to play the scene
        if (SaveStateController.controller._collectedMemories.ContainsKey(_sceneName) && (bool)SaveStateController.controller._collectedMemories[_sceneName] != false)
        {
            SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
        }
    }
}
