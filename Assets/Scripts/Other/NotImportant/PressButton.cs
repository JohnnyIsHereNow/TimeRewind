using UnityEngine;
using System.Collections;

public class PressButton : MonoBehaviour {
	public Transform objectToMove;
	public Vector3 vectorToAdd;


	// Use this for initialization
	void OnCollisionEnter2D (Collision2D col) {
	if (col.gameObject.tag == "Player" || col.gameObject.name=="RotatableObject") {
			GetComponent<Animator>().SetBool("Activated",true);

			//move OpenWall
			if(objectToMove.name.Equals("OpenWall")){
				objectToMove.GetComponent<MoveWallUp>().setMoveUp(true, vectorToAdd);
			}
			
			//move platform0
			if(objectToMove.name.Equals("PlatformActivateByButton0")){
				objectToMove.GetComponent<MovePlatform>().enabled=true;
			}
			//move platform1
			if(objectToMove.name.Equals("PlatformActivateByButton1")){
				objectToMove.GetComponent<MovePlatform>().enabled=true;
			}//move platform2
			if(objectToMove.name.Equals("PlatformActivateByButton2")){
				objectToMove.GetComponent<MovePlatformUpDown>().enabled=true;
			}
			//move platform4
			if(objectToMove.name.Equals("PlatformActivateByButton4")){
				objectToMove.GetComponent<MovePlatform>().enabled=true;
			}
			//move platform5
			if(objectToMove.name.Equals("PlatformActivateByButton5")){
				objectToMove.GetComponent<MovePlatformUpDown>().enabled=true;
			}



	}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
