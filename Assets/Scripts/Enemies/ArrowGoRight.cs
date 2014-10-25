using UnityEngine;
using System.Collections;

public class ArrowGoRight : MonoBehaviour {

	// Use this for initialization
	void Update () {
		transform.Translate(0.4f,0,0);
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D col){
		Destroy(gameObject);
	}
}
