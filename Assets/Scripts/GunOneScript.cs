using UnityEngine;
using System.Collections;

public class GunOneScript : MonoBehaviour {
	public GameObject pistol;
	private Animator playerAnim;
	public GameObject anim;
	private GameObject attack;
	private AttackButton attackbutton;
	private float secondsToWait=2;
	private float time;
	// Use this for initialization
	void Start(){
				attack = GameObject.Find ("_attack");
				attackbutton = attack.GetComponent<AttackButton> ();
				playerAnim = GetComponentInParent<Animator> ();
				time=Time.deltaTime;
		}
	void  setSeconds(){
		if(PlayerPrefs.GetInt("weaponInUse")==0)
			secondsToWait=0.5f;
		else if(PlayerPrefs.GetInt("weaponInUse")==1)
			secondsToWait=1.5f;
		else if(PlayerPrefs.GetInt("weaponInUse")==2)
			secondsToWait=2.5f;
		else if(PlayerPrefs.GetInt("weaponInUse")==3)
			secondsToWait=3.5f;
		else if(PlayerPrefs.GetInt("weaponInUse")==4)
			secondsToWait=4.5f;
	}

	// Update is called once per frame
	void Update () {





		if ((Input.GetAxis("Shoot")!=0 || attackbutton.getAtaca()) && !playerAnim.GetBool ("IsDead") && PlayerPrefs.GetInt("weaponInUse")!=0 && Time.time-time>secondsToWait) {
			playerAnim.SetTrigger("AttackWithGun");
			//Debug.Log ("Gun");
		}
		setSeconds();
		if((Input.GetAxis("Shoot")!=0 || attackbutton.getAtaca()) && !playerAnim.GetBool("IsDead") && Time.time-time>secondsToWait){
			time=Time.time;
			attackbutton.acumNuAtac();
			Vector3 vec = new Vector3 (pistol.transform.position.x, pistol.transform.position.y, 0);
			Instantiate(pistol,transform.position+new Vector3(1.6f,-0.3f,0),Quaternion.identity);

			Instantiate (anim,transform.position,Quaternion.identity);
			
		}
	}
}
