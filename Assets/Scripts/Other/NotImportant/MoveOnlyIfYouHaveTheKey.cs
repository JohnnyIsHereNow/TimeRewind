using UnityEngine;
using System.Collections;

public class MoveOnlyIfYouHaveTheKey : MonoBehaviour {
	private GameObject door;
	private bool done=false;
	// Use this for initialization
	void Start () {
		door = GameObject.Find("Door");
	}
	public IEnumerator WaitSixSeconds(){
		done=true;
		yield return new WaitForSeconds(6);
		DisableMovement();
		done=false;
	}

	private void DisableMovement(){
		//disable movement if you lose the key
		if(GetComponent<MovePlatformUpDown>().enabled==true){
				GetComponent<MovePlatformUpDown>().enabled=false;
				
		}
	}
	//============================================Update===============================

	void Update () {
//activate script if is not activate and make platform move
	if(GetComponent<MovePlatformUpDown>().enabled==false){
			if(door.GetComponent<Animator>().GetBool("HasKey")==true && !done){
				GetComponent<MovePlatformUpDown>().enabled=true;
				StartCoroutine(WaitSixSeconds());
			}

		}

	}
}
