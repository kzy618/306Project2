using UnityEngine;
using System;
using System.Collections;

public class AnimationController : MonoBehaviour {
	
	private Animator animator;
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
		if (Input.GetKeyDown(KeyCode.Space) && !crawl)
		{
			animator.SetTrigger(jumpingHash);
		}
		else
		{
			int poseCounter = 0;
			if (Input.GetKey(KeyCode.LeftShift))
			{
				animator.SetBool(runningHash, true);
				poseCounter++;
			}
			else
			{
				animator.SetBool(runningHash, false);
			}
		
			if (Input.GetKeyDown(KeyCode.LeftControl))
			{
				couch = !couch;
				animator.SetBool(couchingHash, couch);
				if (couch)
				{
					poseCounter++;
				}
			}else if (Input.GetKeyDown(KeyCode.C))
			{
				crawl = !crawl;
				animator.SetBool(crawlingHash, crawl);
				if (crawl)
				{
					poseCounter++;
				}
			}

			if (poseCounter > 1)
			{
				animator.SetBool(runningHash, true);
				animator.SetBool(couchingHash, false);
				couch = false;
				animator.SetBool(crawlingHash, false);
				crawl = false;
			}
		
			float zmove = Input.GetAxis("Vertical");
			float xmove = Input.GetAxis("Horizontal");
			animator.SetFloat(xmov, xmove);
			animator.SetFloat(zmov, zmove);
		}
	}
}
