using UnityEngine;
using System.Collections;
using Soomla.Profile;
using Soomla.Store;
public class GoToMenuScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
#if UNITY_ANDROID || UNITY_IOS
		SoomlaProfile.Initialize();
		//SoomlaStore.Initialize(new InAppPurchases());
#endif
		Application.LoadLevel(1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
