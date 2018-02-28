using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEntrance : MonoBehaviour {

	public bool rightSide; //Make the boss enter by the right side of the screen (true), or the left side (false)
	private bool go;
	public float margin;

	private Vector2 leftBottomCamera;
	private Vector2 rightTopCamera;
	private float transparency;

	void Awake(){
		go = false;
		transparency = 0f;
		GetComponent<SpriteRenderer> ().color= new Color (1f, 1f, 1f, 0f);
	}

	void Start () {
		leftBottomCamera = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		rightTopCamera = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
	}
	
	void Update () {
		if (go) {
			move ();
			fadein ();
		}
	}

	//----------------------- utils ---------------------------

	void move(){
		if (rightSide){
			Vector2 pos = GetComponent<Rigidbody2D> ().transform.position;
			Vector2 size = GetComponent<SpriteRenderer> ().bounds.size;
			if (pos.x > rightTopCamera.x - (size.x * margin)) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-2, 0);
			} else {
				GetComponent<Rigidbody2D> ().velocity=new Vector2(0,0);
				if (gameObject.GetComponent<bossAttacks>()==null) gameObject.AddComponent<bossAttacks> ();
				Invoke ("end", 1f);
			}
		}else{
			Vector2 pos = GetComponent<Rigidbody2D> ().transform.position;
			Vector2 size = GetComponent<SpriteRenderer> ().bounds.size;
			if (pos.x < leftBottomCamera.x + (size.x * margin)) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (2, 0);
			} else {
				GetComponent<Rigidbody2D> ().velocity=new Vector2(0,0);
				if (gameObject.GetComponent<bossAttacks>()==null) gameObject.AddComponent<bossAttacks> ();
				Invoke ("end", 1f);
			}
		}
	}

	void fadein(){
		transparency += 0.002f;
		GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, transparency);
	}

	public void SendGo(){ //use it to launch animation
		this.go = true;
	}

	void end(){
		Destroy (this);
	}
}
