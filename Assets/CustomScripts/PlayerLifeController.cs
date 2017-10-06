using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLifeController : MonoBehaviour {

    public int maxLives;
    public float invincibilityTime;
    public Text text;

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
        text.text = "Lives: " + currentLives;
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
            // replace with game over screen??
            text.text = "ur ded";
        }
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
