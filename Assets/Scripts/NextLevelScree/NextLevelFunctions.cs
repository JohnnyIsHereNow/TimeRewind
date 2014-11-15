using UnityEngine;
using System.Collections;

public class NextLevelFunctions : MonoBehaviour {
	private GameObject levelCompleteInterface;
	public void BackToMainMenu(){
		Application.LoadLevel("startScene");
	}
	public void GetBackToNormal(){
		levelCompleteInterface=GameObject.Find("LevelCompleteInterface");
		Time.timeScale=1.0f;
		levelCompleteInterface.SetActive(false);
	}


	public void NextLevel(){
		//the name is level01-01
		string nextLevelName = Application.loadedLevelName.Substring(5,5);
		//changeTheNumber
		string[] numbers = nextLevelName.Split('-');
		if(int.Parse(numbers[1])==30){
			//go back to world screen
			Application.LoadLevel("loadWorldScene");
		}else{
			//change to the next level
			//get number into int
			int levelNumber=int.Parse(numbers[1]);
			//increment by one
			levelNumber++;
			//check if its smaller than 10;
			if(levelNumber<10) 
				numbers[1]="0"+levelNumber;
			else
				numbers[1]=""+levelNumber;

		//save the new name inside nextLevelName
			nextLevelName=numbers[0]+"-"+numbers[1];
			
		}
		GetBackToNormal();
		//load scene
		Application.LoadLevel("level"+nextLevelName);

	}
	public void ReplayLevel(){
		GetBackToNormal();
		Application.LoadLevel(Application.loadedLevelName);
	}
	public void FacebookShare(){
	
	}
	public void TwiterShare(){

	}
}
