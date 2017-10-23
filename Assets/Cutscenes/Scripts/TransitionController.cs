using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour {

    private float _delay;
    private List<Sprite> _backgrounds;
    private bool _triggered = false;

    // Loads the next scene once the animation finishes
    private void LoadNextScene()
    {
        Debug.Log("Load");
        if (!_triggered)
        {
            _triggered = true;
            gameObject.GetComponent<Animator>().SetTrigger("StartGame");
        }
    }

    // Used in a coroutine to change images based on the delay
    IEnumerator PlayTransition()
    {
        for (int i = 0; i < _backgrounds.Count; i++)
        {
            gameObject.GetComponent<Image>().sprite = _backgrounds[i];
            yield return new WaitForSeconds(_delay);
        }
        LoadNextScene();
    }

    // Begins playing the set of images as an animation
    public void Play(float delay, List<Sprite> backgrounds)
    {
        _backgrounds = backgrounds;
        _delay = delay;
        StartCoroutine(PlayTransition());
    }
}
