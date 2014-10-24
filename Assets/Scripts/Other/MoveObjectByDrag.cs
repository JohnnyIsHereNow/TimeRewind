using UnityEngine;
using System.Collections;

public class MoveObjectByDrag : MonoBehaviour {
	private RaycastHit2D hit;
	private Vector3 touchPost;
	private Vector3 original;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
#if !UNITY_STANDALONE
		if(Input.touchCount>0){
		touchPost = camera.ScreenToWorldPoint(Input.touches[0].position);
		hit=Physics2D.Raycast(camera.ScreenToWorldPoint(Input.touches[0].position), Vector2.zero);
			if(hit!=null && hit.transform!=null && (hit.transform.name=="box" || hit.transform.tag=="Enemy")){
			original=hit.transform.position;
			original.x=touchPost.x;
			original.y=touchPost.y;
			hit.transform.position=original;
		}
		}
#endif


		#if UNITY_STANDALONE
	if(Input.GetMouseButton(0)){
			touchPost = camera.ScreenToWorldPoint(Input.mousePosition);
			hit=Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit !=null && hit.transform !=null)
			                      {
				Debug.Log(hit.transform.name);
	}
			if(hit!=null && hit.transform!=null && hit.transform.name=="box"){
				original=hit.transform.position;
				original.x=touchPost.x;
				original.y=touchPost.y;
				hit.transform.position=original;
			}
}
#endif
}

}
