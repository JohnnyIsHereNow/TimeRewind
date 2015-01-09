using UnityEngine;
using System.Collections;

public class Enemy1Resize : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {
	if(transform.localScale.x <10){
			transform.localScale+=new Vector3(0.1f,0,0);
	}
	if(transform.localScale.y<12){
			transform.localScale+=new Vector3(0,0.1f,0);
	}
	}
}
