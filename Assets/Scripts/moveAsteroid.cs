using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAsteroid : MonoBehaviour {

	public Vector2 speed ;

	public Vector2 movement;

	public Vector3 leftTopCameraBorder;
	public Vector3 rightTopCameraBorder;
	public Vector3 rightBottomCameraBorder;

	// Use this for initialization
	void Start () {
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
	}

	// Update is called once per frame
	void Update () {
		//float inputY = Input.GetAxis ("Vertical");
		float sz= GetComponent<CircleCollider2D>().radius;

		if (GetComponent<Rigidbody2D>().position.x >= leftTopCameraBorder.x-sz/2) {
			movement = new Vector2(-(speed.x),0f );
			GetComponent<Rigidbody2D>().velocity = movement;
		}else{
			movement = GetComponent<Rigidbody2D>().position= new Vector2((rightBottomCameraBorder.x + sz/2),Random.Range(rightBottomCameraBorder.y+sz/2 ,leftTopCameraBorder.y-sz/2));
		}
		if (GameObject.FindGameObjectsWithTag("asteroid").Length < GameState.Instance.getMaxAst() && Random.Range(0,100)==90){
			GameObject ast = Instantiate (Resources.Load("asteroid"), new Vector3(rightBottomCameraBorder.x+sz/2,Random.Range(rightBottomCameraBorder.y+sz/2 ,leftTopCameraBorder.y-sz/2),0),Quaternion.identity) as GameObject;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Bullet" || other.name == "Ship" ){
			if (other.tag == "Bullet") {GameState.Instance.addMaxAst(1);}
			if (other.name == "Ship") {GameState.Instance.delMaxAst(1);}

			float sz= GetComponent<CircleCollider2D>().radius;
			GameObject ast = Instantiate (Resources.Load("asteroid"), new Vector3(rightBottomCameraBorder.x+sz/2,Random.Range(rightBottomCameraBorder.y+sz/2 ,leftTopCameraBorder.y-sz/2),0),Quaternion.identity) as GameObject;
			Destroy (gameObject);
		}
	}
}
