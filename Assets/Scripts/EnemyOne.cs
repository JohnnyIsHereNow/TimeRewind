using UnityEngine;
using System.Collections;

public class EnemyOne : MonoBehaviour {
	private int life;
	private float speed;
	private bool moveEnemy;
	public GameObject boom;

	// Use this for initialization
	void Start () {
		moveEnemy=false;
		life = 10;
		speed= 5f;
	}
	public void setLife(int minusLife){
		life-=minusLife;
	}

	void OnCollisionStay2D(Collision2D col){
		moveEnemy=true;
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag=="Ground" || col.gameObject.tag=="Obstacles" || col.gameObject.tag=="Key" || col.gameObject.tag=="Enemy"){

			if(col.gameObject.transform.position.x< transform.position.x)
			{
				speed=-5f;
			}else speed=5f;
		}
		
	}



	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 (-speed*Time.deltaTime, 0,0);
		if(moveEnemy) transform.position += pos;
		if (life <= 0){
			destroyMe();	
						
		}
	}
	public void destroyMe(){
		Instantiate(boom, transform.position,Quaternion.identity);
		Destroy (gameObject);
	}

}
