using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchGame : MonoBehaviour {

	void Start(){
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener (onClick);
	}

	public void onClick(){
		SceneManager.LoadScene("world1");
	}

	public void TaskOnClick(){
		Debug.Log ("TAMER");
	}


}
