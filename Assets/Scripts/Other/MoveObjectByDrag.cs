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
#if (UNITY_ANDROID || UNITY_IOS || UNITY_WP8) && !UNITY_EDITOR
		if(Input.touchCount>0){
			hit=Physics2D.Raycast(camera.ScreenToWorldPoint(Input.touches[0].position), Vector2.zero);
			touchPost = camera.ScreenToWorldPoint(Input.touches[0].position);
		}
			
			if(hit!=null && hit.transform!=null && (hit.transform.name=="box")){
				if(Input.GetTouch(0).phase !=TouchPhase.Began){
			original=hit.transform.position;
			original.x=touchPost.x;
			original.y=touchPost.y;
			hit.transform.position=original;
			}
		}
#endif


		#if UNITY_STANDALONE || UNITY_EDITOR
	if(Input.GetMouseButton(0)){
			hit=Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			touchPost = camera.ScreenToWorldPoint(Input.mousePosition);
		}

		if(hit!=null && hit.transform!=null && hit.transform.name=="box"){
			if(!Input.GetMouseButton(0)){
			original=hit.transform.position;
			original.x=touchPost.x;
			original.y=touchPost.y;
			hit.transform.position=original;
			}
			}
		#endif
}

}
