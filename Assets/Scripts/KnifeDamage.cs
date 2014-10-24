using UnityEngine;
using System.Collections;

public class KnifeDamage : MonoBehaviour {
	private int damage=10;
	private GameObject enemy;
	private EnemyOne eo;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Enemy") {
			enemy=col.gameObject;
			eo=enemy.gameObject.GetComponent<EnemyOne>();
			eo.setLife(damage);
		}
	}
}
