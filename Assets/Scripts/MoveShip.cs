using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour {

	public Vector2 speed ;	
	public Vector2 movement;
	private bool shoot;			//Allow shoot
	private float shootSpeed;	//Time of reload
	private playerState  player;

	void Start () {
		shootSpeed = 0.5f;
		shoot = true;
		player = GetComponent<playerState> ();
	}


	void Update () {
		float inputY = Input.GetAxis ("Vertical");			//Get Direction vert
		float inputX = Input.GetAxis ("Horizontal");		//Get Direction horiz
		Vector2 sz = GetComponent<BoxCollider2D> ().size;	//Get Size

		bool sp	= Input.GetKeyDown(KeyCode.Space); 			//Get KeyPressed
		if (sp && shoot) { 									//If space pressed
			Vector3 tmpPos = new Vector3 (transform.position.x + sz.x,	transform.position.y, transform.position.z); 
			GameObject bul = Instantiate (Resources.Load("Bullet"), tmpPos,Quaternion.identity) as GameObject;
			this.shoot = false;
			Invoke ("reload", this.shootSpeed);
		}
		movement = new Vector2 (speed.x * inputX, speed.y * inputY);

		GetComponent<Rigidbody2D> ().velocity = movement;	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag != "Bullet") {
			player.Damage (10);
		}
	}

	public void reload(){
		this.shoot = true;
	}

	public void optimizeReload(){
		if (this.shootSpeed>0){
			this.shootSpeed = this.shootSpeed - 0.05f;
		}
	}
}
