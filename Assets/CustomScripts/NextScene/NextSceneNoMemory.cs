using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextSceneNoMemory : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            SceneManager.LoadScene("level001_second_floor");
        }
    }
}
