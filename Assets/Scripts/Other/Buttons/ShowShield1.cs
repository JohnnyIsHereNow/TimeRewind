using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowShield1 : MonoBehaviour {

	private Text text;
	// Use this for initialization
	void Start () {
		text=GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text=""+PlayerPrefs.GetInt("NumberOfShields1");
		//	Debug.Log (PlayerPrefs.GetInt ("dust"));
	}
}
