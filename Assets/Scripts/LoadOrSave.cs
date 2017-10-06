using UnityEngine;
using System.Collections;

public class LoadOrSave : MonoBehaviour {

	public void Load () {
        SaveStateController.controller.Load();
    }

    public void Save () {
        SaveStateController.controller.Save();
    }

    public void Delete()
    {
        SaveStateController.controller.Delete();
    }
}
