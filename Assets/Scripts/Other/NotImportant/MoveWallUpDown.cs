using UnityEngine;
using System.Collections;

public class MoveWallUpDown : MonoBehaviour {
	//testing stupid version for this code
	private float time1=0.0f;
	private float time2=0.0f;
	private float numberOfSeconds=2.5f;
	private bool goDown = true;

	//methods
	public void Start(){
		}
	public void FixedUpdate(){
				time2 = Time.time;
				//Debug.Log (numberOfSeconds);

				if (time2 - time1 > numberOfSeconds) {
					time1=Time.time;
					if(goDown) goDown=false; else goDown=true;
					numberOfSeconds = 2.5f;
				}
				if (goDown) {				
					transform.Translate(new Vector3(0.0f,-0.1f,0.0f));
				} else {
					transform.Translate(new Vector3(0.0f,0.1f,0.0f));
				}
				
		}



    public void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Enemy") {
			numberOfSeconds=time2-time1;
			time1=Time.time;
			if(goDown) goDown=false; else goDown=true;
		}
	}

}
