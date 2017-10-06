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
    public List<string> dLines;
    public List<Sprite> imagesA;
    public List<Sprite> imagesB;
    private int count;
    //public LoadOnScreenClick loader;
    //public LoadOrSave saveLoader;
    public string sceneName;
    public float delay = 0.1f;
    private Coroutine cr;
    private Boolean cr_running;

    // Use this for initialization
    void Start () {
        count = 0;
        updateText();
    }
	
	// Update is called once per frame
	void Update () {
        if (count == dLines.Count && Input.anyKeyDown && !cr_running)
        {
            SceneManager.UnloadScene(sceneName);
            Time.timeScale = 1;
            //saveLoader.Load();
            //loader.LoadByIndex();
        }else if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(count);
            updateText();
        }
	}

    private void updateText()
    {
        if (cr_running)
        {
            StopCoroutine(cr);
            dText.text = dLines[count - 1];
            cr_running = false;

        } else if (count < dLines.Count)
        {
            cr = StartCoroutine(ShowText(dLines[count]));
            if (imagesA[count] != null)
            {
                Debug.Log("chg");
                charA.sprite = imagesA[count];
            }
            if (imagesB[count] != null)
            {
                charB.sprite = imagesB[count];
            }

            count++;
            
            if (count == dLines.Count)
            {
                nextText.text = "Press Any Key to Return...";
            }
        }
    }

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
}
