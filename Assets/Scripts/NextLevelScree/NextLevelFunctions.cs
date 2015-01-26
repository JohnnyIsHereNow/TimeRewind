using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Profile;
using Soomla;

public class NextLevelFunctions : MonoBehaviour {
	private GameObject levelCompleteInterface;
	public void BackToMainMenu(){
		Application.LoadLevel("startScene");
	}
	public void GetBackToNormal(){
		levelCompleteInterface=GameObject.Find("LevelCompleteInterface");
		Time.timeScale=1.0f;
		levelCompleteInterface.SetActive(false);
	}


	public void NextLevel(){
		//the name is level01-01
		string nextLevelName = Application.loadedLevelName.Substring(5,5);
		//changeTheNumber
		string[] numbers = nextLevelName.Split('-');
		if(int.Parse(numbers[1])==30){
			//go back to world screen
			Application.LoadLevel("loadWorldScene");
		}else{
			//change to the next level
			//get number into int
			int levelNumber=int.Parse(numbers[1]);
			//increment by one
			levelNumber++;
			//check if its smaller than 10;
			if(levelNumber<10) 
				numbers[1]="0"+levelNumber;
			else
				numbers[1]=""+levelNumber;

		//save the new name inside nextLevelName
			nextLevelName=numbers[0]+"-"+numbers[1];
			
		}
		GetBackToNormal();
		//load scene
		Application.LoadLevel("level"+nextLevelName);

	}
	public void ReplayLevel(){
		GetBackToNormal();
		Application.LoadLevel(Application.loadedLevelName);
	}
	public void FacebookShare(){
		#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
		// When a user updates his/her status, they'll receive a statusReward (free sword).
		if(SoomlaProfile.IsLoggedIn(Provider.FACEBOOK))
		{/*			
			FB.Feed(
				link: "http://iubisoft.com",
				linkName: "Time Rewind",
				linkCaption: "Maybe the best game ever - ME",
				linkDescription: "Do you have this game ?",
				callback: LogCallback
				);*/
			//	SoomlaProfile.UpdateStatus(Provider.FACEBOOK,"You should try this game","",null);
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
			//SoomlaProfile.OpenAppRatingPage();
		}
		else
		{
			SoomlaProfile.Login(Provider.FACEBOOK);
		}
		#if !(UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR)
		facebookShare.interactable=false;
		#endif
	}
	public void TwiterShare(){
		
		#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
		// When a user updates his/her status, they'll receive a statusReward (free sword).
		if(SoomlaProfile.IsLoggedIn(Provider.TWITTER))
		{
			SoomlaProfile.UpdateStatus(Provider.TWITTER,"You should try this game","",null);
			//give reward
			PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")+20);
			//disable the button			
			PlayerPrefs.SetInt("TwitterTweet",1);
		//	twitterTweet.interactable=false;
		}
		else
		{
			SoomlaProfile.Login(Provider.TWITTER);
		}
		#endif
		#if !(UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR)
		twitterTweet.interactable=false;
		#endif
		#endif
	}
}
