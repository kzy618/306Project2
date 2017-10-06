using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuOnEnter : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Menu();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
