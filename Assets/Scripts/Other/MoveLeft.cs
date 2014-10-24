using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour {
	
	private bool moveLeft=false;
	void Update(){
		foreach (Touch touch in Input.touches)
			if (guiTexture.HitTest(touch.position) && touch.phase!=TouchPhase.Ended){
				moveLeft=true;
		} else moveLeft =false;
		
	}
	#if unity_standalone
	// Use this for initialization
	void Start () {
		moveLeft = false;
	}
	
	void OnMouseDown(){
		moveLeft = true;
	}
	#endif
	void OnMouseUp(){
		moveLeft = false;
	}
	public bool getMoveLeft(){
		return moveLeft;
	}
}
