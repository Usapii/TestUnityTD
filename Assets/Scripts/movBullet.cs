using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movBullet : MonoBehaviour {

	public Vector2 speed ;
	public Vector2 movement;

	public Vector3 leftTopCameraBorder;
	public Vector3 rightTopCameraBorder;
	public Vector3 rightBottomCameraBorder;


	// Use this for initialization
	void Start () {
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
	}

	// Update is called once per frame
	void Update () {
		//float inputY = Input.GetAxis ("Vertical");
		Vector2 sz= GetComponent<BoxCollider2D>().size;
		if (GetComponent<Rigidbody2D>().position.x > rightTopCameraBorder.x-sz.x/2 || GetComponent<Rigidbody2D>().position.x < leftTopCameraBorder.x-sz.x/2) {
			Destroy(gameObject);
		}else{
			GetComponent<Rigidbody2D>().velocity = new Vector2(speed.x,0f );
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name != "Ship" && other.name != "Bullet(Clone)" && other.tag!="Paryss" && other.tag != "Laser") {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
