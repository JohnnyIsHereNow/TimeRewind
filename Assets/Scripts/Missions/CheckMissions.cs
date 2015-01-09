using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CheckMissions : MonoBehaviour {
	private int missionOne=0;
	private int missionTwo=0;
	public RectTransform finishPanel;
	public Text tex;
	string[] st;
	int number=-1;
	void Start(){
		finishPanel.anchoredPosition=new Vector2(0,50);
		//PlayerPrefs.DeleteAll();
	}

	void FixedUpdate () {
	//check to see what missions are available
		int i=0;
		int j=1;
		
		while(j<=PlayerPrefs.GetInt("NumberOfMissions")){
			if(i<2){
				st=(PlayerPrefs.GetString(""+j)).Split(',');
				if(!st[3].Equals(st[4])){					
					i++;
					if(i==1){
						missionOne=int.Parse(st[0]);
					}
					if(i==2){
						missionTwo=int.Parse(st[0]);
					}
				}
			}
			j++;
		}

	//impletement all missions
	//choose switchs or ifs

		//destroy 1 enemy
		if(missionOne==1 || missionTwo==1){
				number=missionOne;
				if(missionTwo==1) number=missionTwo;
			//Debug.Log("Number: "+number);
			if(PlayerPrefs.GetInt("numberOfEnemiesKilled")>=1){
				st=(PlayerPrefs.GetString(""+number)).Split(',');
				PlayerPrefs.SetString(""+st[0],""+st[0]+","+st[1]+","+st[2]+","+st[3]+","+1);
				st=(PlayerPrefs.GetString(""+number)).Split(',');
				//give reward

				//show panel
				if(st[3].Equals(st[4])){
				tex.text="Nice job ! You just finised a mission: "+st[1];
				StartCoroutine(showPanel());
				}
			}
		}
		//destroy 3 enemies
		if(missionOne==2 || missionTwo==2){
					number=missionOne;
					if(missionTwo==2) number=missionTwo;
			if(PlayerPrefs.GetInt("numberOfEnemiesKilled")<=3 && PlayerPrefs.GetInt("numberOfEnemiesKilled")>0){
				st=(PlayerPrefs.GetString(""+number)).Split(',');
				PlayerPrefs.SetString(""+st[0],""+st[0]+","+st[1]+","+st[2]+","+st[3]+","+PlayerPrefs.GetInt("numberOfEnemiesKilled"));
				st=(PlayerPrefs.GetString(""+number)).Split(',');
				//give reward
				
				//show panel
				if(st[3].Equals(st[4])){
				tex.text="Nice job ! You just finised a mission: "+st[1];
				StartCoroutine(showPanel());
				}
		}
		}
		//get 10 dust
		if(missionOne==3 || missionTwo==3){
					number=missionOne;
					if(missionTwo==3) number=missionTwo;
			if(PlayerPrefs.GetInt("dust")>=10){
				st=(PlayerPrefs.GetString(""+number)).Split(',');
				PlayerPrefs.SetString(""+st[0],""+st[0]+","+st[1]+","+st[2]+","+st[3]+","+"10");
				st=(PlayerPrefs.GetString(""+number)).Split(',');
				//show panel
				if(st[3].Equals(st[4])){
				tex.text="Nice job ! You just finised a mission: "+st[1];
				StartCoroutine(showPanel());
				}
			}
		}
		//rewind time three times
		if(missionOne==4 || missionTwo==4){
					number=missionOne;
					if(missionTwo==4) number=missionTwo;
			if(Input.GetKeyDown("q") || RewindButton.rewind==true){
				st=(PlayerPrefs.GetString(""+number)).Split(',');
				if(int.Parse(st[4])<3)
				PlayerPrefs.SetString(""+st[0],""+st[0]+","+st[1]+","+st[2]+","+st[3]+","+(int.Parse(st[4])+1));
				st=(PlayerPrefs.GetString(""+number)).Split(',');
				//show panel
				if(st[3].Equals(st[4])){
					tex.text="Nice job ! You just finised a mission: "+st[1];
					StartCoroutine(showPanel());
				}
			}
		}
		//get 30 dust
		if(missionOne==5 || missionTwo==5){
			number=missionOne;
			if(missionTwo==5) number=missionTwo;
			if(PlayerPrefs.GetInt("dust")>=30){
				st=(PlayerPrefs.GetString(""+number)).Split(',');
				PlayerPrefs.SetString(""+st[0],""+st[0]+","+st[1]+","+st[2]+","+st[3]+","+"30");
				st=(PlayerPrefs.GetString(""+number)).Split(',');
				//show panel
				if(st[3].Equals(st[4])){
					tex.text="Nice job ! You just finised a mission: "+st[1];
					StartCoroutine(showPanel());
				}
			}else{
				st=(PlayerPrefs.GetString(""+number)).Split(',');
				PlayerPrefs.SetString(""+st[0],""+st[0]+","+st[1]+","+st[2]+","+st[3]+","+PlayerPrefs.GetInt("dust"));
			}
		}

	
	}
	private IEnumerator showPanel(){
		finishPanel.anchoredPosition=new Vector2(0,50);
		if(finishPanel.anchoredPosition.y>0)
			finishPanel.anchoredPosition=new Vector2(0,0);
		yield return new WaitForSeconds(5);		
		if(finishPanel.anchoredPosition.y<50)
			finishPanel.anchoredPosition=new Vector2(0,50);
	}
}
