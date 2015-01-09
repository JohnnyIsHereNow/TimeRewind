using UnityEngine;
using System.Collections;

public class HandlerScript : MonoBehaviour {
	//this should be done only once
	private int movable;
	public Transform objectToMove;	
	public Vector3 vectorToAdd;
	// Update is called once per frame

	void Start(){
		movable=0;
	}
	void Update () {
				if(transform.GetComponent<Animator>().GetBool("Activated")==true && movable <15){
					//move OpenWall
					if(objectToMove.name=="OpenWall")
						{
						objectToMove.transform.position+=vectorToAdd;
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
					movable+=1;
				}
	}
}
