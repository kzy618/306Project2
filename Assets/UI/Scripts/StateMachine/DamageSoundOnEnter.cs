using UnityEngine;
using System.Collections;

/*
 * Class that plays a sound when player has been damaged
 */
public class DamageSoundOnEnter : StateMachineBehaviour
{
    // when damaged state has been reached
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // play sound
        animator.gameObject.GetComponent<AudioSource>().Play();
    }

}
