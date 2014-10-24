using UnityEngine;
using System.Collections;

public class DestroyBoom : MonoBehaviour {

		private IEnumerator KillOnAnimationEnd() {
			yield return new WaitForSeconds (0.9f);
			Destroy (gameObject);
		}
		
		void Update () {
			StartCoroutine (KillOnAnimationEnd ());
		}
	}
