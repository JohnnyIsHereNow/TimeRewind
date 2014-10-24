using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {
	private float movingSpeed;
	private float maxGone;
	private float gone;
	private GameObject player;
	// Use this for initialization
	void Start () {
		movingSpeed = -0.1f;
		maxGone = 10;
		gone = 0;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void OnCollisionStay2D(Collision2D col){
				if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy") {
						col.transform.Translate (new Vector2 (movingSpeed, 0));

				}
		}
	void Update () {
				transform.Translate (new Vector2 (movingSpeed, 0));
				gone += 0.1f;

				if (gone >= maxGone)
		{
						gone = 0;
			if(movingSpeed==-0.1f)
						movingSpeed = 0.1f;
			else movingSpeed=-0.1f;
		}
	}
}
