using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ReviewMemory : MonoBehaviour {

    public List<string> _sceneNames;
    public List<string> _buttonNames;
    public Button _buttonPrefab;
    public AudioSource _bgm;

    void Update ()
    {
        for (int i = 0; i < _sceneNames.Count; i++)
        {
            if (SaveStateController.controller._collectedMemories.Contains(_sceneNames[i]))
            {
                // Instantiate a button prefab and then add it to the parent panel
                var btn = Instantiate(_buttonPrefab);
                btn.transform.SetParent(GetComponent<RectTransform>(), false);

                // Set the scene linked to the button, and rename the button to a more descriptive name
                btn.GetComponent<ButtonMemoryController>()._sceneName = _sceneNames[i];
                btn.GetComponentInChildren<Text>().text = _buttonNames[i];
                btn.GetComponent<ButtonMemoryController>()._bgm = _bgm;

                _sceneNames.RemoveAt(i);
                _buttonNames.RemoveAt(i);
                i--;
            }
        }
    }
}
