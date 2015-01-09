using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Profile;
using Soomla;
public class SocialOnLevelCompleted : MonoBehaviour {
	public InputField tx;

	public void shareOnFacebook(){
#if UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR
		if(SoomlaProfile.IsLoggedIn(Provider.FACEBOOK))
		{			
			FB.Feed(
				link: "http://iubisoft.com",
				linkName: "Time Rewind",
				linkCaption: "Maybe the best game ever - ME",
				linkDescription: tx.text,
				callback: LogCallback
				);
			Debug.Log ("Done !");
			//SoomlaProfile.UpdateStatus(Provider.FACEBOOK,"You should try this game","",null);
		}else{
			SoomlaProfile.Login(Provider.FACEBOOK);
		}
#endif
#if !(UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR)
		Application.OpenURL("https://facebook.com/iubisoftcom");
#endif
	}
	public void shareOnTwitter(){
#if UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR
		if(SoomlaProfile.IsLoggedIn(Provider.TWITTER)){
			SoomlaProfile.UpdateStatus(Provider.TWITTER,"Hey, "+tx.text,"",null);
		}else{
			SoomlaProfile.Login(Provider.TWITTER);
		}
#endif
#if !(UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR)
		Application.OpenURL("https://twitter.com/iubisoftcom");
#endif
	}

//=====================================================================Shares====================================
#if UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR
	void LogCallback(FBResult response) {
		//give reward
		if(!response.Text.Contains("cancelled")){
			PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")+20);
		}
		Debug.Log("Result: "+response.Text);
	}
#endif
}

