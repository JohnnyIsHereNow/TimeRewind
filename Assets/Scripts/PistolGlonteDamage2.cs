using UnityEngine;
using System.Collections;

public class PistolGlonteDamage2 : MonoBehaviour {
	private float speed=0.3f;	
	private int direction =1;	
	private float time=0.0f;
	private float maxTime = 6.0f;
	private GameObject player;
	private GameObject enemy;
	private EnemyOne eo;
	private Enemy2Script e2s;
	private Enemy3Script e3s;
	public GameObject boom;
	private int damage= 50;
	private GameObject moveleft;
	private MoveLeft moveleftbutton;
	private GameObject moveright;
	private MoveRight moverightbutton;
	private Vector3 defaultAcceleration;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		moveleft = GameObject.Find ("left");
		moveleftbutton = moveleft.GetComponent<MoveLeft> ();
		moveright = GameObject.Find ("right");
		moverightbutton = moveright.GetComponent<MoveRight> ();
		defaultAcceleration=Input.acceleration;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.localScale.x == -1)
			direction = -1;
		if (Input.GetKey ("d") || moverightbutton.getMoveRight())
			direction = 1;
		if (Input.GetKey ("a") || moveleftbutton.getMoveLeft())
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
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_PSM || UNITY_EDITOR

		Vector3 changedAcceleration = Input.acceleration-defaultAcceleration;
		//Debug.Log (changedAcceleration);
		//transform.Rotate(new Vector3(0,0, zeroZ));
		transform.Translate(new Vector2(speed*direction,changedAcceleration.y*5));

#endif
#if UNITY_STANDALONE
		transform.Translate(new Vector2(speed*direction,0));
#endif

		
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag != "Player")				
			Instantiate (boom, gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);
		if (col.gameObject.tag == "Enemy" && col.gameObject.name=="Enemy1") {
			enemy=col.gameObject;
			eo=enemy.gameObject.GetComponent<EnemyOne>();
			eo.setLife(damage);
			Destroy(gameObject);			
			Instantiate (boom, gameObject.transform.position, Quaternion.identity);
		}
		if (col.gameObject.tag == "Enemy" && col.gameObject.name=="Enemy2") {
			enemy=col.gameObject;
			e2s=enemy.gameObject.GetComponent<Enemy2Script>();
			e2s.setLife(damage);
			Destroy(gameObject);			
			Instantiate (boom, gameObject.transform.position, Quaternion.identity);
		}
		if (col.gameObject.tag == "Enemy" && col.gameObject.name=="Enemy3") {
			enemy=col.gameObject;
			e3s=enemy.gameObject.GetComponent<Enemy3Script>();
			e3s.setLife(damage);
			Destroy(gameObject);			
			Instantiate (boom, gameObject.transform.position, Quaternion.identity);
		}/*
		if (col.gameObject.tag == "Enemy" && col.gameObject.name=="Enemy4") {
			enemy=col.gameObject;
			e2s=enemy.gameObject.GetComponent<Enemy2Script>();
			e2s.setLife(damage);
			Destroy(gameObject);			
			Instantiate (boom, gameObject.transform.position, Quaternion.identity);
		}*/
	}
	
}
