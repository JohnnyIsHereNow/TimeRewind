using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DisplayTextForUnlockingWorlds : MonoBehaviour {
	private Text tex;
	// Use this for initialization
	void Start () {
		tex=GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("l")) PlayerPrefs.SetInt("dust",15000);
		if(Input.GetKey("k")) PlayerPrefs.SetInt("dust",0);
	if(PlayerPrefs.GetInt("dust") < 2500 )
		{
			tex.text="I'm sorry, you do not have enough dust to make this purchase. You only have " + 
				PlayerPrefs.GetInt("dust") + " dust. Play the game a little bit more, purchase some dust in the store"
					+ " or make a donation and ask for a cheat code.";

		} else
		{
			tex.text="You have " + PlayerPrefs.GetInt("dust") + " dust. Are you sure you want to make this purchase?";
		}
	}
}
