using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonActions : MonoBehaviour {
	private GameObject player;
	private GameObject b,b2,b3;

		

	IEnumerator FiveSecondsTime(){
		b3=GameObject.Find("ShoeButton");
		b3.GetComponent<Image>().enabled=false;
		b3.GetComponentInChildren<Text>().enabled=false;
		PlayerController.maxspeed = 50;
		PlayerController.velocityy = 40;
		PlayerController.velocityx = 25;
		yield return new WaitForSeconds(3);		
		PlayerController.maxspeed = 24;
		PlayerController.velocityy = 27;
		PlayerController.velocityx = 16;
		b3.GetComponent<Image>().enabled=true;
		b3.GetComponentInChildren<Text>().enabled=true;
	}
	
	IEnumerator FiveSecondsForShield1(){
		player.transform.FindChild ("protectiveShield").GetComponent<SpriteRenderer> ().enabled = true;
		PlayerPrefs.SetInt("Shield",1);
		b=GameObject.Find("Shield1Button");
		b.GetComponent<Image>().enabled=false;
		b.GetComponentInChildren<Text>().enabled=false;
		yield return new WaitForSeconds (5);
		player.transform.FindChild ("protectiveShield").GetComponent<SpriteRenderer> ().enabled = false;
		b.GetComponent<Image>().enabled=true;
		b.GetComponentInChildren<Text>().enabled=true;
		PlayerPrefs.SetInt("Shield",0);
	}
	IEnumerator FiveSecondsForShield2(){
		PlayerPrefs.SetInt("Shield2",1);
		b2=GameObject.Find("Shield2Button");
		player.transform.FindChild ("killEnemiesShield").GetComponent<SpriteRenderer> ().enabled = true;
		b2.GetComponent<Image>().enabled=false;
		b2.GetComponentInChildren<Text>().enabled=false;
		yield return new WaitForSeconds (5);
		player.transform.FindChild ("killEnemiesShield").GetComponent<SpriteRenderer> ().enabled = false;
		b2.GetComponent<Image>().enabled=true;
		b2.GetComponentInChildren<Text>().enabled=true;
		PlayerPrefs.SetInt("Shield2",0);
	}

	public void TakeShoe(){
		player=GameObject.Find("Player");
		if(PlayerPrefs.HasKey("NumberOfShoes") && PlayerPrefs.GetInt("NumberOfShoes")>0){
			PlayerPrefs.SetInt("NumberOfShoes", PlayerPrefs.GetInt("NumberOfShoes")-1);
			StartCoroutine (FiveSecondsTime());
		}

	}

	public void TakeShield1(){
		player=GameObject.Find("Player");
		if(PlayerPrefs.HasKey("NumberOfShields1") && PlayerPrefs.GetInt("NumberOfShields1")>0){
		PlayerPrefs.SetInt ("NumberOfShields1",PlayerPrefs.GetInt("NumberOfShields1")-1);
			StartCoroutine (FiveSecondsForShield1 ());
		}
	}
	public void TakeShield2(){				
		player=GameObject.Find("Player");
		if(PlayerPrefs.HasKey("NumberOfShields2") && PlayerPrefs.GetInt("NumberOfShields2")>0){
			PlayerPrefs.SetInt ("NumberOfShields2",PlayerPrefs.GetInt("NumberOfShields2")-1);
			StartCoroutine (FiveSecondsForShield2 ());
		}
	}
}
