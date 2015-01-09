using UnityEngine;
using System.Collections;
using Soomla.Profile;
public class GoToMenuScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SoomlaProfile.Initialize();
		Application.LoadLevel(1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
