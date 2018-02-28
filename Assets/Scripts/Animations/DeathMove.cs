using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMove : MonoBehaviour {

	private bool end;
	private Animator shipAnim;

	// Use this for initialization
	void Start () {
		end = false;
		shipAnim=gameObject.GetComponent<Animator> ();
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (6f, -0.5f);
		Invoke ("End", 1.4f);
	}
	
	// Update is called once per frame
	void Update () { 
		if (!end) {
			Vector2 velo = gameObject.GetComponent<Rigidbody2D> ().velocity;
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velo.x - 0.05f, velo.y - 0.05f);
		} else {
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (1, -1);
		}
	}

	public void End(){
		this.end = true;
		shipAnim.SetBool ("dying",true);
		Invoke ("newGame", 1f);
	}

	private void newGame(){
		SceneManager.LoadScene("SceneStart");
	}

}
