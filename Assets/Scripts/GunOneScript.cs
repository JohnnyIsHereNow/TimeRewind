using UnityEngine;
using System.Collections;

public class GunOneScript : MonoBehaviour {
	public GameObject pistol;
	private Animator playerAnim;
	public GameObject anim;
	private GameObject attack;
	private AttackButton attackbutton;
	// Use this for initialization
	void Start(){
				attack = GameObject.Find ("_attack");
				attackbutton = attack.GetComponent<AttackButton> ();
				playerAnim = GetComponentInParent<Animator> ();
		}


	// Update is called once per frame
	void Update () {
		if((Input.GetKeyDown ("e") || attackbutton.getAtaca()) && !playerAnim.GetBool("IsDead")){
			attackbutton.acumNuAtac();
			Vector3 vec = new Vector3 (pistol.transform.position.x, pistol.transform.position.y, 0);
			//vec.x += 0.3f;
			Instantiate(pistol,transform.position+new Vector3(1.6f,-0.3f,0),Quaternion.identity);			
			Instantiate (anim,transform.position,Quaternion.identity);
		}
	}
}
