using UnityEngine;
using System.Collections;

public class GifScript : MonoBehaviour {

	public Texture[] textures;
	public int[] delayedFrames; //which frames to delay
	public int[] delayLength;	//how long the frames selected are delayed

	private int i;
	private int j;
	public int toNextFrame = 5;
	private int size;
	private	int delay = 0;
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
		//sustains frame for until the delay lasts before moving on to next frame
		j++;
		int delayIdx = isInDelayFrames (i);
		if (delayIdx != -1) {
			delay = delayLength [delayIdx];
		} else {
			delay = 0;
		}
		if (j >= toNextFrame + delay) {
			j = 0;
			i++;
			if (i >= size) {
				i = 0;
			}
		}


		Renderer rend = GetComponent<Renderer> ();
		rend.material.mainTexture = textures [i];
	}

	int isInDelayFrames(int frame){
		for (int i=0; i<delayedFrames.Length; i++) {
			if (frame == delayedFrames[i])
				return i;
		}
		return -1;
	}

}
