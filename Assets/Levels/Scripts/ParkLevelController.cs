using UnityEngine;
using System.Collections;

public class ParkLevelController : MonoBehaviour {

    public GameObject _laserShooter;
    public GameObject _memoryFragment;

	// Use this for initialization
	void Start () {
        _laserShooter.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (!_memoryFragment.activeSelf && !_laserShooter.activeSelf)
        {
            _laserShooter.SetActive(true);
        }
	}
}
