using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HintTriggerController : MonoBehaviour {
    public Text _memoryFragmentHintText;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _memoryFragmentHintText.text = "You should collect continue exploring before proceeding";
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
