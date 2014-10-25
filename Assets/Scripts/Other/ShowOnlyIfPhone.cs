using UnityEngine;
using System.Collections;

public class ShowOnlyIfPhone : MonoBehaviour {
	// Use this for initialization
	void Start () {
#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_PSM
		transform.position = new Vector2(-1000,-1000);
#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
