using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// AnimationController is the class responsible for controlling the animation state for the progatonist object.
/// The state of the animation is changed based on the user's inputs.
/// </summary>
public class AnimationController : MonoBehaviour {
	
	private Animator animator; // A reference to the Animator Component.
	private int runningHash = Animator.StringToHash("running");
	private int couchingHash = Animator.StringToHash("couching");
	private int crawlingHash = Animator.StringToHash("crawling");
	private int jumpingHash = Animator.StringToHash("jumping");
	private int xmov = Animator.StringToHash("xmovement");
	private int zmov = Animator.StringToHash("zmovement");

	private bool couch = false;
	private bool crawl = false;

	
	void Start ()
	{
		animator = GetComponent<Animator>();
	}


	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !crawl) //switch to jump animation
		{
			animator.SetTrigger(jumpingHash);
		}
		else
		{
			int poseCounter = 0;
			if (Input.GetKey(KeyCode.LeftShift)) //switch to sprint animation while shift is being held down by player
			{
				animator.SetBool(runningHash, true);
				poseCounter++;
			}
			else
			{
				animator.SetBool(runningHash, false);
			}
		
			if (Input.GetKeyDown(KeyCode.LeftControl)) //switch to crouching animation
			{
				couch = !couch;
				animator.SetBool(couchingHash, couch);
				if (couch)
				{
					poseCounter++;
				}
			}else if (Input.GetKeyDown(KeyCode.C)) //switch to crawling animation
			{
				crawl = !crawl;
				animator.SetBool(crawlingHash, crawl);
				if (crawl)
				{
					poseCounter++;
				}
			}

			if (poseCounter > 1) //if multiple input signals get fed in at once, running animation has the highest priority
			{
				animator.SetBool(runningHash, true);
				animator.SetBool(couchingHash, false);
				couch = false;
				animator.SetBool(crawlingHash, false);
				crawl = false;
			}
		
			//the protagonist stays idle if no movement signal detected, otherwise walking animation will be enabled.
			float zmove = Input.GetAxis("Vertical");
			float xmove = Input.GetAxis("Horizontal");
			animator.SetFloat(xmov, xmove);
			animator.SetFloat(zmov, zmove);
		}
	}
}
