using UnityEngine;
using System.Collections;

public class FunctionsToBeCalled : MonoBehaviour {

	public void PlayButton(){
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
	public void UnlockWorld1(){
		if(PlayerPrefs.HasKey("dust") && PlayerPrefs.GetInt("worldUnlocked1")==0){
			if(PlayerPrefs.GetInt("dust")>=2500){
				PlayerPrefs.SetInt ("worldUnlocked1", 1);
				PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-2500);}
			}
		}
	public void UnlockWorld2(){
		if(PlayerPrefs.HasKey("dust") && PlayerPrefs.GetInt("worldUnlocked2")==0){
			if(PlayerPrefs.GetInt("dust")>=2500){
				PlayerPrefs.SetInt ("worldUnlocked2", 1);
				PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-2500);}
		}
	}
	public void UnlockWorld3(){
		if(PlayerPrefs.HasKey("dust")  && PlayerPrefs.GetInt("worldUnlocked3")==0){
			if(PlayerPrefs.GetInt("dust")>=2500){
				PlayerPrefs.SetInt ("worldUnlocked3", 1);
				PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-2500);}
		}
	}
	public void UnlockWorld4(){
		if(PlayerPrefs.HasKey("dust")  && PlayerPrefs.GetInt("worldUnlocked4")==0){
			if(PlayerPrefs.GetInt("dust")>=2500){
				PlayerPrefs.SetInt ("worldUnlocked4", 1);
				PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-2500);}
		}
	}
	public void UnlockWorld5(){
		if(PlayerPrefs.HasKey("dust")  && PlayerPrefs.GetInt("worldUnlocked5")==0){
			if(PlayerPrefs.GetInt("dust")>=2500){
				PlayerPrefs.SetInt ("worldUnlocked5", 1);
				PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-2500);}
		}
	}
	public void UnlockWorld6(){
		if(PlayerPrefs.HasKey("dust")  && PlayerPrefs.GetInt("worldUnlocked6")==0){
			if(PlayerPrefs.GetInt("dust")>=2500){
				PlayerPrefs.SetInt ("worldUnlocked6", 1);
				PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")-2500);}
		}
	}
	public void EnterCharacterSelect(){
		Application.LoadLevel ("characterSelect");
		}
	public void EnterWorld1Level1(){
		PlayerPrefs.SetInt ("levelInPlay", 1);
		Application.LoadLevel ("scene");
	}
	public void EnterWorld1Level2(){
		PlayerPrefs.SetInt ("levelInPlay", 2);
		Application.LoadLevel ("scene2");
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
