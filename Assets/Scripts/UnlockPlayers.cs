using UnityEngine;
using System.Collections;

public class UnlockPlayers : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		for(int i=1;i<=2;i++){
			if (!PlayerPrefs.HasKey ("playersUnlocked"+i))
				PlayerPrefs.SetInt ("playersUnlocked"+i, 0);
		}
		//PlayerPrefs.SetInt ("worldUnlocked2", 0);
		//PlayerPrefs.SetInt ("dust", 5600);
		PlayerPrefs.SetInt ("playersUnlocked1", 1);
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (PlayerPrefs.GetInt ("dust"));
		for(int i=1;i<=2;i++){
			if(PlayerPrefs.GetInt("playersUnlocked"+i)==1){
				GameObject.Find("Child For Pictures").gameObject.transform.FindChild("Player"+i).FindChild("Locked").gameObject.SetActive(false);
				GameObject.Find("Child For Pictures").gameObject.transform.FindChild("Player"+i).FindChild("PlayerForTheLevels").gameObject.SetActive(true);

			}
			else
				GameObject.Find("Child For Pictures").gameObject.transform.FindChild("Player"+i).FindChild("PlayerForTheLevels").gameObject.SetActive(false);
			
		}
	}
}
