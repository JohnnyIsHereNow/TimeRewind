
using UnityEngine;
using System.Collections;

public class AddVelocityToPlatform : MonoBehaviour {
	private float movingSpeed;
	private Rigidbody2D r;

	void Start(){
		movingSpeed = -0.1f;
		r=GetComponent<Rigidbody2D>();
	}
	// Update is called once per frame
	void Update () {
		StartCoroutine(waitSeconds());
	}
	private IEnumerator waitSeconds(){
		yield return new WaitForSeconds(3);
		AddVelocity();
	}
	// Update is called once per frame
	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy") {
			col.transform.Translate (new Vector2 (movingSpeed, 0));
			
		}
	}
	private void AddVelocity(){
		if(r.velocity.x <0 && r.velocity.x>-2) {
			//add negative velocity
			Vector2 vec = new Vector2(-5,0);
			r.velocity +=vec;
			movingSpeed=-movingSpeed;
		}else if (r.velocity.x >=0 && r.velocity.x<3){
			//add positive velocity
			Vector2 vec = new Vector2(5,0);
			r.velocity +=vec;
			movingSpeed=-movingSpeed;
		}

	}
}
