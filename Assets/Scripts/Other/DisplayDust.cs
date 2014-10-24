using UnityEngine;
using System.Collections;

public class DisplayDust : MonoBehaviour {
		private Animator anim;
		private GameObject textG;
		private GUIText text;
		// Use this for initialization
		void Start () {
		textG = GameObject.Find ("ShowTheDust");
			text = textG.GetComponent<GUIText> (); 
			anim = GetComponent<Animator> ();
		}
		
		// Update is called once per frame
		void Update () {
			text.text ="Dust: "+ PlayerPrefs.GetInt ("dust").ToString ();
		}
}
