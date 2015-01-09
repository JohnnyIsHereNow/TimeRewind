using UnityEngine;
using System.Collections;

public class Enemy3Script : MonoBehaviour {
	private int life;
	public float speed;
	private bool moveEnemy;
	public GameObject boom;
	private Camera myCamera;
	private Vector2 vec;
	private GUIStyle currentStyle=null;
	private bool onGround=true;
	// Use this for initialization
	void Start () {
		moveEnemy=false;
		life = 100;
		speed= 12f;
		myCamera=FindObjectOfType<Camera>();
	}
	
	void OnGUI(){
		InitStyles();
		if(life>0 && Time.timeScale!=0){
			vec=myCamera.WorldToScreenPoint(transform.position);
			GUI.backgroundColor = Color.red;
			GUI.Box(new Rect(vec.x-life*2/2,Screen.height-(vec.y+200),life*2,2),"",currentStyle);
			
		}
		
	}
	public void setLife(int minusLife){
		life-=minusLife;
	}
	
	void OnCollisionStay2D(Collision2D col){
		moveEnemy=true;
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag=="Ground")  onGround=true;

		if(col.gameObject.tag=="Ground"){
			//change speed if a wall he hits a wall in left or right
			if(col.gameObject.transform.position.y>transform.position.y){
				if(col.gameObject.transform.position.x < transform.position.x)
				{
					transform.localScale=new Vector2(-1,1);
					speed=-speed;
				}else 
				{	
					transform.localScale=new Vector2(1,1);
					speed=-speed;
				}
			}

	}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag=="Obstacles" || col.gameObject.tag=="Key" || col.gameObject.tag=="Enemy"){
			
			if(col.gameObject.transform.position.x < transform.position.x)
			{
				transform.localScale=new Vector2(-1,1);
			}else 
			{	
				transform.localScale=new Vector2(1,1);
			}
			speed=-speed;
		}
		
	}
	
	
	
	// Update is called once per frame
	void Update () {
		//make character jump

		int r = Random.Range(0,3);
		if(r==2){
			if(transform.localScale.x==1 && onGround)
			gameObject.rigidbody2D.velocity = new Vector2(-5,10);
			if(transform.localScale.x==-1 && onGround)				
			gameObject.rigidbody2D.velocity = new Vector2(5,10);
			onGround=false;
		}

		Vector3 pos = new Vector3 (-speed*Time.deltaTime, 0,0);
		if(moveEnemy) transform.position += pos;
		if (life <= 0){
			destroyMe();	
			
		}
	}

	public void destroyMe(){
		Instantiate(boom, transform.position,Quaternion.identity);
		//increase number of enemies killed here
		if(PlayerPrefs.HasKey("numberOfEnemiesKilled")) 
			PlayerPrefs.SetInt("numberOfEnemiesKilled",PlayerPrefs.GetInt("numberOfEnemiesKilled")+1);
		else PlayerPrefs.SetInt("numberOfEnemiesKilled",1);
		//
		Destroy (gameObject);
	}private void InitStyles()
	{
		if( currentStyle == null )
		{
			currentStyle = new GUIStyle( GUI.skin.box );
			currentStyle.normal.background = MakeTex( life*5,5, new Color( 1f, 0f, 0f, 0.5f ) );
		}
	}


	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}
	
}
