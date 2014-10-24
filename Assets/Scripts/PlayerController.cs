using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	bool doubleJump=false;
	private Animator playerAnim;
	private Animator OpenDoor;
	private float speed=0;
	private float maxspeed=24;
	private int direction=0;
	private int velocityy=27, velocityx=16;
	private Vector3 scale;
	public static bool IsDead=false;
	private bool HasTheKey=false;
	private bool moving = false;
	private GameObject attack;
	private AttackButton attackbutton;	
	private GameObject jump;
	private JumpButton jumpbutton;	
	private GameObject moveleft;
	private MoveLeft moveleftbutton;
	private GameObject moveright;
	private MoveRight moverightbutton;
	private SpriteRenderer spL,spR,c,ms,md,par1,par2;
	public Material blueGlow,defaultMaterial;
	public GameObject boom;
	//public Texture buttonA,buttonD,buttonW,buttonQ;
	// Use this for initialization
	void changeSpeed(){
		StartCoroutine (FiveSecondsTime());
	}
	void displayShield(){
		StartCoroutine (FiveSecondsForShield ());
	}
	void displayShield2(){
		StartCoroutine (FiveSecondsForShield2 ());
	}

	IEnumerator FiveSecondsTime(){
		maxspeed = 50;
		velocityy = 40;
		velocityx = 25;
		yield return new WaitForSeconds(3);		
		maxspeed = 24;
		velocityy = 27;
		velocityx = 16;
	}

	IEnumerator FiveSecondsForShield(){	
		PlayerPrefs.SetInt("Shield",1);
		transform.FindChild ("protectiveShield").GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (5);
		transform.FindChild ("protectiveShield").GetComponent<SpriteRenderer> ().enabled = false;
		PlayerPrefs.SetInt("Shield",0);
	}
	IEnumerator FiveSecondsForShield2(){
		PlayerPrefs.SetInt("Shield2",1);
		transform.FindChild ("killEnemiesShield").GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (5);
		transform.FindChild ("killEnemiesShield").GetComponent<SpriteRenderer> ().enabled = false;
		PlayerPrefs.SetInt("Shield2",0);
	}



	void Start () {
		PlayerPrefs.SetInt("Shield",0);
		PlayerPrefs.SetInt("Shield2",0);

		attack = GameObject.Find ("_attack");
		attackbutton = attack.GetComponent<AttackButton> ();		
		jump = GameObject.Find ("up");
		jumpbutton = jump.GetComponent<JumpButton> ();	
		moveleft = GameObject.Find ("left");
		moveleftbutton = moveleft.GetComponent<MoveLeft> ();
		moveright = GameObject.Find ("right");
		moverightbutton = moveright.GetComponent<MoveRight> ();
		playerAnim = GetComponentInParent<Animator> ();
		OpenDoor = GameObject.Find ("Door").GetComponent<Animator> ();
		spL = GameObject.Find ("piciors").GetComponent<SpriteRenderer> ();
		spR = GameObject.Find ("piciord").GetComponent<SpriteRenderer> ();
		c = GameObject.Find ("caracter").GetComponent<SpriteRenderer> ();
		ms = GameObject.Find ("manas").GetComponent<SpriteRenderer> ();
		md = GameObject.Find ("manaj").GetComponent<SpriteRenderer> ();
		par1 = GameObject.Find ("par1").GetComponent<SpriteRenderer> ();
		par2 = GameObject.Find ("par2").GetComponent<SpriteRenderer> ();

		//guiTexture.texture = buttonA;
	}

	void OnTriggerEnter2D(Collider2D col){
		//==========================Verifica coliziunea cu lada================	
		if (col.gameObject.tag == "Chest" && (!Input.GetKey ("q") || !TimeScale.RewindTime) && !IsDead) {
			col.GetComponent<Animator>().SetBool("Open",true);
				}
		//==========================Verifica coliziunea cu shield=============
		if (col.gameObject.tag == "shield" && (!Input.GetKey ("q")  || !TimeScale.RewindTime) && !IsDead) {
			PlayerPrefs.SetInt("Shield",1);
			Destroy(col.gameObject);
		}
		//==========================Verifica coliziunea cu shield2=============
		if (col.gameObject.tag == "shield2" && (!Input.GetKey ("q") || !TimeScale.RewindTime) && !IsDead) {
			PlayerPrefs.SetInt("Shield2",1);
			Destroy(col.gameObject);
		}


		//==========================Verifica coliziunea cu speedShoe=============
		if (col.gameObject.tag == "Shoe" && (!Input.GetKey ("q") || !TimeScale.RewindTime) && !IsDead) {
					Destroy(col.gameObject);
					changeSpeed();
				}

		//==========================Verifica coliziunea cu usa===================
		if (col.gameObject.tag == "Door" && (!Input.GetKey ("q") || !TimeScale.RewindTime) && !IsDead && HasTheKey) {
			//getDust
			//GetToTheNextLevel
			if(PlayerPrefs.GetInt("levelInPlay") == PlayerPrefs.GetInt("levelsUnlocked1"))
			{
				PlayerPrefs.SetInt("levelsUnlocked1", PlayerPrefs.GetInt("levelsUnlocked1")+1);
			}
			Application.LoadLevel ("loadWorldScene");
			
		}

	}
	
	void OnCollisionEnter2D(Collision2D col)
	{	
		//==========================Verifica coliziunea cu cheita================	
		
		if (col.gameObject.tag == "Key" && (!Input.GetKey("q") || !TimeScale.RewindTime) && !IsDead) {
			HasTheKey=true;
			if(transform.FindChild("manaj")!=null)
			col.gameObject.transform.parent=transform.FindChild("manaj");
			else
			   col.gameObject.transform.parent=transform.FindChild("caracter").FindChild("manaj");	
			   
			OpenDoor.SetBool("HasKey",true);
		}


//==========================Verifica pamantul si etc================
				if (col.gameObject.tag == "Ground" && col.gameObject.transform.position.y<transform.position.y) {
						playerAnim.SetBool ("Jump", false);
						playerAnim.SetBool("Grounded",true);
						moving=false;
				}
		if ((col.gameObject.tag == "Obstacles" || col.gameObject.tag=="Enemy") && PlayerPrefs.GetInt("Shield")!=1 && PlayerPrefs.GetInt("Shield2")!=1) {
			playerAnim.SetBool ("IsDead", true);			
			OpenDoor.SetBool("HasKey",false);
		}
		if(col.gameObject.tag=="Enemy" && PlayerPrefs.GetInt("Shield2")==1){
			Instantiate(boom, col.gameObject.transform.position,Quaternion.identity);
			Destroy (col.gameObject);
		}



	}
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
		playerAnim.SetBool("Grounded",false);
	}
	
	// Update is called once per frame
	void Update () {
				//====================================Activate Shield ===================================
				if (PlayerPrefs.HasKey ("Shield"))
				if (PlayerPrefs.GetInt ("Shield") == 1)
					displayShield();
				//====================================Activate Shield2 ===================================
				if (PlayerPrefs.HasKey ("Shield2"))
					if (PlayerPrefs.GetInt ("Shield2") == 1)
						displayShield2();
								

		//====================================Change Color of the feets===========================
		if (maxspeed == 50 && spL.color != Color.blue) {
						spL.color = Color.blue;
						spL.material=blueGlow;
				} else {
						spL.color = Color.white;
						spL.material=defaultMaterial;
		}
		if (maxspeed == 50 && spR.color != Color.blue) {
			spR.color = Color.blue;
			spR.material=blueGlow;
		} else {
			spR.color = Color.white;
			spR.material=defaultMaterial;
		}
		if (maxspeed == 50 && c.color != Color.blue) {
			c.color = Color.blue;
			c.material=blueGlow;
		} else {
			c.color = Color.white;
			c.material=defaultMaterial;
		}
		if (maxspeed == 50 && ms.color != Color.blue) {
			ms.color = Color.blue;
			ms.material=blueGlow;
		} else {
			ms.color = Color.white;
			ms.material=defaultMaterial;
		}
		if (maxspeed == 50 && md.color != Color.blue) {
			md.color = Color.blue;
			md.material=blueGlow;
		} else {
			md.color = Color.white;
			md.material=defaultMaterial;
		}
		if (maxspeed == 50 && par1.color != Color.blue) {
			par1.color = Color.blue;
			par1.material=blueGlow;
		} else {
			par1.color = Color.white;
			par1.material=defaultMaterial;
		}
		if (maxspeed == 50 && par2.color != Color.blue) {
			par2.color = Color.blue;
			par2.material=blueGlow;
		} else {
			par2.color = Color.white;
			par2.material=defaultMaterial;
		}
		
		//====================================Change Speed========================================

		//Debug.Log ("Speed: "+speed);
		if (rigidbody2D.velocity.x > 0)
						speed = rigidbody2D.velocity.x;
				else if (rigidbody2D.velocity.x < 0)
						speed = -rigidbody2D.velocity.x;
				else
						speed = 0;
		playerAnim.SetFloat ("Speed", speed);
		if (rigidbody2D.velocity.y > velocityy)
			rigidbody2D.velocity = (new Vector2 (rigidbody2D.velocity.x, velocityy-2));
		if (rigidbody2D.velocity.x > velocityx)
			rigidbody2D.velocity = (new Vector2 (velocityx,rigidbody2D.velocity.y));
		if (rigidbody2D.velocity.x < -velocityy)
			rigidbody2D.velocity = (new Vector2 (-velocityx-1,rigidbody2D.velocity.y));
		if (speed > maxspeed)
			speed = maxspeed;
		if(playerAnim.GetBool("IsDead")) IsDead=true; else IsDead=false;
//scale the character
		if (direction == 0) {
						Vector3 scale = new Vector2 (1, 1);
						transform.localScale = scale;
				} else {
						Vector3 scale = new Vector2 (-1, 1);
						transform.localScale = scale;
				}
		
//set the speed to 0 while is not walking

		if ((Input.GetKeyDown ("e") || attackbutton.getAtaca()) && !playerAnim.GetBool ("IsDead") && PlayerPrefs.GetInt("weaponInUse")==0) {
			playerAnim.SetTrigger("AttackWithKnife");
			Debug.Log ("Knife");
		}
		if ((Input.GetKeyDown ("e") || attackbutton.getAtaca()) && !playerAnim.GetBool ("IsDead") && PlayerPrefs.GetInt("weaponInUse")==1) {
			playerAnim.SetTrigger("AttackWithGun");
			Debug.Log ("Gun");
		}
		//jumps sideways
		if ((Input.GetKey ("d") || moverightbutton.getMoveRight()) && !playerAnim.GetBool ("Jump") && !playerAnim.GetBool ("IsDead")) {
			speed=maxspeed;
			rigidbody2D.velocity = (new Vector2 (velocityy-2, rigidbody2D.velocity.y));
			moving=true;
			direction=0;
			if(Input.GetKeyDown("w") || jumpbutton.getJump()){
				rigidbody2D.velocity = (new Vector2 (velocityx-1, velocityy-2));
				playerAnim.SetBool ("Jump", true);
				playerAnim.SetBool ("Grounded", false);
			}
		}
		//jumps sideways left
		if ((Input.GetKey ("a") || moveleftbutton.getMoveLeft()) && !playerAnim.GetBool ("Jump") && !playerAnim.GetBool ("IsDead")) {
			speed=maxspeed;
			rigidbody2D.velocity = (new Vector2 (-velocityy-2, rigidbody2D.velocity.y));
			moving=true;
			direction=1;
			if(Input.GetKey("w") || jumpbutton.getJump()){
				rigidbody2D.velocity = (new Vector2 (-velocityx-1, velocityy-2));
				playerAnim.SetBool ("Jump", true);
				playerAnim.SetBool ("Grounded", false);
			}
		}


		// JUMPS STRAIT
		if ((Input.GetKeyDown("w") || jumpbutton.getJump()) && !playerAnim.GetBool("Jump") && !playerAnim.GetBool("IsDead")) {
			rigidbody2D.velocity = (new Vector2 (rigidbody2D.velocity.x, velocityy-2));
			playerAnim.SetBool ("Jump", true);
			playerAnim.SetBool ("Grounded", false);
		}
		//jump to the right
		if (playerAnim.GetBool ("Jump") && !playerAnim.GetBool ("IsDead")) {

			if ((Input.GetKeyDown ("a")|| moveleftbutton.getMoveLeft()) && !moving) {
				moving = true;
				direction =1;
				rigidbody2D.velocity = (new Vector2 (-velocityx-1, rigidbody2D.velocity.y));
			}
			if ((Input.GetKeyDown ("d") || moverightbutton.getMoveRight()) && !moving) {
				moving = true;
				direction =0;
				rigidbody2D.velocity = (new Vector2 (velocityx-1, rigidbody2D.velocity.y));
			}
		}


//=========================If it has the key=============================
		if (HasTheKey) {
			GameObject thekey;
			thekey=GameObject.Find("cheita");			
			OpenDoor.SetBool("HasKey",true);
			thekey.transform.collider2D.enabled=false;
			if(transform.Find ("caracter").Find("manaj")==null)
				thekey.transform.position=transform.Find("manaj").position;
			else
			thekey.transform.position=transform.Find("caracter").Find("manaj").position;
			//GameObject.Find ("manaj").transform.position;//transform.FindChild ("manaj").position;
			thekey.transform.rotation =  Quaternion.Euler(0, 0, -30);
			}
//=========================If has not the key============================
		if (IsDead || !HasTheKey) {
						GameObject thekey = GameObject.FindGameObjectWithTag("Key");
						thekey.transform.collider2D.enabled=true;
						thekey.transform.parent=null;
						HasTheKey = false;
									}
//=========================End of statament=====================
	}
}
