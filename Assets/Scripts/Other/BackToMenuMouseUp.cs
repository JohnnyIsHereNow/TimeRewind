using UnityEngine;
using System.Collections;

public class BackToMenuMouseUp : MonoBehaviour {

	void Update () {
		if (guiTexture.HitTest (Input.mousePosition)) {						
			guiTexture.color = new Vector4(0.5f,1f,1f,0.5f);
		} else {
			guiTexture.color = Color.white;
			guiTexture.color = new Vector4(0.4f,0.4f,0.4f,0.4f);
		}
	}
	// Use this for initialization
	void OnMouseUp(){
		Time.timeScale = 1.0f;
		Application.LoadLevel ("loadWorldScene");
	}
}
