using UnityEngine;
using System.Collections;

public class MoveObjectWithGyroscope : MonoBehaviour {

	
	public Vector3 forceVec;
	void FixedUpdate() {
		transform.Translate(-Input.acceleration.x,0,0);
	}
}
