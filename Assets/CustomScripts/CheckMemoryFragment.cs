using UnityEngine;
using System.Collections;

public class CheckMemoryFragment : MonoBehaviour {

    public GameObject _door;
    public bool _memoryFound;

    private void Start()
    {
        _memoryFound = false;
    }

    void OnTriggerEnter (Collider other)
    {
        Debug.Log(other.ToString());
        Debug.Log(_memoryFound);
        if (other.gameObject.CompareTag("Player") && _memoryFound)
        {
            _door.SetActive(false);
        }
    }
}
