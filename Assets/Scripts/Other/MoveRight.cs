using UnityEngine;
using System.Collections;

public class MoveRight : MonoBehaviour {

	private bool moveRight=false;
	// Use this for initialization
	void Start () {
		moveRight = false;
	}
	void Update(){
		foreach (Touch touch in Input.touches)
		if (guiTexture.HitTest(touch.position) && touch.phase!=TouchPhase.Ended){
			moveRight=true;
		} else moveRight =false;
	}
	
	
	#if unity_standalone
	void OnMouseDown(){
		moveRight = true;
	}
	void OnMouseUp(){
		moveRight = false;
	}
	#endif
	public bool getMoveRight(){
		return moveRight;
	}
}
