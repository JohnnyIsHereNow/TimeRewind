using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FacebookShare : MonoBehaviour {
	/*
	public	 InputField ifb;

	void Awake(){
		if(!FB.IsLoggedIn){
			Debug.Log ("FB has been init");
			FB.Init(SetInit, OnHideUnity);
		}
	}
	//login to facebook;
	public void LogIn(){
		if(!FB.IsLoggedIn){
			//login
			FB.Login("email,publish_actions", AuthCallback);
		
			//change picture to logout
			Debug.Log ("Login");
		}
		if(FB.IsLoggedIn){
			//logout
			FB.Logout();
			Debug.Log ("Logout");
			//change picture to login
		}
	}
	// Update is called once per frame
	public void post() {
	if(FB.IsLoggedIn){
			Debug.Log ("I am here");
			postOnWall();
		}
	if(!FB.IsLoggedIn){
			LogIn();
			Debug.Log ("Logged in");
	}
	
	}
	public void postOnWall(){
		//make a feed for every platform
		FB.Feed(
			toId: FB.UserId,
			link: "http://iubisoft.com",
			linkName: "Time Rewind Game !",
			linkCaption: "Awesome !"+ifb.text,
			linkDescription: "You should try this awesome game ! It's free !"
			//picture: "https://graph.facebook.com/758207807577734/picture?type=large" //getPicture().ToString()
			);
		Debug.Log ("Message posted");
	}

	//functions
	//initiate facebook
	public void SetInit(){
		enabled = true;		
	}
	//hide facebook
	private void OnHideUnity(bool isGameShown) {
		if (!isGameShown) {
			// pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// start the game back up - we're getting focus again
			Time.timeScale = 1;
		}
	}
	//check if loged in
	private void AuthCallback(FBResult result) {
		if(FB.IsLoggedIn) {
			Debug.Log(FB.UserId);
		} else {
			Debug.Log("User cancelled login");
		}
	}*/
}
