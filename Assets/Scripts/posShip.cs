using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posShip : MonoBehaviour {
	
	private Vector3 rightTopCameraBorder;
	private Vector3 leftBottomCameraBorder;

	// Use this for initialization
	void Start () {
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 0));
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
		Rigidbody2D comp= GetComponent<Rigidbody2D>() ;
		Vector2 pos = comp.position;
		Vector2 sz = GetComponent<BoxCollider2D> ().size;

		if (pos.y>rightTopCameraBorder.y-sz.y/2){
			comp.position= new Vector2(pos.x,rightTopCameraBorder.y-sz.y/2);
		}else if (pos.y<leftBottomCameraBorder.y+sz.y/2){
			comp.position= new Vector2 (pos.x,leftBottomCameraBorder.y+sz.y/2);
		}

		if (pos.x<leftBottomCameraBorder.x+sz.x/2){
			comp.position= new Vector2(leftBottomCameraBorder.x+sz.x/2,pos.y);
		}else if (pos.x>rightTopCameraBorder.y-sz.x/2){
			comp.position= new Vector2 (rightTopCameraBorder.y-sz.x/2,pos.y);
		}
	}
}
