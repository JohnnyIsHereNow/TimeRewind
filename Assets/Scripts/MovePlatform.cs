using UnityEngine;
using System.Collections;

public class MovePlatform: MonoBehaviour {
	private bool goDown = true;
	private Vector3 pos,pos2;
	private GameObject player;
	private float movingSpeed;
	// Use this for initialization
	void Start () {
		movingSpeed = -0.1f;
		pos = transform.position;
		pos2 = new Vector3 (transform.position.x-6,transform.position.y,transform.position.z);
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag=="Enemy" || col.gameObject.tag=="Player" || col.gameObject.tag=="Ground")
		if(col.gameObject.transform.position.y<transform.position.y){
			movingSpeed=-movingSpeed;
			if(goDown) goDown=false; else goDown=true;
		}
	}
	
	public void FixedUpdate(){
		if (transform.position.x > pos.x) {
			movingSpeed=-movingSpeed;
			goDown=true;		
		}
		if (transform.position.x < pos2.x) {			
			movingSpeed=-movingSpeed;
			goDown=false;		
		}
		transform.Translate(movingSpeed,0,0);
		
	}
}
