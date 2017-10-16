using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MemoryRotator : MonoBehaviour {

    public NextSceneMemory _memoryChecker;
    public Animator anim;
    public float animDuration;
    public string memory;

    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Time.timeScale != 0)
        {
            if (_memoryChecker != null)
            {
                _memoryChecker._memoryFound = true;
            }
            Time.timeScale = 0;
            SaveStateController.controller._collectedMemories.Add(memory, true);
            StartCoroutine(playFade(memory));
        }
    }


    IEnumerator playFade(string memoryToLoad)
    {
        anim.SetTrigger("FadeToMemory");
        var scene = SceneManager.LoadSceneAsync(memoryToLoad, LoadSceneMode.Additive);
        scene.allowSceneActivation = false;
        yield return CoroutineUtilities.WaitForRealTime(animDuration);
        scene.allowSceneActivation = true;
        this.gameObject.SetActive(false);
    }
}
