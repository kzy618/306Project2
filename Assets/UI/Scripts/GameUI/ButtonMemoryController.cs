using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonMemoryController : MonoBehaviour {

    public string _sceneName;
    public AudioSource _bgm;

    public void replayScene()
    {
        // If the player has collected the memory then they are allowed to play the scene
        if (SaveStateController.controller._collectedMemories.ContainsKey(_sceneName) && (bool)SaveStateController.controller._collectedMemories[_sceneName] != false)
        {
            _bgm.Pause();
            SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
            StartCoroutine(resumeBGM());
        }
    }

    IEnumerator resumeBGM()
    {
        while (Time.timeScale == 0)
        {
            Debug.Log("hello");
            yield return 0;
        }
        _bgm.UnPause();
    }
}
