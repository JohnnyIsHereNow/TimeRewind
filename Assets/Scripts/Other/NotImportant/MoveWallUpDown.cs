using UnityEngine;
using System.Collections;

public class MoveWallUpDown : MonoBehaviour {
	public float movingSpeed;
	public bool change=true;
	// Use this for initialization
	void Start () {
		movingSpeed = -0.3f;
	}
	
	private IEnumerator changeSpeed(){
		yield return new WaitForSeconds(3);
		movingSpeed=-movingSpeed;
		change=true;
	}
	
	// Update is called once per frame
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag=="Enemy" || col.gameObject.tag=="Player" || col.gameObject.tag=="Ground")
		if(col.gameObject.transform.position.y<transform.position.y){
			movingSpeed=-movingSpeed;
			change=true;
		}
	}
	
	void Update () {
		if(change)	{
			change=false;
			StartCoroutine(changeSpeed());
		}
		transform.Translate (new Vector2 (0,movingSpeed));
	}
}
