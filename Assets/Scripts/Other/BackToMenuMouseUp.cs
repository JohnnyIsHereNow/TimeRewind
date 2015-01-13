using UnityEngine;
using System.Collections;

public class BackToMenuMouseUp : MonoBehaviour {

	void Update () {

	}
	// Use this for initialization
	public void OnMouseUpMenu(){
		Time.timeScale = 1.0f;
		Application.LoadLevel ("loadWorldScene");
	}
}
