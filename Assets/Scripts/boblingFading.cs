using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boblingFading : MonoBehaviour {

	public bool bob;			//Allow the script to make the object bobbing
	public bool fade;			//Allow the script to make the object FadeIn and FadeOut

	private float valBob; 		//value of Bobing
	private float valFade;		//value of fading
	private bool cdBob =true;	//bobing is rising or decreasing
	private bool cdFade =true;	//fade is fadedin or fadedout

	/**
	 * Improvement:
	 * 	Precise speed of boboing / fading
	 * 	Precise limit of boboing / fading
	 */

	void Start () {
		if (bob) valBob = 0f;
		if (fade)valFade = 0.9f;
	}
	
	void Update () {

		if (bob) {
			if (cdBob && valBob < 0.02f) {
				valBob += 0.0005f;
			} else if (!cdBob && valBob > -0.02f) {
				valBob -= 0.0005f;
			} else {
				cdBob = !cdBob;
			}

			Vector2 sz = gameObject.transform.localScale;
			gameObject.transform.localScale = new Vector2 (sz.x + valBob , sz.y + valBob);
		}

		if (fade) {
			if (cdFade && valFade < 0.9f) {
				valFade += 0.007f;
			} else if (!cdFade && valFade > 0.3f) {
				valFade -= 0.007f;
			} else {
				cdFade = !cdFade;
			}

			gameObject.GetComponent<SpriteRenderer> ().material.color=new Color(1.0f,1.0f,1.0f,valFade);
		}
	}
}
