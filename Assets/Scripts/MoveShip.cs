using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour {

	public Vector2 speed ;	
	public Vector2 movement;
	private bool shoot;			//Allow shoot
	private float shootSpeed;	//Time of reload

	void Start () {
		shootSpeed = 0.5f;
		shoot = true;
	}


	void Update () {
		float inputY = Input.GetAxis ("Vertical");			//Get Direction
		Vector2 sz = GetComponent<BoxCollider2D> ().size;	//Get Size

		bool sp	= Input.GetKeyDown(KeyCode.Space); 			//Get KeyPressed
		if (sp && shoot) { 									//If space pressed
			Vector3 tmpPos = new Vector3 (transform.position.x + sz.x,	transform.position.y, transform.position.z); 
			GameObject bul = Instantiate (Resources.Load("Bullet"), tmpPos,Quaternion.identity) as GameObject;
			this.shoot = false;
			Invoke ("reload", this.shootSpeed);
		}
		movement = new Vector2 (0f, speed.y * inputY);

		GetComponent<Rigidbody2D> ().velocity = movement;	
	}

	void onTriggerEnter2D(Collider2D other){
		if (other.name != "Bullet") {
			if (GameObject.FindGameObjectWithTag ("life4")) {
				Destroy (GameObject.FindGameObjectWithTag ("life4"));
			}else if (GameObject.FindGameObjectWithTag ("life3")) {
				Destroy (GameObject.FindGameObjectWithTag ("life3"));
			}else if (GameObject.FindGameObjectWithTag ("life2")) {
				Destroy (GameObject.FindGameObjectWithTag ("life2"));
			}else if (GameObject.FindGameObjectWithTag ("life1")) {
				Destroy (GameObject.FindGameObjectWithTag ("life1"));
			}
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
