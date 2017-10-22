using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class TransitionOnEnter : StateMachineBehaviour {

    public List<Sprite> _backgrounds;
    public float _framesPerSecond = 24;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float delay = 1 / _framesPerSecond;
        animator.gameObject.GetComponent<TransitionController>().Play(delay, _backgrounds);
    }

}
