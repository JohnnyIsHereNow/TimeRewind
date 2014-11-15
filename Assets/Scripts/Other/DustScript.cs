using UnityEngine;
using System.Collections;

public class DustScript : MonoBehaviour {
	public bool goup=false;
	private Animator anim;
	private SpriteRenderer tenText;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		tenText = transform.FindChild ("tenText").GetComponent<SpriteRenderer>();
        
	}
	
	// Update is called once per frame
	void Update () {

		if (goup) {
			if(transform.collider2D.enabled==true)
			transform.collider2D.enabled=false;
			anim.SetBool("FadeAway",true);
			transform.position=transform.position+new Vector3(0,0.1f,0);
			tenText.enabled=true;
			Destroy (gameObject, 2);
		}
	}
}
