using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject camera;
	// Use this for initialization
	void Start () {		
		camera = GameObject.Find ("_camera");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vec = new Vector3 (camera.transform.position.x, camera.transform.position.y, -10);
		transform.position = vec;
	}
}
