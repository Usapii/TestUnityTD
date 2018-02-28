using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class progressScript : MonoBehaviour {

	private int progress;
	public Slider progressBar;
	public Slider bossProgress;
	 
	// Use this for initialization
	void Start () {
		progress = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (SceneManager.GetActiveScene ().name);
		if (SceneManager.GetActiveScene ().name== "world1") {
			world1 ();
		} else if (SceneManager.GetActiveScene ().name == "world2") {
			world2 ();
		}
	}

	private void endScene(){
		progress = 0;
		SceneManager.LoadScene("world2");
	}


//------------ utils ---------
	private void world1() {
		progress += 1;
		progressBar.value = progress;
		if (progress >= progressBar.maxValue) {
			Invoke("endScene", 5f );
			GameObject.FindGameObjectWithTag("player").GetComponent<Rigidbody2D> ().velocity = new Vector2 (5, 0);
		}
	}

	private void world2(){
		progress += 1;
		bossProgress.value = progress;
	}
}
