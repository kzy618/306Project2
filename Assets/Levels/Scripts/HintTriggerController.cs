using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Sets a warning text to the player
 *  if they attempt to enter an area without having collected a required fragment yet
 */
public class HintTriggerController : MonoBehaviour {
    public Text _memoryFragmentHintText;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _memoryFragmentHintText.text = "You should collect the memory fragment before proceeding";
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _memoryFragmentHintText.text = "";
        }
    }
}
