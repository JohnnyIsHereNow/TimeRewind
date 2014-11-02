using UnityEngine;
using System.Collections;

public class ArrowGoRight : MonoBehaviour {

	// Use this for initialization
	void Update () {
		transform.Translate(0.4f,0,0);
	}
	IEnumerator zeroSec(){
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D col){
		StartCoroutine(zeroSec());
	}
	void OnTriggerEnter2D(Collider2D col){
		StartCoroutine(zeroSec());
	}
}
