using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	public static GameState Instance;
	private int maxAsteroid;

	void Start () {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (Instance.gameObject);
		}
		else if (this != Instance) {
			Destroy (this.gameObject);
		}

		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name == "world1") {
			GameState.Instance.maxAsteroid = 10;
		} else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name == "Scene2") {
			GameState.Instance.maxAsteroid = 18;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int  getMaxAst(){
		return this.maxAsteroid;
	}

	public void addMaxAst(int a){
		this.maxAsteroid += a;
	}
}
