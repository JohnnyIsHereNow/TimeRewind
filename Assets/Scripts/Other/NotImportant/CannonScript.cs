
using UnityEngine;
using System.Collections;

public class CannonScript : MonoBehaviour {
	public Transform cannonBall;
	private Transform cb;
	public Transform spawnPoint;
	private bool launch=true;
	// Use this for initialization



	void FixedUpdate(){
		if(launch)
		StartCoroutine(lauchABall());

	}

	IEnumerator lauchABall(){
		launch=false;
		yield return new WaitForSeconds(3);
		launchCannonBall();


	}




	public void launchCannonBall()
	{
		if(cannonBall!=null){
			
			transform.GetComponent<Animator>().SetTrigger("Shoot");
			cb=Instantiate(cannonBall, spawnPoint.position,Quaternion.identity) as Transform;
			//test
			cb.rigidbody2D.velocity+= new Vector2(60,0);
			//cb.rigidbody2D.AddForce(new Vector3(100,100,0));
			//end test
		}else{
			Debug.Log ("No cannon ball.");
		}
		launch=true;
	}
}
