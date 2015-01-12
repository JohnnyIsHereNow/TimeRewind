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
			#if UNITY_ANDROID
			SoomlaProfile.UpdateStory(
				Provider.FACEBOOK,                          // Provider
				"Blabla",                       // Text of the story to post
				"The story of SOOMBOT (Profile Test App)",  // Name
				"SOOMBOT Story",                            // Caption
				"http://about.soom.la/soombots",            // Link to post
				"http://about.soom.la/.../spockbot.png",    // Image URL
				"",                                         // Payload
				null                               // Reward for posting a story
				);
			#endif
			#if UNITY_IPHONE
			SoomlaProfile.UpdateStory(
				Provider.FACEBOOK,                          // Provider
				"Blabla",                       // Text of the story to post
				"The story of SOOMBOT (Profile Test App)",  // Name
				"SOOMBOT Story",                            // Caption
				"http://about.soom.la/soombots",            // Link to post
				"http://about.soom.la/.../spockbot.png",    // Image URL
				"",                                         // Payload
				null                               // Reward for posting a story
				);
			#endif
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

