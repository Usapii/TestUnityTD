using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("end", 0.5f);
	}

	void end(){
		Destroy (gameObject);	
	}
}
