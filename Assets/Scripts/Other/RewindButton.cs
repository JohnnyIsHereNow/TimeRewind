using UnityEngine;
using System.Collections;

public class RewindButton : MonoBehaviour {
	
	public static bool rewind=false;
	private bool isRewinding=false;

	IEnumerator justRewind(){
		isRewinding=true;
		TimeScale.RewindTime=true;
		RotationTimeScale.rewind=true;
		yield return new WaitForSeconds(2);
		isRewinding=false;
	}


	void FixedUpdate(){
		//Debug.Log("RewindValue: "+getRewind());
		foreach (Touch touch in Input.touches)
		if (guiTexture.HitTest(touch.position) && touch.phase!=TouchPhase.Ended){
			rewind=true;
		} else rewind =false;
		if((Input.GetKey("q") || rewind==true) && !isRewinding) 
		{	
			StartCoroutine(justRewind());

		} 
		if(!isRewinding)
		{TimeScale.RewindTime=false;
			RotationTimeScale.rewind=false;
		}
	}
	#if unity_standalone
	// Use this for initialization
	void Start () {
		rewind = false;
	}

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
 