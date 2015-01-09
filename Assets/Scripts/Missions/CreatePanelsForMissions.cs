using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CreatePanelsForMissions : MonoBehaviour {
	public Transform t1,t2,t3,t4;
	public Transform t5,t6,t7,t8;
	public string[] st;
	void Start(){


	}
	// Use this for initialization
	void Update () {
		int i=0;
		int j=1;

		while(j<=PlayerPrefs.GetInt("NumberOfMissions")){
			if(i<2){
			st=(PlayerPrefs.GetString(""+j)).Split(',');
			if(!st[3].Equals(st[4])){					
				i++;
				//am gasit unul
				switch(i){
				case 1:
						t1.GetComponent<Text>().text="#"+st[0];
						t2.GetComponent<Text>().text=st[1];
						t3.GetComponent<Text>().text=st[2];
						t4.GetComponent<Text>().text="Progress: "+st[4]+"/"+st[3];
					break;
				case 2:					
						t5.GetComponent<Text>().text="#"+st[0];
						t6.GetComponent<Text>().text=st[1];
						t7.GetComponent<Text>().text=st[2];
						t8.GetComponent<Text>().text="Progress: "+st[4]+"/"+st[3];
					break;
				}
			}
			
		}
			j++;
		}
	}
}
