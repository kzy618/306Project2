using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/*
 * Class meant for menu button selection with keyboard
 */ 
public class SelectOnInput : MonoBehaviour
{

    public EventSystem eventSystem;
    public GameObject selectedObject;

    private bool buttonSelected;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
    }

    private void OnDisable()
    {
        buttonSelected = false;
    }
}