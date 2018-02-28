using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossEntranceBar : MonoBehaviour {

	private int progress;
	public Slider progressBar;
	private bool gone=true;

	// Use this for initialization
	void Start () {
		progress = 0;
	}

	void Update () {
		progress += 1;
		progressBar.value = progress;
		if (progress >= progressBar.maxValue && gone) {
			GameObject.FindGameObjectWithTag("Paryss").GetComponent<BossEntrance> ().SendGo ();
			this.gone = false;
		}
	}
}
