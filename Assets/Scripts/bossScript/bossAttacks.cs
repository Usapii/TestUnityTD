using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttacks : MonoBehaviour {

	private int state = 0;
	private int life = 100;
	private bool next = true;
	private Vector2 destination; // if not set variate beetween top-0.5 skull and bottom +0.5 skull
	private bool goTop=true;
	private int speed=1;

	private Vector2 TopLeftCorner;
	private Vector2 RightBottomCorner;
	private Vector3 size;

	void Start () {
		foreach(GameObject tmp in GameObject.FindGameObjectsWithTag("asteroid")){
			Destroy (tmp);
		}
		TopLeftCorner = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		RightBottomCorner = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
		size = GetComponent<SpriteRenderer> ().bounds.size;
	}
	
	void Update () {
		if (state == 0) {
			phase1 ();
		} else if (state == 1) {
			phase2 ();
		}
		velocityToDestination ();
	}

	void OnTriggerEnter2D(Collider2D other){
		//TODO: desincrémenté life si collider avec bullet
		if (other.tag=="Bullet"){
			life -= 2;
			if (life < 50)speed = 2;
			GetComponent<Animator> ().SetInteger("life", life);
			GetComponent<SpriteRenderer> ().color = new Color (0.7f,0.3f,0.3f,1f);
			Invoke ("healedFont", 0.2f);

			if (life <= 0) {
				if (gameObject.GetComponent<bossEnd>() == null) gameObject.AddComponent<bossEnd> ();
				this.enabled = false;
			}
		}
	}
	void healedFont(){ //change the font back to normal
		GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f,1f);
	}


//-------------- BossPhases -----------
	void phase1(){
		int rand = Random.Range (0, 1000);
		if (rand > 990) {
			sendLaser ();
			Invoke ("sendLaser", 0.2f);
			Invoke ("sendLaser", 0.4f);
		} else if (rand >= 985) {
			sendAsteroid ();
			Invoke ("sendAsteroid", 0.2f);
			Invoke ("sendAsteroid", 0.4f);
		} 
		if (this.life <= 50)this.state = 1;
	}

	void phase2(){
		int rand = Random.Range (0, 1000);
		if (rand > 980) {
			sendLaser ();
			Invoke ("sendLaser", 0.1f);
			Invoke ("sendLaser", 0.2f);
		} else if (rand >= 970) {
			sendAsteroid ();
			Invoke ("sendAsteroid", 0.1f);
			Invoke ("sendAsteroid", 0.2f);
		}
	}

//---------------- utils ---------------
	void velocityToDestination(){
		if (this.destination != null) {
			Vector2 pos = GetComponent<Rigidbody2D> ().transform.position;
			if (pos.y <= TopLeftCorner.y-size.y/2 && goTop) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed);
			} else if (pos.y > RightBottomCorner.y+size.y/2 && !goTop) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -speed);
			} else {
				goTop = !goTop;
			}
		}
	}

	private void sendAsteroid(){
		Vector2 pos = GetComponent<Rigidbody2D> ().transform.position;
		GameObject ast = Instantiate (Resources.Load("comet"), new Vector3(pos.x*0.95f,pos.y-(size.y*0.22f),0f),Quaternion.identity) as GameObject;
	}
	private void sendLaser(){
		Vector2 pos = GetComponent<Rigidbody2D> ().transform.position;
		GameObject ast = Instantiate (Resources.Load("Laser"), new Vector3(pos.x,pos.y+(size.y*0.2f),0f),Quaternion.identity) as GameObject;
	}
}
