using UnityEngine;
using System.Collections;

public class ReplayLevel : MonoBehaviour {

	void Update () {

	}
	// Use this for initialization
	public void OnMouseUpReplay(){
		Time.timeScale = 1.0f;
		Application.LoadLevel (Application.loadedLevelName);
	}
}
