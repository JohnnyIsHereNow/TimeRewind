using UnityEngine;
using System.Collections;

public class MovePlatformUpDown: MonoBehaviour {
	private bool goDown = true;
	private Vector3 pos,pos2;
	private GameObject player;
	private float movingSpeed;
	// Use this for initialization
	void Start () {
		movingSpeed = -0.1f;
		pos = transform.position;
		pos2 = new Vector3 (transform.position.x,transform.position.y-6,transform.position.z);
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
		if (transform.position.y > pos.y) {
			movingSpeed=-movingSpeed;
			goDown=true;		
		}
		if (transform.position.y < pos2.y) {			
			movingSpeed=-movingSpeed;
			goDown=false;		
		}
			transform.Translate(0,movingSpeed,0);
		
	}
}
