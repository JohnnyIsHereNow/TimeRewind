using UnityEngine;
using System.Collections;

public class DestroyAfterTwoSeconds : MonoBehaviour {

	private IEnumerator KillOnAnimationEnd() {
		yield return new WaitForSeconds (2.0f);
		Destroy (gameObject);
	}
	
	void Update () {
		StartCoroutine (KillOnAnimationEnd ());
	}
}
