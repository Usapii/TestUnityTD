using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveComet : MonoBehaviour {

	public Vector2 speed ;

	public Vector2 movement;

	public Vector3 leftTopCameraBorder;
	public Vector3 rightTopCameraBorder;
	public Vector3 rightBottomCameraBorder;

	void Start () {
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, 0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, 0));
	}

	void Update () {
		float sz= GetComponent<CircleCollider2D>().radius;

		if (GetComponent<Rigidbody2D>().position.x >= leftTopCameraBorder.x-sz/2) {
			movement = new Vector2(-(speed.x),0f );
			GetComponent<Rigidbody2D>().velocity = movement;
		}else{
			Destroy (gameObject);
		}
	}
}
