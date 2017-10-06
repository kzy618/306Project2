using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // Use this for initialization
    void Start () {
        count = 0;
        updateText();
    }
	
	// Update is called once per frame
	void Update () {
        if (count == dLines.Count && Input.anyKeyDown)
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
        if (count < dLines.Count)
        {
            dText.text = dLines[count];
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
}
