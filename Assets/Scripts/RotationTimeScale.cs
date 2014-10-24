using UnityEngine;
using System.Collections;

public class RotationTimeScale : MonoBehaviour {
	public  Quaternion[] storePosition;
	private bool enter = false,aTrecut=false;
	private int i=0,j=0;
	public static bool rewind;
	//public Transform obj;
	// Use this for initialization
	void Start () {
		storePosition = new Quaternion[100];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (rewind==false) {						
			if (i > storePosition.Length-1) {
				i = 0;
				j = 0;
				aTrecut=true;
			}
			storePosition[i] = transform.rotation;
			i++;
			j=i;		
			enter=true;
			
		}
		if (rewind==true) {		
			
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
				transform.rotation = storePosition [i];
			}
		}
		
	}
}
