using UnityEngine;
using System.Collections;

public class RotateWhileNotPlayer : MonoBehaviour {
	private bool touchPlayer=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(touchPlayer==false)
		transform.Rotate(0,0,1f);
	}

}
