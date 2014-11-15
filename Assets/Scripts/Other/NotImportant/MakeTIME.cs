using UnityEngine;
using System.Collections;

public class MakeTIME : MonoBehaviour {
	public GameObject t,i,m,e;
	// Use this for initialization
	void Start () {
			if(PlayerPrefs.HasKey("TIMEMission")){
			if(PlayerPrefs.GetString("TIMEMission")=="")
			{
				Instantiate(t,transform.position,Quaternion.identity);
				//make sprite =t
			}
			if(PlayerPrefs.GetString("TIMEMission")=="T")
			{
				Instantiate(i,transform.position,Quaternion.identity);
				//make sprite =i
			}if(PlayerPrefs.GetString("TIMEMission")=="TI")
			{
				Instantiate(m,transform.position,Quaternion.identity);
				//make sprite =m
			}if(PlayerPrefs.GetString("TIMEMission")=="TIM")
			{
				Instantiate(e,transform.position,Quaternion.identity);
				//make sprite =e
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
