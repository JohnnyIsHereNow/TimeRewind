using UnityEngine;
using System.Collections;
using Soomla;
using Soomla.Profile;

using UnityEngine.UI;
public class InitializeSocial : MonoBehaviour {
	private Text tx;
	private Image profileImage;
	public Sprite defaultImage,fbLogOut,fbLogIn,twLogOut,twLogIn;
	private WWW www;
	private bool pictureNotLoaded=true;
	public Button b1,b2;
	// Use this for initialization


	void Start () {

#if UNITY_ANDROID || UNITY_IPHONE || UNITY_EDITOR

		tx=GameObject.Find("ErrorMessage").GetComponent<Text>();
		profileImage=GameObject.Find("FbImage").GetComponent<Image>();

#endif
#if !(UNITY_ANDROID || UNITY_IPHONE || UNITY_EDITOR)
		b1.GetComponent<Image>().color=new Vector4(0,0,0,0);
		b1.interactable=false;
		b2.GetComponent<Image>().color=new Vector4(0,0,0,0);
		b2.interactable=false;
#endif
	}
	
#if UNITY_ANDROID || UNITY_IPHONE || UNITY_EDITOR
	IEnumerator getProfilePicture(){
		pictureNotLoaded=false;
		www = new WWW("https://graph.facebook.com/"+SoomlaProfile.GetStoredUserProfile(Provider.FACEBOOK).ProfileId+"/picture?height=90&type=normal&width=90");
		//Debug.Log ("https://graph.facebook.com/"+SoomlaProfile.GetStoredUserProfile(Provider.FACEBOOK).ProfileId+"/picture?height=200&type=normal&width=200");
		while(!www.isDone)
		{
			yield return new WaitForSeconds(1);
		}
		profileImage.sprite=Sprite.Create(www.texture, new Rect(0, 0,90.0f,90.0f), new Vector2(0.5f, 0.5f), 100);
	}
#endif
	void Update(){
#if UNITY_ANDROID || UNITY_IPHONE || UNITY_EDITOR
		if (SoomlaProfile.IsLoggedIn(Provider.FACEBOOK) && pictureNotLoaded) {
			StartCoroutine(getProfilePicture());
		}
#endif
	}
	public void LogInToFacebook(){
#if UNITY_ANDROID || UNITY_IPHONE || UNITY_EDITOR
		if(Application.internetReachability!=NetworkReachability.NotReachable){
		if (!SoomlaProfile.IsLoggedIn(Provider.FACEBOOK)) {
			SoomlaProfile.Login(Provider.FACEBOOK);
			tx.text="";
			b1.GetComponent<Image>().sprite=fbLogOut;
		}
		else{
			SoomlaProfile.Logout(Provider.FACEBOOK);
			tx.text="";
			profileImage.sprite=defaultImage;
			pictureNotLoaded=true;
			b1.GetComponent<Image>().sprite=fbLogIn;
			}
		}else 
		tx.text="No internet connection";
#endif
	}

	public void LogInToTwitter(){
		
#if UNITY_ANDROID || UNITY_IPHONE || UNITY_EDITOR
		if(Application.internetReachability!=NetworkReachability.NotReachable){
		if(!SoomlaProfile.IsLoggedIn(Provider.TWITTER)){
			SoomlaProfile.Login(Provider.TWITTER);
			tx.text="";
			b2.GetComponent<Image>().sprite=twLogOut;
		}
		else{
			SoomlaProfile.Logout(Provider.TWITTER);
			tx.text="";
			b2.GetComponent<Image>().sprite=twLogIn;
			}
		}else 
		tx.text="No internet connection";
#endif
}
}
