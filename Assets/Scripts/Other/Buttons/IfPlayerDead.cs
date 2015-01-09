using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IfPlayerDead : MonoBehaviour {
	public GameObject[] b;
	// Use this for initialization
	void Start () {
		b=new GameObject[3];
		b[0]=GameObject.Find("ShoeButton");
		b[1]=GameObject.Find("Shield1Button");
		b[2]=GameObject.Find("Shield2Button");
	}
	
	// Update is called once per frame
	void Update () {
	if(GameObject.Find("__PlayButtons")!=null)
	if(GameObject.Find("__PlayButtons").gameObject.activeInHierarchy==true)
	if(PlayerController.IsDead){
			foreach(GameObject g in b){ 
				g.SetActive(false);
			}
		}else 
			foreach(GameObject g in b) {
				g.SetActive(true);
		}
		                 
	}
}
