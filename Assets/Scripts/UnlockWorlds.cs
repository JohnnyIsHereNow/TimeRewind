using UnityEngine;
using System.Collections;

public class UnlockWorlds : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		for(int i=1;i<=6;i++){
		if (!PlayerPrefs.HasKey ("worldUnlocked"+i))
						PlayerPrefs.SetInt ("worldUnlocked"+i, 0);
		}
		//PlayerPrefs.SetInt ("worldUnlocked2", 0);
		PlayerPrefs.SetInt ("dust", 5600);
		PlayerPrefs.SetInt ("worldUnlocked1", 1);

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (PlayerPrefs.GetInt ("dust"));
		for(int i=1;i<=6;i++){
			if(PlayerPrefs.GetInt("worldUnlocked"+i)==1)
			GameObject.Find("Child For Pictures").gameObject.transform.FindChild("World"+i).FindChild("Locked").gameObject.SetActive(false);

	
	}
}
}
