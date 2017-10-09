using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * Class with method that loads the main menu scene when entering Menu state in an animation 
 */
public class MenuOnEnter : StateMachineBehaviour
{

    // when menu state is reached
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Menu();
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
