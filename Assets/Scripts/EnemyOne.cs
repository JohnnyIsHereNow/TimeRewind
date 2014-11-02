using UnityEngine;
using System.Collections;

public class EnemyOne : MonoBehaviour {
	private int life;
	private float speed;
	private bool moveEnemy;
	public GameObject boom;
	private Camera myCamera;
	private Vector2 vec;
	private GUIStyle currentStyle=null;
		// Use this for initialization
	void Start () {
		moveEnemy=false;
		life = 10;
		speed= 5f;
		myCamera=FindObjectOfType<Camera>();
	}

	void OnGUI(){
		InitStyles();
		if(life>0 && Time.timeScale!=0){
			vec=myCamera.WorldToScreenPoint(transform.position);
			GUI.backgroundColor = Color.red;
			GUI.Box(new Rect(vec.x-life*10/2,Screen.height-(vec.y+45),life*10,10),"a",currentStyle);

		}

	}
	public void setLife(int minusLife){
		life-=minusLife;
	}

	void OnCollisionStay2D(Collision2D col){
		moveEnemy=true;
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag=="Ground" || col.gameObject.tag=="Obstacles" || col.gameObject.tag=="Key" || col.gameObject.tag=="Enemy"){

			if(col.gameObject.transform.position.x< transform.position.x)
			{
				speed=-5f;
			}else speed=5f;
		}
		
	}



	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 (-speed*Time.deltaTime, 0,0);
		if(moveEnemy) transform.position += pos;
		if (life <= 0){
			destroyMe();	
						
		}
	}
	public void destroyMe(){
		Instantiate(boom, transform.position,Quaternion.identity);
		Destroy (gameObject);
	}private void InitStyles()
	{
		if( currentStyle == null )
		{
			currentStyle = new GUIStyle( GUI.skin.box );
			currentStyle.normal.background = MakeTex( life*10,10, new Color( 1f, 0f, 0f, 0.5f ) );
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
