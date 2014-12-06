using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FunctionsToBeCalled : MonoBehaviour {
	private GameObject aus;
	private int worldToUnlock=0;
	void Start(){
		aus= GameObject.Find("Panel");
			if(aus!=null)
		aus.SetActive(false);
	}
	void Update(){
		//Debug.Log (worldToUnlock);
	}



	public void PlayButton(){
		if(!PlayerPrefs.HasKey("dust")) PlayerPrefs.SetInt("dust",0);
		if(!PlayerPrefs.HasKey("NumberOfShields1")) PlayerPrefs.SetInt("NumberOfShields1",1);
		if(!PlayerPrefs.HasKey("NumberOfShields2")) PlayerPrefs.SetInt("NumberOfShields2",1);
		if(!PlayerPrefs.HasKey("NumberOfShoes")) PlayerPrefs.SetInt("NumberOfShoes",1);
		Application.LoadLevel ("loadWorldScene");
	}
	public void OpenFacebook(){
		Application.OpenURL ("http://facebook.com/iubisoftcom");
	}
	public void BackToTheFirstMenu(){
		Application.LoadLevel ("startScene");
	}
	public void LoadOptions(){
		Application.LoadLevel ("options");
	}
	public void LoadCharacterSelect(){
		if(!PlayerPrefs.HasKey("dust")) PlayerPrefs.SetInt("dust",0);
		if(!PlayerPrefs.HasKey("NumberOfShields1")) PlayerPrefs.SetInt("NumberOfShields1",1);
		if(!PlayerPrefs.HasKey("NumberOfShields2")) PlayerPrefs.SetInt("NumberOfShields2",1);
		if(!PlayerPrefs.HasKey("NumberOfShoes")) PlayerPrefs.SetInt("NumberOfShoes",1);
		Application.LoadLevel ("characterSelect");
	}
	public void LoadLevel1Levels(){
		//if(PlayerPrefs.HasKey("worldUnlocked1"))
		//	if(PlayerPrefs.GetInt("worldUnlocked1")==1)
				Application.LoadLevel ("world1Levels");
	}
	public void LoadLevel2Levels(){
		if(PlayerPrefs.HasKey("worldUnlocked2"))
			if(PlayerPrefs.GetInt("worldUnlocked2")==1)
				Application.LoadLevel ("world2Levels");
	}
	public void LoadLevel3Levels(){
		if(PlayerPrefs.HasKey("worldUnlocked3"))
			if(PlayerPrefs.GetInt("worldUnlocked3")==1)
				Application.LoadLevel ("world3Levels");
	}
	public void LoadLevel4Levels(){
		if(PlayerPrefs.HasKey("worldUnlocked4"))
			if(PlayerPrefs.GetInt("worldUnlocked4")==1)
				Application.LoadLevel ("world4Levels");
	}
	public void LoadLevel5Levels(){
		if(PlayerPrefs.HasKey("worldUnlocked5"))
			if(PlayerPrefs.GetInt("worldUnlocked5")==1)
				Application.LoadLevel ("world5Levels");
	}
	public void LoadLevel6Levels(){
		if(PlayerPrefs.HasKey("worldUnlocked6"))
			if(PlayerPrefs.GetInt("worldUnlocked6")==1)
				Application.LoadLevel ("world6Levels");
	}
	public void showPromt2(){
		if(aus.activeInHierarchy == false){
		worldToUnlock=2;
		}
		if(PlayerPrefs.GetInt("worldUnlocked2")==0)
		aus.SetActive(true);
	}
	public void showPromt3(){
		if(aus.activeInHierarchy == false){
		worldToUnlock=3;
		}
		if(PlayerPrefs.GetInt("worldUnlocked3")==0)
		aus.SetActive(true);
	}
		public void showPromt4(){
			if(aus.activeInHierarchy == false){
		worldToUnlock=4;
		}
		if(PlayerPrefs.GetInt("worldUnlocked4")==0)
			aus.SetActive(true);
	}


	public void cancelTransaction(){
		aus.SetActive(false);

	}
	public void operateTransaction(){
		aus.SetActive(false);
		PlayerPrefs.SetInt("dust", PlayerPrefs.GetInt("dust")-2500);
		PlayerPrefs.SetInt("worldUnlocked"+worldToUnlock,1);

	}
	public void EnterCharacterSelect(){
		Application.LoadLevel ("characterSelect");
		}
	public void EnterWorld1Level1(){
		PlayerPrefs.SetInt ("levelInPlay", 1);
		Application.LoadLevel ("level01-01");
	}
	public void EnterWorld1Level2(){
		PlayerPrefs.SetInt ("levelInPlay", 2);
		Application.LoadLevel ("level01-02");
	}

	public void UnlockCharacter2(){
		if (PlayerPrefs.GetInt ("dust") >= 2500 && PlayerPrefs.GetInt("playersUnlocked2") !=1) {
			PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-2500);
			PlayerPrefs.SetInt("playersUnlocked2",1);
				}
		}
	public void SetPlayer2(){
		PlayerPrefs.SetInt ("Player", 2);

		}
	public void SetPlayer1(){
		PlayerPrefs.SetInt ("Player", 1);
		
	}


}
