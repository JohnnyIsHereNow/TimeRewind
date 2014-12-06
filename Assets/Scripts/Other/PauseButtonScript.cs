using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PauseButtonScript : MonoBehaviour {
	public Texture continuePlay;
	public Texture pause;
	private GameObject cam;
	private GameObject playmenu;
	private GameObject text;
	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Camera");
		playmenu = GameObject.Find ("__PlayButtons");
		text=GameObject.Find("TextInformation");
		//PlayerPrefs.DeleteAll();
	}

	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale!=0){
			GameObject.Find("TextInformation").GetComponent<Text>().text="";
		}
	if(Time.timeScale==0){
			if(PlayerPrefs.GetInt("unlockGun2")==1)
			{
				GameObject.Find("ButtonGun1").GetComponent<Button>().interactable=false;
				GameObject.Find("Text1").GetComponent<Text>().text="Item already purchase.";
				
			}
		if(PlayerPrefs.GetInt("unlockGun3")==1)
		{
			GameObject.Find("ButtonGun2").GetComponent<Button>().interactable=false;
			GameObject.Find("Text2").GetComponent<Text>().text="Item already purchase.";
			
		}
		if(PlayerPrefs.GetInt("unlockGun4")==1)
		{
			GameObject.Find("ButtonGun3").GetComponent<Button>().interactable=false;
			GameObject.Find("Text3").GetComponent<Text>().text="Item already purchase.";

		}
		if(PlayerPrefs.GetInt("unlockGun5")==1)
		{
			GameObject.Find("ButtonGun4").GetComponent<Button>().interactable=false;
			GameObject.Find("Text4").GetComponent<Text>().text="Item already purchase.";
			
		}
		}

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
						//show backtomenu texture
						transform.FindChild("BackToMenu").gameObject.SetActive(true);
			
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
			//hide backtomenu texture
			transform.FindChild("BackToMenu").gameObject.SetActive(false);
			
		}

	}

	public void unlockGun2(){
		if(PlayerPrefs.GetInt("unlockGun2") == 0 && PlayerPrefs.GetInt("dust") >=5000){
			PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-5000);
			PlayerPrefs.SetInt("unlockGun2",1);
			text.GetComponent<Text>().text="You've unlocked Modify Pistol.";
		}else 
			text.GetComponent<Text>().text="You don't have enough dust.";

	}
	public void unlockGun3(){
		if(PlayerPrefs.GetInt("unlockGun3") == 0 && PlayerPrefs.GetInt("dust") >=8000){
			PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-8000);
			PlayerPrefs.SetInt("unlockGun3",1);
			text.GetComponent<Text>().text="You've unlocked ShotGun.";
		}else 
			text.GetComponent<Text>().text="You don't have enough dust.";
		
	}
	public void unlockGun4(){
		if(PlayerPrefs.GetInt("unlockGun4") == 0 && PlayerPrefs.GetInt("dust") >=10000){
			PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-10000);
			PlayerPrefs.SetInt("unlockGun4",1);
			text.GetComponent<Text>().text="You've unlocked SingleShot.";
		}else 
			text.GetComponent<Text>().text="You don't have enough dust.";
		
	}
	public void unlockGun5(){
		if(PlayerPrefs.GetInt("unlockGun5") == 0 && PlayerPrefs.GetInt("dust") >=15000){
			PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-15000);
			PlayerPrefs.SetInt("unlockGun5",1);
			text.GetComponent<Text>().text="You've unlocked M4-Carbine.";
		}else 
			text.GetComponent<Text>().text="You don't have enough dust.";
		
	}
	public void addSpeedy(){
		if(PlayerPrefs.GetInt("dust")>= 500)
		{
			PlayerPrefs.SetInt("dust", PlayerPrefs.GetInt("dust")-500);
			PlayerPrefs.SetInt("NumberOfShoes", PlayerPrefs.GetInt("NumberOfShoes")+1);
			text.GetComponent<Text>().text="One more speedy for the road.";
		}else 
			text.GetComponent<Text>().text="You don't have enough dust.";
	}
	public void addImmortality(){
		if(PlayerPrefs.GetInt("dust")>= 500)
		{
			PlayerPrefs.SetInt("dust", PlayerPrefs.GetInt("dust")-500);
			PlayerPrefs.SetInt("NumberOfShields", PlayerPrefs.GetInt("NumberOfShields")+1);
			text.GetComponent<Text>().text="One more shield for the road.";
		}else 
			text.GetComponent<Text>().text="You don't have enough dust.";
	}
	public void addInvincibility(){
		if(PlayerPrefs.GetInt("dust")>= 500)
		{
			PlayerPrefs.SetInt("dust", PlayerPrefs.GetInt("dust")-500);
			PlayerPrefs.SetInt("NumberOfShields2", PlayerPrefs.GetInt("NumberOfShields2")+1);
			text.GetComponent<Text>().text="One more shield for the road.";
		}else 
			text.GetComponent<Text>().text="You don't have enough dust.";
	}

	public void unlockOneMoreLevel(){
				if (PlayerPrefs.GetInt ("dust") >= 500) {
						if (PlayerPrefs.GetInt ("levelsUnlocked1") < 30) {
								PlayerPrefs.SetInt ("dust", PlayerPrefs.GetInt ("dust") - 500);
								PlayerPrefs.SetInt ("levelsUnlocked1", PlayerPrefs.GetInt ("levelsUnlocked1") + 1);
							}else 
							{
								text.GetComponent<Text> ().text = "No more levels to be unlocked";
							}
				}
				else
				{
				text.GetComponent<Text>().text="You don't have enough dust.";
				}

}
}
	