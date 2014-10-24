using UnityEngine;
using System.Collections;

public class JumpButton : MonoBehaviour {
	private bool jump=false;
	// Use this for initialization
	void Start () {
		jump = false;
	}
	void Update(){
		foreach (Touch touch in Input.touches)
		if (guiTexture.HitTest(touch.position) && touch.phase!=TouchPhase.Ended){
			jump=true;
		} else jump =false;
	}
	
	
	#if unity_standalone || unity_editor
	void OnMouseDown(){
				jump = true;
		}
	void OnMouseUp(){
		jump = false;
	}
	#endif
	public bool getJump(){
		return jump;
	}
}
