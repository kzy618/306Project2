using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerLifeController : MonoBehaviour {

    public int _maxLives = 5;
    public float invincibilityTime;
    public Text _lifeText;

    private int currentLives;
    private float currentInvincibilityTime;
    private bool invincible;
    private bool died;

    public Animator death;
    public Animator _damaged;

    private bool _crRunning;
    private Coroutine _cr;

    public int _secondsPerRegen = 3;

    private void Start()
    {
        currentLives = SaveStateController.controller.health;
        invincible = false;
        died = false;
    }

	// Update is called once per frame
	void Update () {
        //print(currentLives);
        _lifeText.text = "x" + currentLives;

        if (invincible)
        {
            currentInvincibilityTime += Time.deltaTime;
            if (currentInvincibilityTime > invincibilityTime)
            {
                invincible = false;
                currentInvincibilityTime = 0;
            }
        }

        if (!_crRunning)
        {
            _cr = StartCoroutine(startRegen());
        }

        if (currentLives <= 0 && !died)
        {
            StopCoroutine(_cr);
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
            _damaged.SetTrigger("PlayerDamaged");
            SaveStateController.controller.health--;
            currentLives = SaveStateController.controller.health;
            invincible = true;
            if (_crRunning)
            {
                _crRunning = false;
                StopCoroutine(_cr);
            }
        }      
    }
    
    public void healing()
    {
        if (currentLives < _maxLives)
        {
            Debug.Log(SaveStateController.controller.health);
            SaveStateController.controller.health++;
            currentLives = SaveStateController.controller.health;
            GetComponentInChildren<RegenSound>().Play();
            Debug.Log(SaveStateController.controller.health);
        }
    }

    IEnumerator startRegen()
    {
        _crRunning = true;
        yield return new WaitForSeconds(_secondsPerRegen);
        healing(); 
        _crRunning = false;
    }

	public void Death(){
		death.SetTrigger("PlayerDeath");
		currentLives = 0;
	}
}
