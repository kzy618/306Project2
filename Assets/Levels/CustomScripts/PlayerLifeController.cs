using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerLifeController : MonoBehaviour {

    public int maxLives;
    public float invincibilityTime;

    private int currentLives;
    private float currentInvincibilityTime;
    private bool invincible;

    private void Start()
    {
        currentLives = maxLives;
        invincible = false;
    }

	// Update is called once per frame
	void Update () {
        //print(currentLives);

        if (invincible)
        {
            currentInvincibilityTime += Time.deltaTime;

            if (currentInvincibilityTime > invincibilityTime)
            {
                invincible = false;
                currentInvincibilityTime = 0;
            }
        }

        if (currentLives <= 0)
        {
            // handle death
        }
	}

    public int lives()
    {
        return currentLives;
    }

    public void takeDamage()
    {
        if (!invincible)
        {
            currentLives--;
            invincible = true;
        }
        
    }
}
