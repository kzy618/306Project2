using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// This class changes the texture of the memory fragment to the given background image
public class FragmentTextureMaker : MonoBehaviour {

    public Texture _background;

	void Start () {
        if (_background)
        {
            GetComponent<MeshRenderer>().materials[0].mainTexture = _background;
        }
	}

}
