using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UnlockWorlds : MonoBehaviour {
	// Use this for initialization
	public Button ui;
	void Awake () {
		//PlayerPrefs.DeleteAll();

		//PlayerPrefs.SetInt ("worldUnlocked2", 0);
		//PlayerPrefs.SetInt ("dust", 5600);
		PlayerPrefs.SetInt ("worldUnlocked1", 1);
		
		for(int i=1;i<=6;i++){
			if (!PlayerPrefs.HasKey ("worldUnlocked"+i))
				PlayerPrefs.SetInt ("worldUnlocked"+i, 0);
		}
		

	}
	
	// Update is called once per frame
	void Update () {
		for(int j=2;j<5;j++){
			if(PlayerPrefs.GetInt("worldUnlocked"+j)==1){
				GameObject.Find("Button"+j).GetComponentInChildren<Text>().text="Already puchased.";
			}
		}
		if(PlayerPrefs.GetInt("dust") <2500){
			ui.interactable=false;
		}
		if(PlayerPrefs.GetInt("dust") >=2500){
			ui.interactable=true;
		}
		//Debug.Log (PlayerPrefs.GetInt ("dust"));
		for(int i=1;i<=6;i++){
			if(PlayerPrefs.GetInt("worldUnlocked"+i)==1){
			GameObject.Find("Child For Pictures").gameObject.transform.FindChild("World"+i).FindChild("Locked").gameObject.SetActive(false);

			}

	
	}
}
}
