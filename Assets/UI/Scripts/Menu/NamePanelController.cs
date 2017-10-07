using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NamePanelController : MonoBehaviour {
    public InputField nameField;
    public Button confirmButton;

    void Start()
    {
        // change the input field to "" to disable confirm button
        nameField.text = "Hi";
        nameField.text = "";
    }

    // stores the new name
    public void SetNewName () {
        SaveStateController.controller.playerName = nameField.text;
    }

    // disables the confirm button if the username field is blank
    public void ReconfigureConfirmButton() {
        if (nameField.text.Trim() == "")
        {
            confirmButton.interactable = false;
        }
        else {
            confirmButton.interactable = true;

        }
    }

    // focuses the name field
    public void FocusNameField() {
        nameField.Select();
        nameField.ActivateInputField();
    }

}
