using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Soomla.Profile;
using Soomla;

public class SocialActions : MonoBehaviour {
	public Button likeButton,followButton,youtubeSubscribe,twitchFollow,twitterTweet,facebookShare,friendInviteButton;
//disable the buttons
void Start(){
		//PlayerPrefs.DeleteAll();
		if(PlayerPrefs.HasKey("LikeButton")){
			if(PlayerPrefs.GetInt("LikeButton")==1){
				likeButton.interactable=false;
			}
		}
		if(PlayerPrefs.HasKey("FollowButton")){
			if(PlayerPrefs.GetInt("FollowButton")==1){
				followButton.interactable=false;
			}
		}
		if(PlayerPrefs.HasKey("YoutubeSubscribe")){
			if(PlayerPrefs.GetInt("YoutubeSubscribe")==1){
				youtubeSubscribe.interactable=false;
			}
		}
		if(PlayerPrefs.HasKey("TwitchFollow")){
			if(PlayerPrefs.GetInt("TwitchFollow")==1){
				twitchFollow.interactable=false;
			}
		}
		if(PlayerPrefs.HasKey("TwitterTweet")){
			if(PlayerPrefs.GetInt("TwitterTweet")==1){
				twitterTweet.interactable=false;
			}
		}
	}
public void likeFacebookPage()
	{
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
		if(SoomlaProfile.IsLoggedIn(Provider.FACEBOOK)){
		//open the windows
		SoomlaProfile.Like(Provider.FACEBOOK,"iubisoftcom",null);
		//give reward
		PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")+100);
		//disable the buttons
		PlayerPrefs.SetInt("LikeButton",1);
		likeButton.interactable=false;
		}else{
			SoomlaProfile.Login(Provider.FACEBOOK);
		}
#else
		Application.OpenURL("https://facebook.com/iubisoftcom");
		//give reward
		PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")+100);
		//disable the buttons
		PlayerPrefs.SetInt("LikeButton",1);
		likeButton.interactable=false;
#endif
	}
public void followOnTwitter()
	{
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
		if(SoomlaProfile.IsLoggedIn(Provider.TWITTER)){
		SoomlaProfile.Like (Provider.TWITTER,"iubisoftcom",null);
		//give reward
		PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")+100);
		//disable the buttons
		PlayerPrefs.SetInt("FollowButton",1);
		followButton.interactable=false;
			}else{
			SoomlaProfile.Login(Provider.TWITTER);
		}
#else
			Application.OpenURL("https://twitter.com/iubisoftcom");
			//give reward
			PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")+100);
			//disable the buttons
			PlayerPrefs.SetInt("FollowButton",1);
			followButton.interactable=false;
#endif	
	}
	public void subscribeOnYoutube()
	{
		Application.OpenURL("http://youtube.com/user/iubisoft");
		//give reward
		PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")+100);
		//disable the buttons
		PlayerPrefs.SetInt("YoutubeSubscribe",1);
		youtubeSubscribe.interactable=false;
	}
	public void followOnTwitch()
	{
		Application.OpenURL("http://www.twitch.tv/iubisoft");
		//give reward
		PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")+100);
		//disable the buttons
		PlayerPrefs.SetInt("TwitchFollow",1);
		twitchFollow.interactable=false;
	}
//=====================================================================Shares====================================
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
	void LogCallback(FBResult response) {
		//give reward
		if(!response.Text.Contains("cancelled")){
		PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")+20);
		}
		Debug.Log("Result: "+response.Text);
	}
#endif	

//=====================================================================Shares====================================
	public void shareOnFacebook(){
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
	public void shareOnTwitter(){
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
		// When a user updates his/her status, they'll receive a statusReward (free sword).
		if(SoomlaProfile.IsLoggedIn(Provider.TWITTER))
		{
			SoomlaProfile.UpdateStatus(Provider.TWITTER,"You should try this game","",null);
			//give reward
			PlayerPrefs.SetInt("dust",PlayerPrefs.GetInt("dust")+20);
			//disable the button			
			PlayerPrefs.SetInt("TwitterTweet",1);
			twitterTweet.interactable=false;
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
//==============================================================friend invite================================
	public void friendInvite(){
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
		FB.AppRequest(
		message: "Come play this great game!", 
		callback: LogCallback
		);
#endif
#if !(UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR)
		friendInviteButton.interactable=false;
#endif
	}
//end of clas
}
//end of file