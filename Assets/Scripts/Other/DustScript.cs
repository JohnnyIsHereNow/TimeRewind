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
			anim.SetBool("FadeAway",true);
			transform.position=transform.position+new Vector3(0,0.1f,0);
			tenText.enabled=true;
			Destroy (gameObject, 2);
				}
	}

	void OnTriggerEnter2D(Collider2D col){
		//if (col.gameObject.tag == "Player") {
			//disable collider
			transform.collider2D.enabled=false;
			//make it go up;
			goup=true;
			//
		PlayerPrefs.SetInt ("dust", PlayerPrefs.GetInt ("dust") + 10);

		//		}
	}
}
