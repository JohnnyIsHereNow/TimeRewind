using UnityEngine;
using System.Collections;

public class AfterChestOpens : MonoBehaviour {
	public GameObject[] prizes = new GameObject[3];

	IEnumerator waitOneSecond(){
		yield return new WaitForSeconds (1);
		int rnd = Random.Range (0, 3);
		int rnd2 = Random.Range (0, 3);
		if (rnd == 0)
			Instantiate (prizes [0], new Vector3(transform.position.x-2.2f,transform.position.y,transform.position.z), Quaternion.identity);
		else if(rnd==1)
			Instantiate (prizes [1],  new Vector3(transform.position.x-2.2f,transform.position.y,transform.position.z), Quaternion.identity);
		else
			Instantiate (prizes [2],  new Vector3(transform.position.x-2.2f,transform.position.y,transform.position.z), Quaternion.identity);
		if (rnd2 == 0)
			Instantiate (prizes [0], new Vector3(transform.position.x+2.2f,transform.position.y,transform.position.z), Quaternion.identity);
		else if(rnd2==1)
			Instantiate (prizes [1],  new Vector3(transform.position.x+2.2f,transform.position.y,transform.position.z), Quaternion.identity);
		else
			Instantiate (prizes [2],  new Vector3(transform.position.x+2.2f,transform.position.y,transform.position.z), Quaternion.identity);

	}

	// Update is called once per frame
	void Update () {
		}

	public void awordPrize(){
		StartCoroutine (waitOneSecond ());
	}
}
