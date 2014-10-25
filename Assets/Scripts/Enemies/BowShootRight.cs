using UnityEngine;
using System.Collections;

public class BowShootRight : MonoBehaviour {
	public GameObject arrow;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void MakeArrow(){
		Instantiate(arrow, transform.position,Quaternion.identity);
	}
}
