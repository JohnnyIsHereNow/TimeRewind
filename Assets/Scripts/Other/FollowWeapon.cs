using UnityEngine;
using System.Collections;

public class FollowWeapon : MonoBehaviour {
	private GameObject weapon;

	// Use this for initialization
	void Start () {
		weapon = GameObject.FindGameObjectWithTag ("Weapon");
	}
	
	// Update is called once per frame
	void Update () {		
		
		StartCoroutine (KillOnAnimationEnd ());
		Vector3 vec = new Vector3 (weapon.transform.position.x, weapon.transform.position.y, 0);
		vec.y += -0.5f;
		transform.position = vec;
	
	}
	private IEnumerator KillOnAnimationEnd() {
		yield return new WaitForSeconds (0.2f);
		Destroy (gameObject);
	}
}
