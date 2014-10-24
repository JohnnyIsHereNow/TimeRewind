using UnityEngine;
using System.Collections;

public class PistolGlonteDamage : MonoBehaviour {
	private float speed=1.0f;	
	private int direction =1;	
	private float time=0.0f;
	private float maxTime = 3.0f;
	private GameObject player;
	private GameObject enemy;
	private EnemyOne eo;
	public GameObject boom;
	private int damage= 20;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.localScale.x == -1)
						direction = -1;
		if (Input.GetKey ("d"))
			direction = 1;
		if (Input.GetKey ("a"))
			direction = -1;
		time = time+Time.deltaTime;
		if (time > maxTime)
						Destroy (gameObject);
		if (direction == 1) {
			Vector3 scale = new Vector2 (1, 1);
			transform.localScale = scale;
		} else {
			Vector3 scale = new Vector2 (-1, 1);
			transform.localScale = scale;
		}

		transform.Translate(new Vector2(speed*direction,0));

	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag != "Player")				
			Instantiate (boom, gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);
		if (col.gameObject.tag == "Enemy") {
			enemy=col.gameObject;
			eo=enemy.gameObject.GetComponent<EnemyOne>();
			eo.setLife(damage);
			Destroy(gameObject);			
			Instantiate (boom, gameObject.transform.position, Quaternion.identity);
				}
	}

}
