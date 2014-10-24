using UnityEngine;
using System.Collections;

public class AttackButton : MonoBehaviour {
	private bool Ataca=false;
	void Update(){
		foreach (Touch touch in Input.touches)
			if (guiTexture.HitTest(touch.position) && touch.phase!=TouchPhase.Ended){
				Ataca=true;
				} else Ataca =false;
}
	

	#if unity_standalone
	void OnMouseDown(){
		Ataca = true;
	}
	void OnMouseUp(){
		Ataca = false;
		}
	#endif
	public bool getAtaca(){
				return Ataca;
		}
	public void acumAtac(){
				Ataca = true;
		}
	public void acumNuAtac(){
		Ataca = false;
	}

}
