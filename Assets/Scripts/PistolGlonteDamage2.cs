using UnityEngine;
using System.Collections;

public class PistolGlonteDamage2 : MonoBehaviour {
	private float speed=0.3f;	
	private int direction =1;	
	private float time=0.0f;
	private float maxTime = 3.0f;
	private GameObject player;
	private GameObject enemy;
	private EnemyOne eo;
	public GameObject boom;
	private int damage= 20;
	private GameObject moveleft;
	private MoveLeft moveleftbutton;
	private GameObject moveright;
	private MoveRight moverightbutton;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		moveleft = GameObject.Find ("left");
		moveleftbutton = moveleft.GetComponent<MoveLeft> ();
		moveright = GameObject.Find ("right");
		moverightbutton = moveright.GetComponent<MoveRight> ();
		
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
		float zeroZ=0.9623718f;
		float zeroY=0.1754303f;
		zeroZ=Input.acceleration.z+zeroZ;
		zeroY+=Input.acceleration.y;
		//Debug.Log (Input.acceleration.y);
		//transform.Rotate(new Vector3(0,0, zeroZ));
		transform.Translate(new Vector2(speed*direction,zeroY*10));

#endif
#if UNITY_STANDALONE
		transform.Translate(new Vector2(speed*direction,0));
#endif

		
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
