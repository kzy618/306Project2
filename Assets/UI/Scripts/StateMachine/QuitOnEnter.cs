using UnityEngine;
using System.Collections;

/*
 * Class with Quit method to be called when entering Quit state in an animation 
 */
public class QuitOnEnter : StateMachineBehaviour
{
    // when quit state reached
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Quit();
    }

    public void Quit()
    {
        // save player preferences when quitting the game
        new LoadOrSave().SavePlayerPref();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
