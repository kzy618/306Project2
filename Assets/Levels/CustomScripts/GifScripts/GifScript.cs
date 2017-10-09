using UnityEngine;
using System.Collections;

public class GifScript : MonoBehaviour {

	public Texture[] textures;

	private int i;
	private int j;
	public int toNextFrame = 5;
	private int size;
	// Use this for initialization
	void Start () {
		size = textures.Length;
		Renderer rend = GetComponent<Renderer> ();
		rend.material.mainTexture = textures [0];

		i = 0;
		j = 0;
	}
	
	// Update is called once per frame
	void Update () {
		j++;
		if (j >= toNextFrame) {
			j = 0;
			i++;
			if (i >= size) {
				i = 0;
			}
		}

		Renderer rend = GetComponent<Renderer> ();
		rend.material.mainTexture = textures [i];
	}

}
