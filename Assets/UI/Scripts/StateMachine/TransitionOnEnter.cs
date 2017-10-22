using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class TransitionOnEnter : StateMachineBehaviour {

    private Image _bg;
    public Sprite _initialBg;
    public List<Sprite> _backgrounds;
    private Animator _anim;
    public int _framesPerUpdate = 5;
    private int _delay;
    private int _count = 0;
    private bool _triggered = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bg = animator.gameObject.GetComponent<Image>();
        _bg.sprite = _initialBg;
        _delay = _framesPerUpdate;
        _anim = animator;
    }

    // Update is called once per frame
    void OnStateUpdate()
    {
        _delay--;
        if (_delay == 0)
        {
            _delay = _framesPerUpdate;
            if (_count < _backgrounds.Count)
            {
                _bg.sprite = _backgrounds[_count];
                _count++;
            }
            else
            {
                LoadNextScene();
            }
        }
    }

    private void LoadNextScene()
    {
        Debug.Log("Load");
        if (!_triggered) {
            _triggered = true;
            _anim.SetTrigger("StartGame");
        }
    }
}
