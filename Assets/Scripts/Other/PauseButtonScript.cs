using UnityEngine;
using System.Collections;

public class PauseButtonScript : MonoBehaviour {
	public Texture continuePlay;
	public Texture pause;
	private GameObject cam;
	private GameObject playmenu;
	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Camera");
		playmenu = GameObject.Find ("__PlayButtons");

	}

	
	// Update is called once per frame
	void Update () {

			if (guiTexture.HitTest (Input.mousePosition)) {						
			guiTexture.color = new Vector4(0.5f,1f,1f,0.5f);
				} else {
			guiTexture.color = Color.white;
			guiTexture.color = new Vector4(0.4f,0.4f,0.4f,0.4f);
				}
	}
	void OnMouseUp(){
		if (Time.timeScale != 0.0) {
						//stop time
						Time.timeScale = 0.0f;
						//disable camera
						cam.SetActive (false);
						playmenu.SetActive(false);
						//enable UIElements
						transform.FindChild ("_UIElements").gameObject.SetActive(true);						
						//change texture
						gameObject.guiTexture.texture=continuePlay;
						//show replay texture
						transform.FindChild("ReplayButton").gameObject.SetActive(true);
			
				}
		else{
			//restart time
			Time.timeScale = 1.0f;
			//disable camera
			cam.gameObject.SetActive (true);
			playmenu.SetActive(true);
			//enable UIElements
			transform.FindChild ("_UIElements").gameObject.SetActive(false);
			//change texture
			gameObject.guiTexture.texture=pause;
			//hide replay texture
			transform.FindChild("ReplayButton").gameObject.SetActive(false);
			
		}

	}

}
	