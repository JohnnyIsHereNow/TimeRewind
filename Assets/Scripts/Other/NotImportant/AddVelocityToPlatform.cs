using UnityEngine;
using System.Collections;

public class AddVelocityToPlatform : MonoBehaviour {
	private Rigidbody2D r;

	void Start(){
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
	private void AddVelocity(){
		if(r.velocity.x <0 && r.velocity.x>-2) {
			//add negative velocity
			Vector2 vec = new Vector2(-5,0);
			r.velocity +=vec;
		}else if (r.velocity.x >=0 && r.velocity.x<3){
			//add positive velocity
			Vector2 vec = new Vector2(5,0);
			r.velocity +=vec;
		}

	}
}
