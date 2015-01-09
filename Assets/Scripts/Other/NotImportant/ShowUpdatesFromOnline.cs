using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
public class ShowUpdatesFromOnline : MonoBehaviour {
	string path="https://dl.dropboxusercontent.com/u/64640959/TimeRewindAlpha/updatesTimeRewind.txt";
	string cont="Nothing new";
	Text tx;

	private IEnumerator getStringFromURL(){
		//Security.PrefetchSocketPolicy(path, 843);
		WWW hs_post =new WWW(path);
		yield return hs_post ;
		cont=hs_post.text;
	}

	// Use this for initialization
	void Start () {
		tx=gameObject.GetComponent<Text>();
		try{
			StartCoroutine(getStringFromURL());
		}
		catch(IOException e){
			Debug.Log (e.Message);
			Debug.Log ("Nu merge");
		}
	}
	void Update(){
		tx.text=cont;
	}
}
