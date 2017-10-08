using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextSceneFromSpawn : NextScene
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _memoryFound)
        {
            SceneManager.LoadScene("Lvl01Puzzle04");
        }
    }
}
