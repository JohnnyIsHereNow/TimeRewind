using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ShowCredits : MonoBehaviour {
	private Image panel;
	private bool move=false;
	private Vector3 v;
	public void showPanelAndCredits(){
		v=GameObject.Find("Canvas").transform.FindChild("ShowCredits").transform.FindChild("Panel").FindChild("Text").position;
		move=true;
		GameObject.Find("Canvas").transform.FindChild("ShowCredits").transform.FindChild("Panel").gameObject.SetActive(true);
		StartCoroutine(waitSec());
	}
	IEnumerator waitSec(){

		yield return new WaitForSeconds(8);		
		move=false;
		GameObject.Find("Canvas").transform.FindChild("ShowCredits").transform.FindChild("Panel").gameObject.SetActive(false);
		GameObject.Find("Canvas").transform.FindChild("ShowCredits").transform.FindChild("Panel").FindChild("Text").position=v;
	}
	void Update(){		
		if(move)
		GameObject.Find("Canvas").transform.FindChild("ShowCredits").transform.FindChild("Panel").FindChild("Text").transform.Translate(new Vector3(0,3*Time.deltaTime,0));
	}

}
