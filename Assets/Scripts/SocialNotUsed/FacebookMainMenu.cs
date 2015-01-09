using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FacebookMainMenu : MonoBehaviour {
	/*private bool showFeed=true;
	public Sprite login, logout;
	public Button b;

	void Update(){
		if(FB.IsLoggedIn){			
			b.GetComponent<Image>().sprite=logout;
		}else{			
			b.GetComponent<Image>().sprite=login;
		}
	}
	void Awake(){
		b.GetComponent<Button>();

	}
	//initiate facebook
	public void SetInit(){
		enabled = true;		
	}
	//login to facebook;
	public void LogIn(){
		if(!FB.IsLoggedIn && Application.internetReachability!=NetworkReachability.NotReachable)
			FB.Init(SetInit, OnHideUnity);
		if(!FB.IsLoggedIn && Application.internetReachability!=NetworkReachability.NotReachable){
			//login
			FB.Login("email", AuthCallback);

			//change picture to logout
		}
		if(FB.IsLoggedIn && Application.internetReachability!=NetworkReachability.NotReachable){
			//logout
			FB.Logout();
			//change picture to login
		}
	}
	public void showFeedToInvite(){
		inviteToPlayGame();
	}
	public void postOnWall(){
		FB.Feed(
			link: "http://iubisoft.com",
			linkName: "The Larch",
			linkCaption: "I thought up a witty tagline about larches",
			linkDescription: "There are a lot of larch trees around here, aren't there?"
			);
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
		}
	//invite to play the game !
	private void LogCallback(FBResult response) {
		Debug.Log(response.Text);
	}

	private void inviteToPlayGame(){
	FB.AppRequest(message: "Come play this great game!", callback: LogCallback);
	}
*/
}
