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
			messageBox.text="Audio muted";
			PlayerPrefs.SetInt("Audio",0);
		}
	if(!soundCheck.isOn && (PlayerPrefs.GetInt("Audio")==0)){
			AudioListener.pause=false;
			messageBox.text="Audio is now running";
			PlayerPrefs.SetInt("Audio",1);
	}
	if(resetCheck.isOn){
			PlayerPrefs.DeleteAll();
			messageBox.text="Progress deleted";
			StartCoroutine(waitSecond());
		}
	}
	public void checkForCheat(){		
		if(cheatCodeInput.text.Equals("Give me money")){
			messageBox.text="Give me money";
		}
		}

}
