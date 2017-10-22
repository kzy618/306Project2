using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour {

    private float _delay;
    private List<Sprite> _backgrounds;
    private bool _triggered = false;

    private void LoadNextScene()
    {
        Debug.Log("Load");
        if (!_triggered)
        {
            _triggered = true;
            gameObject.GetComponent<Animator>().SetTrigger("StartGame");
        }
    }
    IEnumerator PlayTransition()
    {
        for (int i = 0; i < _backgrounds.Count; i++)
        {
            gameObject.GetComponent<Image>().sprite = _backgrounds[i];
            yield return new WaitForSeconds(_delay);
        }
        LoadNextScene();
    }

    public void Play(float delay, List<Sprite> backgrounds)
    {
        _backgrounds = backgrounds;
        _delay = delay;
        StartCoroutine(PlayTransition());
    }
}
