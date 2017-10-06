using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NamePanelController : MonoBehaviour {
    public InputField nameField;
	
    // stores the new name
	public void SetNewName () {
        SaveStateController.controller.playerName = nameField.text;
    }

    // focuses the name field
    public void FocusNameField() {
        nameField.Select();
        nameField.ActivateInputField();
    }

}
