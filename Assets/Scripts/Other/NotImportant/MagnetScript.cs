using UnityEngine;
using System.Collections;

public class MagnetScript : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {		

		player=GameObject.Find("Player");
	}

	private IEnumerator waitFiveSeconds(){

		yield return new WaitForSeconds(5);
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(waitFiveSeconds());
		transform.position = player.transform.position;
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag=="Dust")
		{
			//Debug.Log ("Dust collected.");
			//damn c#
			Vector3 vecX = new Vector3(1,0,0);
			Vector3 vecY= new Vector3(0,1,0);
			if(col.gameObject.transform.position.x > player.transform.position.x) 
				col.transform.position-=vecX;
			else 
				col.transform.position+=vecX;
			if(col.gameObject.transform.position.y > player.transform.position.y) 
				col.transform.position-=vecY;
			else 
				col.transform.position+=vecY;
		}
	}
}
