using UnityEngine;
using System.Collections;

public class UnlockLevelWorld1 : MonoBehaviour {
	private int levelsUnlocked=1;
	private GameObject playerForTheLevels;
	// Use this for initialization
	void Start () {
		playerForTheLevels = GameObject.Find ("PlayerForTheLevels");
	if (!PlayerPrefs.HasKey ("levelsUnlocked1"))
						PlayerPrefs.SetInt ("levelsUnlocked1", 1);
						levelsUnlocked = PlayerPrefs.GetInt ("levelsUnlocked1");
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 pos = new Vector2 (gameObject.transform.GetChild (levelsUnlocked).transform.position.x - 25, gameObject.transform.GetChild (levelsUnlocked).transform.position.y - 20);
		playerForTheLevels.transform.position = pos;
		GameObject b=GameObject.Find("level"+levelsUnlocked);
		for (int i=1; i<=levelsUnlocked; i++) {
						b = GameObject.Find ("level" + levelsUnlocked);
						gameObject.transform.GetChild (i).GetChild (0).gameObject.SetActive (false);			
				}
		for(int i=levelsUnlocked+1;i<=30;i++){
			b=GameObject.Find("level"+levelsUnlocked);
			gameObject.transform.GetChild(i).gameObject.SetActive(false);
		}
	
	}
}
