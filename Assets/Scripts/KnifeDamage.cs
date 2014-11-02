using UnityEngine;
using System.Collections;

public class KnifeDamage : MonoBehaviour {
	private int damage=10;
	private GameObject enemy;
	private Enemy2Script e2s;
	private EnemyOne eo;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Enemy" && col.gameObject.name=="Enemy1" && PlayerController.attackWithKnife) {
			enemy=col.gameObject;
			eo=enemy.gameObject.GetComponent<EnemyOne>();
			eo.setLife(damage);
		}
		if (col.gameObject.tag == "Enemy" && col.gameObject.name=="Enemy2" && PlayerController.attackWithKnife) {
			enemy=col.gameObject;
			e2s=enemy.gameObject.GetComponent<Enemy2Script>();
			e2s.setLife(damage);
		}
	}
}
