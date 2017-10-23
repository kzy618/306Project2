using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class DialogueController : MonoBehaviour {

    public Text dText;
    public Text nextText;
    public Image charA;
    public Image charB;
    public Image bg;
    public Sprite blank;
    public List<string> dLines;
    public List<Sprite> imagesA;
    public List<Sprite> imagesB;
    public List<Sprite> backgrounds;
    private int count;
    //public LoadOnScreenClick loader;
    //public LoadOrSave saveLoader;
    public string sceneName;
    public float delay = 0.1f;
    private Coroutine cr;
    private Boolean cr_running;
    private Color faded = new Color(1f, 1f, 1f, 0.5f);
    private Color shaded = new Color(1f, 1f, 1f, 1.0f);
    private Boolean charAInFocus = true;
    public Animator anim;
    public float animDuration = 0.9f;
    public string exitText = "Press Any Key to Return...";

    // Use this for initialization
    void Start () {
        count = 0;
        updateText();
    }
	
	// Update is called once per frame
	void Update () {
        // If the dialogue has finished playing, then prepare to close the cutscene
        if (count == dLines.Count && Input.anyKeyDown && !cr_running)
        {
            StartCoroutine(fadeOut());
        }else if (Input.GetKeyDown(KeyCode.Space)) // Otherwise continue displaying dialogue
        {
            Debug.Log(count);
            updateText();
        }
	}
    
    // Updates the text to show in the textbox, starts a coroutine to display letters of a message in order, if called again, the coroutine finishes early
    private void updateText()
    {
        if (cr_running)
        {
            StopCoroutine(cr);
            dText.text = dLines[count - 1];
            cr_running = false;

        } else if (count < dLines.Count)
        {
            processText();
            cr = StartCoroutine(ShowText(dLines[count]));
            updateImages();

            count++;
            
            if (count == dLines.Count)
            {
                nextText.text = exitText;
            }
        }
    }

    // Replaces the special "@" character with the player's name
    private void processText()
    {
        Debug.Log(SaveStateController.controller.playerName + " name");
        Debug.Log(dLines[count]);
        dLines[count] = dLines[count].Replace("@", SaveStateController.controller.playerName);
    }

    // Updates the images of the two characters in a cutscene
    private void updateImages()
    {
        if (backgrounds[count] != null)
        {
            bg.sprite = backgrounds[count];
        }

        if (imagesB[count] != null)
        {
            charB.sprite = imagesB[count];
            charAInFocus = false;
        }

        if (imagesA[count] != null)
        {
            Debug.Log("chg");
            charA.sprite = imagesA[count];
            charAInFocus = true;
        }

        if (charA.sprite == blank) {
            charAInFocus = false;
        }
        if (charB.sprite == blank)
        {
            charAInFocus = true;
        }


        if (charAInFocus)
        {
            charA.color = shaded;
            charB.color = faded;
        } else
        {
            charA.color = faded;
            charB.color = shaded;
        }
    }

    // Used to create a typewriter effect in text box
    IEnumerator ShowText(string fullText)
    {
        cr_running = true;
        for (int i = 0; i <= fullText.Length; i++)
        {
            dText.text = fullText.Substring(0, i);
            yield return StartCoroutine(CoroutineUtilities.WaitForRealTime(delay));
        }
        Debug.Log("false");
        cr_running = false;
    }

    // Sets a trigger to the animator to play a fading out effect
    IEnumerator fadeOut()
    {
        anim.SetTrigger("FadeToMemory");
        yield return CoroutineUtilities.WaitForRealTime(animDuration);
        SceneManager.UnloadScene(sceneName);
        Time.timeScale = 1;
    }
}
