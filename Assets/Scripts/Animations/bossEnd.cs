using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossEnd : MonoBehaviour {

	private Vector2 width;
	private Vector2 height;
	private bool reload;

	void Start () {
		reload = true;
		Vector2 tmp=  GetComponent<SpriteRenderer> ().bounds.size;
		Vector2 pos = GetComponent<Rigidbody2D> ().position;
		width.x = pos.x-tmp.x/2f; width.y = pos.x+tmp.x/2f;  
		height.x = pos.y-tmp.y/2f; height.y = pos.y+tmp.y/2f;
		Invoke ("end", 3f);
	}


	void Update () {
		if (reload) {
			this.reload = false;
			GameObject ast = Instantiate (Resources.Load ("explosion"), new Vector3 (Random.Range(width.x,width.y),Random.Range(height.x,height.y), 0f), Quaternion.identity) as GameObject;
			Invoke("re", 0.05f);
		}
	}

	private void re(){
		this.reload = true;
	}

	private void end(){
		SceneManager.LoadScene("endScene");
	}
}
