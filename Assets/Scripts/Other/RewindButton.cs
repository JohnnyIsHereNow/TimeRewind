using UnityEngine;
using System.Collections;

public class RewindButton : MonoBehaviour {

	public static bool rewind=false;
	void FixedUpdate(){



		Debug.Log("RewindValue: "+getRewind());
		foreach (Touch touch in Input.touches)
		if (guiTexture.HitTest(touch.position) && touch.phase!=TouchPhase.Ended){
			rewind=true;
		} else rewind =false;
		if(Input.GetKey("q") || rewind==true) 
		{	TimeScale.RewindTime=true;
			RotationTimeScale.rewind=true;
		} else 
		{TimeScale.RewindTime=false;
			RotationTimeScale.rewind=false;
		}
	}
	#if unity_standalone
	// Use this for initialization
	void Start () {
		rewind = false;
	}
	q
	void OnMouseDown(){
		rewind = true;
	}
	void OnMouseUp(){
		rewind = false;
	}	
	#endif
	public bool getRewind(){
		return rewind;
	}
}
 