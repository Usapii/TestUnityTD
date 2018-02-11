using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressScript : MonoBehaviour {

	private int progress;
	public Slider progressBar;
	 
	// Use this for initialization
	void Start () {
		progress = 0;
	}
	
	// Update is called once per frame
	void Update () {
		progress += 1;
		progressBar.value = progress;
		if (progress >= progressBar.maxValue) {
			endScene ();
		}
	}

	private void endScene(){
		//Animation de fin de lvl
		//Changement de Scene
		Debug.Log("FIN ! :P ");
	}
}
