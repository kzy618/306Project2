using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

    public Text dText;
    public Text nextText;
    public List<string> dLines;
    private int count;
    public LoadOnScreenClick loader;
    public LoadOrSave saveLoader;

    // Use this for initialization
    void Start () {
        count = 0;
        updateText();
    }
	
	// Update is called once per frame
	void Update () {
        if (count == dLines.Count && Input.anyKeyDown)
        {
            saveLoader.Load();
            loader.LoadByIndex();
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
            count++;
            if (count == dLines.Count)
            {
                nextText.text = "Press Any Key to Return...";
            }
        }
    }
}
