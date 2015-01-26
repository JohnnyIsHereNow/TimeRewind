using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PauseButtonScript : MonoBehaviour {
	//public Texture continuePlay;
	//public Texture pause;
	private GameObject cam;
	private GameObject playmenu;
	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Camera");
		playmenu = GameObject.Find ("__PlayButtons");
		//PlayerPrefs.DeleteAll();
	}

	
	// Update is called once per frame
	void FixedUpdate () {
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
		if(PlayerPrefs.GetInt("noads")==1)
		{
			GameObject.Find("ButtonNoAds").GetComponent<Button>().interactable=false;
			GameObject.Find("Text4").GetComponent<Text>().text="Item already purchase.";
				
		}
		}
	}
	public void OnMouseUpPause(){
		if (Time.timeScale != 0.0) {
						//stop time
						Time.timeScale = 0.0f;
						//disable camera
						cam.SetActive (false);
						playmenu.SetActive(false);
						//enable UIElements
						GameObject.Find ("__PauseButton").transform.FindChild("_UIElements").gameObject.SetActive(true);						
						//disable pause button
						GameObject.Find("Interfata").transform.FindChild("PauseMenu").gameObject.SetActive(false);
						//disable game objects
			GameObject.Find("Interfata").transform.FindChild("Shield1Button").gameObject.SetActive(false);
			GameObject.Find("Interfata").transform.FindChild("ShoeButton").gameObject.SetActive(false);
			GameObject.Find("Interfata").transform.FindChild("KilledEnemies").gameObject.SetActive(false);
			GameObject.Find("Interfata").transform.FindChild("Shield2Button").gameObject.SetActive(false);
			
				}
		else{
			//restart time
			Time.timeScale = 1.0f;
			//disable camera
			cam.gameObject.SetActive (true);
			playmenu.SetActive(true);
			//enable UIElements
			GameObject.Find ("__PauseButton").transform.FindChild("_UIElements").gameObject.SetActive(false);
			//disable pause button
			GameObject.Find("Interfata").transform.FindChild("PauseMenu").gameObject.SetActive(true);
			//enable game objects
			GameObject.Find("Interfata").transform.FindChild("KilledEnemies").gameObject.SetActive(true);
			GameObject.Find("Interfata").transform.FindChild("ShoeButton").gameObject.SetActive(true);
			GameObject.Find("Interfata").transform.FindChild("Shield1Button").gameObject.SetActive(true);
			GameObject.Find("Interfata").transform.FindChild("Shield2Button").gameObject.SetActive(true);
			
		}

	}

	public void unlockGun2(){
		if(PlayerPrefs.GetInt("unlockGun2") == 0 && PlayerPrefs.GetInt("dust") >=5000){
			PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-5000);
			PlayerPrefs.SetInt("unlockGun2",1);
			GameObject.Find("TextInformation").GetComponent<Text>().text="You've unlocked Modify Pistol.";
		}else 
			GameObject.Find("TextInformation").GetComponent<Text>().text="You don't have enough dust.";

	}
	public void unlockGun3(){
		if(PlayerPrefs.GetInt("unlockGun3") == 0 && PlayerPrefs.GetInt("dust") >=8000){
			PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-8000);
			PlayerPrefs.SetInt("unlockGun3",1);
			GameObject.Find("TextInformation").GetComponent<Text>().text="You've unlocked ShotGun.";
		}else 
			GameObject.Find("TextInformation").GetComponent<Text>().text="You don't have enough dust.";
		
	}
	public void unlockGun4(){
		if(PlayerPrefs.GetInt("unlockGun4") == 0 && PlayerPrefs.GetInt("dust") >=10000){
			PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-10000);
			PlayerPrefs.SetInt("unlockGun4",1);
			GameObject.Find("TextInformation").GetComponent<Text>().text="You've unlocked SingleShot.";
		}else 
			GameObject.Find("TextInformation").GetComponent<Text>().text="You don't have enough dust.";
		
	}
	public void unlockGun5(){
		if(PlayerPrefs.GetInt("unlockGun5") == 0 && PlayerPrefs.GetInt("dust") >=15000){
			PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-15000);
			PlayerPrefs.SetInt("unlockGun5",1);
			GameObject.Find("TextInformation").GetComponent<Text>().text="You've unlocked M4-Carbine.";
		}else 
			GameObject.Find("TextInformation").GetComponent<Text>().text="You don't have enough dust.";
		
	}
	public void addSpeedy(){
		if(PlayerPrefs.GetInt("dust")>= 500)
		{
			PlayerPrefs.SetInt("dust", PlayerPrefs.GetInt("dust")-500);
			PlayerPrefs.SetInt("NumberOfShoes", PlayerPrefs.GetInt("NumberOfShoes")+1);
			GameObject.Find("TextInformation").GetComponent<Text>().text="One more speedy for the road.";
		}else 
			GameObject.Find("TextInformation").GetComponent<Text>().text="You don't have enough dust.";
	}
	public void addImmortality(){
		if(PlayerPrefs.GetInt("dust")>= 500)
		{
			PlayerPrefs.SetInt("dust", PlayerPrefs.GetInt("dust")-500);
			PlayerPrefs.SetInt("NumberOfShields", PlayerPrefs.GetInt("NumberOfShields")+1);
			GameObject.Find("TextInformation").GetComponent<Text>().text="One more shield for the road.";
		}else 
			GameObject.Find("TextInformation").GetComponent<Text>().text="You don't have enough dust.";
	}
	public void addInvincibility(){
		if(PlayerPrefs.GetInt("dust")>= 500)
		{
			PlayerPrefs.SetInt("dust", PlayerPrefs.GetInt("dust")-500);
			PlayerPrefs.SetInt("NumberOfShields2", PlayerPrefs.GetInt("NumberOfShields2")+1);
			GameObject.Find("TextInformation").GetComponent<Text>().text="One more shield for the road.";
		}else 
			GameObject.Find("TextInformation").GetComponent<Text>().text="You don't have enough dust.";
	}

	public void unlockOneMoreLevel(){
				if (PlayerPrefs.GetInt ("dust") >= 500) {
						if (PlayerPrefs.GetInt ("levelsUnlocked1") < 30) {
								PlayerPrefs.SetInt ("dust", PlayerPrefs.GetInt ("dust") - 500);
								PlayerPrefs.SetInt ("levelsUnlocked1", PlayerPrefs.GetInt ("levelsUnlocked1") + 1);
							}else 
							{
				GameObject.Find("TextInformation").GetComponent<Text> ().text = "No more levels to be unlocked";
							}
				}
				else
				{
			GameObject.Find("TextInformation").GetComponent<Text>().text="You don't have enough dust.";
				}

}
}
	