using UnityEngine;
using System.Collections;

public class CreateMissions : MonoBehaviour {
	
	void Start () {
			PlayerPrefs.DeleteAll();
			//if(!PlayerPrefs.HasKey("NumberOfMissions")){
			PlayerPrefs.SetInt("NumberOfMissions",0);
			//}
			if(!PlayerPrefs.HasKey("FinishLevel1")){
			//create missions here
			Mission m = new Mission(1,"First enemy","Destroy one enemy !", 1);
				PlayerPrefs.SetInt("NumberOfMissions",PlayerPrefs.GetInt("NumberOfMissions")+1);
			Mission m2 = new Mission(2,"After 3","Destroy 3 enemies", 3);
				PlayerPrefs.SetInt("NumberOfMissions",PlayerPrefs.GetInt("NumberOfMissions")+1);
			Mission m3 = new Mission(3,"First dust","You need to have 10 dust",10);
				PlayerPrefs.SetInt("NumberOfMissions",PlayerPrefs.GetInt("NumberOfMissions")+1);
			Mission m4 = new Mission(4,"Rewind","Rewind the time three times",3);
				PlayerPrefs.SetInt("NumberOfMissions",PlayerPrefs.GetInt("NumberOfMissions")+1);
			Mission m5 = new Mission(5,"Get more dust","Get 30 dust in total !",30);
				PlayerPrefs.SetInt("NumberOfMissions",PlayerPrefs.GetInt("NumberOfMissions")+1);
		}
	}
}
