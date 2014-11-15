using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ShowNumberOfEnemiesKilled : MonoBehaviour {
	public Text text;
	// Use this for initialization
	void Start () {
		text= GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.HasKey("numberOfEnemiesKilled"))
		text.text=""+PlayerPrefs.GetInt("numberOfEnemiesKilled");
	}
}
