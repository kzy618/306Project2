using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using System;

public class PlayerLifeController : MonoBehaviour {

    public int maxLives;
    public float invincibilityTime;
    public Text lifeText;

    private int currentLives;
    private float currentInvincibilityTime;
    private bool invincible;
    private bool died;

    public Animator death;

    private void Start()
    {
        currentLives = SaveStateController.controller.health;
        invincible = false;
        died = false;
    }

	// Update is called once per frame
	void Update () {
        //print(currentLives);
        lifeText.text = "x" + currentLives;

        if (invincible)
        {
            currentInvincibilityTime += Time.deltaTime;

            if (currentInvincibilityTime > invincibilityTime)
            {
                invincible = false;
                currentInvincibilityTime = 0;
            }
        }

        if (currentLives <= 0 && !died)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GetComponent<FirstPersonController>().enabled = false;
            Time.timeScale = 0;
            Debug.Log("ts0");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            died = true;
            death.SetTrigger("PlayerDeath");
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
			SaveStateController.controller.health--;
			currentLives = SaveStateController.controller.health;
            invincible = true;
        }
        
    }
    
    public void healing()
    {
		Debug.Log (SaveStateController.controller.health);
        SaveStateController.controller.health++;
        currentLives = SaveStateController.controller.health;
		Debug.Log (SaveStateController.controller.health);
    }
}
