using UnityEngine;
using System.Collections;

public class NinjaStarMovement : MonoBehaviour {
	private int speed=100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.timeScale!=0){
		transform.Rotate(new Vector3(0,0,5));
		rigidbody2D.AddForce(new Vector2(speed,5));
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		speed=-speed;
	}
	void OnCollisionEnter2D(Collision2D col){
		speed=-speed;
	}
}
