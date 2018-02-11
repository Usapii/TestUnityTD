using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerState : MonoBehaviour {

	public int maxHealth = 100;
	public int hp;
	public Slider hpSlider;
	//public Image damage //image à afficher en cas de dommages

	AudioSource audioDamage;
	bool isDead;
	bool damaged;
	// Use this for initialization
	void Awake () {
		hp = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Damage(int d){
		damaged = true;
		hp = hp - d;
		hpSlider.value = hp;
		//Jouer le son de dommage
		if (hp <= 0 && !isDead) {
			Death ();
		}
	}

	public void Death(){
		isDead = true;
		GetComponent<MoveShip> ().enabled = false;
		GetComponent<posShip> ().enabled = false;
		gameObject.AddComponent<DeathMove>();
	}
}
