    using UnityEngine;
    using System.Collections;
using UnityEngine.SceneManagement;

class NextSceneFromSecondLevel : NextScene
{
    public void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _memoryFound)
        {
            SceneManager.LoadScene("Level001_Spawn");
        }
    }
}
