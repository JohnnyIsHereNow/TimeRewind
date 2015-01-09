using UnityEngine;
using System.Collections;

public class Enemy4Script : MonoBehaviour {
	// Use this for initialization
	public GameObject enemy1;
	private GameObject obj1,obj2;
	// Update is called once per frame
	void Update () {
		if(transform.rigidbody2D.velocity.y==4 || transform.rigidbody2D.velocity.y==0){
			transform.rigidbody2D.velocity+=new Vector2(0,20.0f);

		}


		//make it random
		if(Random.Range(0,500)==5)
			transform.GetComponent<Animator>().SetTrigger("MakeEnemies");

		//StartCoroutine(floating());		
		transform.rigidbody2D.velocity-=new Vector2(0,0.1f);
	}




	IEnumerator floating(){
		//transform.Translate(new Vector3(0,0.3f,0));
		transform.rigidbody2D.velocity+=new Vector2(0,1.0f);
		yield return new WaitForSeconds(2);
	}


	public void createEnemies(){

		obj1=(GameObject)Instantiate(enemy1,transform.FindChild("body").FindChild("weapon").transform.position,Quaternion.identity);
		obj2=(GameObject)Instantiate(enemy1,transform.FindChild("body").FindChild("weapon2").transform.position,Quaternion.identity);
		obj1.transform.rigidbody2D.AddForce(new Vector3(-5,5,0));
		obj2.transform.rigidbody2D.AddForce(new Vector3(5,5,0));
	}
}
