using UnityEngine;
using System.Collections;

public class RotateLeftAndRight : MonoBehaviour {
	int r;
	// Use this for initialization
	void Start () {
	
	}
	IEnumerator rand(){
		r=Random.Range(0,2);
		yield return new WaitForSeconds(5);
	}
	// Update is called once per frame
	void Update () {
		StartCoroutine(rand ());
		if(r==1)
			transform.Rotate(0,0,60);
		else
			transform.Rotate(0,0,-60);
	}
}
