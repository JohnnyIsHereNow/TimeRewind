using UnityEngine;
using System.Collections;

public class StarForTIME : MonoBehaviour {
	Vector3 vec;
	// Use this for initialization
	void Start () {
		vec= new Vector3(0,0,-5);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (vec);
	}

	public void destroyStar(){
		Destroy(gameObject);
	}
}
