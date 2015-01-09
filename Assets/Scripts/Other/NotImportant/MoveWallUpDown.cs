using UnityEngine;
using System.Collections;

public class MoveWallUpDown : MonoBehaviour {
	private bool goDown = true;
	private Vector3 pos;
	//methods
	public void Start(){
		pos = transform.position;
		}
	public void FixedUpdate(){
		if (transform.position.y > pos.y) {
			goDown=true;		
		}
		if (goDown) {
			transform.Translate(0,-0.1f,0);
				} else {
			transform.Translate(0,0.1f,0);
				}
		}



    public void OnTriggerEnter2D(Collider2D col){
	if (col.gameObject.tag == "Enemy" || col.gameObject.tag=="Ground" || col.gameObject.tag=="Player") {
			if(goDown) goDown=false;
		}
	}

}
