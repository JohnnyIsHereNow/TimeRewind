using UnityEngine;
using System.Collections;

public class NextWeapon : MonoBehaviour {

	private bool nextWeapon=false;
	// Use this for initialization
	void Start () {
		nextWeapon = false;
	}
	void Update(){
		foreach (Touch touch in Input.touches)
		if (guiTexture.HitTest(touch.position) && touch.phase==TouchPhase.Began){
			nextWeapon=true;
		} else nextWeapon =false;
	}
	
	
	#if unity_standalone
	void OnMouseDown(){
		nextWeapon = true;
	}
	void OnMouseUp(){
		nextWeapon = false;
	}
	#endif
	public bool getNextWeapon(){
		return nextWeapon;
	}
	public void setFalse(){
		nextWeapon = false;
	}
}
