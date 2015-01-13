using UnityEngine;
using System.Collections;

public class TimeScale : MonoBehaviour {
	public  Vector3[] storePosition;
	private bool okFromTheScreen=false;
	private bool enter = false,aTrecut=false;
	private int i=0,j=0;
	private Animator anim;
	public static bool RewindTime=false;
	//public Transform obj;
	// Use this for initialization


	void Start () {
		anim = GameObject.FindGameObjectWithTag ("Player").GetComponent <Animator>();
		storePosition = new Vector3[1000];
	}
	
	// Update is called once per frame
	void FixedUpdate () {

//		Debug.Log (okFromTheScreen);
		if (RewindTime==false && (anim.GetBool("IsDead")==false || (anim.GetBool("IsDead")==true && anim.GetBool("Grounded")==false))) {						
						if (i > storePosition.Length-1) {
								i = 0;
								j = 0;
								aTrecut=true;
						}
						storePosition [i] = transform.position;
						i++;
						j=i;		
						enter=true;

				}
	
		if (RewindTime==true){
				if(anim.GetBool("IsDead")){
						//anim.Play("Player1Dead");
						anim.SetBool("IsDead",false);
						}
						
								if(i==j+1) enter=false;						
								if (i <= 0) {
										if (aTrecut)
												i = storePosition.Length - 1;
										else{
												i = j;
												enter=false;
											}
									
								}
									
						if (enter) {
								i--;
								transform.position = storePosition [i];
				}
				
		}

						
	}
}
