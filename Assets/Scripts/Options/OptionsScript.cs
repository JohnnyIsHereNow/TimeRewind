using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class OptionsScript : MonoBehaviour {
	private GameObject c;
	private Toggle soundCheck, resetCheck;
	private InputField cheatCodeInput;
	private Text messageBox;
	// Use this for initialization
	void Start () {
		c=GameObject.Find("Canvas");
		soundCheck=c.transform.FindChild("ToggleMuteButton").GetComponent<Toggle>();
		resetCheck=c.transform.FindChild("ToggleResetButton").GetComponent<Toggle>();
		cheatCodeInput=c.transform.FindChild("InputField").GetComponent<InputField>();
		messageBox=c.transform.Find("Text").GetComponent<Text>();
		if(PlayerPrefs.GetInt("Audio")==1){
			soundCheck.isOn=false;
		}else{
			soundCheck.isOn=true;
		}
	}
	IEnumerator waitSecond(){
		yield return new WaitForSeconds(1);		
		resetCheck.isOn=false;
	}
	// Update is called once per frame
	void Update () {
	

	if(soundCheck.isOn){
			AudioListener.pause=true;
			//messageBox.text="Audio muted";
			PlayerPrefs.SetInt("Audio",0);
		}
	if(!soundCheck.isOn && (PlayerPrefs.GetInt("Audio")==0)){
			AudioListener.pause=false;
			//messageBox.text="Audio is now running";
			PlayerPrefs.SetInt("Audio",1);
	}
	if(resetCheck.isOn){
			PlayerPrefs.DeleteAll();
			messageBox.text="Progress deleted";
			StartCoroutine(waitSecond());
		}
	}
	public void checkForCheat(){		
		//give me money cheat
		if(cheatCodeInput.text.Equals("Give me money")){
			if(PlayerPrefs.HasKey("GiveMeMoney")){
				messageBox.text="Cheat allready used or not valid !";
			}else{
				PlayerPrefs.SetString("GiveMeMoney","GiveMeMoney");
				PlayerPrefs.SetInt("dust", PlayerPrefs.GetInt("dust")+500);
				messageBox.text="You've been rewarded with 500 dust !";
			}
		}
		//give me money cheat
		if(cheatCodeInput.text.Equals("Give me more money")){
			if(PlayerPrefs.HasKey("GiveMeMoreMoney")){
				messageBox.text="Cheat allready used or not valid !";
			}else{
				PlayerPrefs.SetString("GiveMeMoreMoney","GiveMeMoreMoney");
				PlayerPrefs.SetInt("dust", PlayerPrefs.GetInt("dust")+5000);
				messageBox.text="You've been rewarded with 5000 dust !";
			}
		}
		//unlocke weapon two
		if(cheatCodeInput.text.Equals("nbnannsnm")){
			if(PlayerPrefs.HasKey("nbnannsnm")){
				messageBox.text="Cheat allready used or not valid !";
			}else{
				PlayerPrefs.SetString("nbnannsnm","nbnannsnm");
				PlayerPrefs.SetInt("unlockGun2",1);
				messageBox.text="A weapon has been unlocked";
			}
		}
		//unlocke weapon three
		if(cheatCodeInput.text.Equals("asdw3d3")){
			if(PlayerPrefs.HasKey("asdw3d3")){
				messageBox.text="Cheat allready used or not valid !";
			}else{
				PlayerPrefs.SetString("asdw3d3","asdw3d3");
				PlayerPrefs.SetInt("unlockGun3",1);
				messageBox.text="A weapon has been unlocked";
			}
		}
		//unlocke weapon four
		if(cheatCodeInput.text.Equals("84877c77cc7")){
			if(PlayerPrefs.HasKey("84877c77cc7")){
				messageBox.text="Cheat allready used or not valid !";
			}else{
				PlayerPrefs.SetString("84877c77cc7","84877c77cc7");
				PlayerPrefs.SetInt("unlockGun4",1);
				messageBox.text="A weapon has been unlocked";
			}
		}
		//unlocke weapon five
		if(cheatCodeInput.text.Equals("asdassadavvfg333")){
			if(PlayerPrefs.HasKey("asdassadavvfg333")){
				messageBox.text="Cheat allready used or not valid !";
			}else{
				PlayerPrefs.SetString("asdassadavvfg333","asdassadavvfg333");
				PlayerPrefs.SetInt("unlockGun5",1);
				messageBox.text="A weapon has been unlocked";
			}
		}
		

		}

}
