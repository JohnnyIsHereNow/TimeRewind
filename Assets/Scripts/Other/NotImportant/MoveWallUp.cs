using UnityEngine;
using System.Collections;

public class MoveWallUp : MonoBehaviour {
	private bool moveUp;
	private int movable;
	private Vector3 vectorToAdd;
	// Use this for initialization
	void Start () {
		moveUp=false;
		movable=1;
		vectorToAdd=Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(moveUp){
		movable+=1;
		}
		if(movable<15 && moveUp){
			transform.position += vectorToAdd;
		}
	}

	public void setMoveUp(bool moveUp, Vector3 vectorToAdd){
		this.moveUp=moveUp;
		this.vectorToAdd=vectorToAdd;
	}
}
