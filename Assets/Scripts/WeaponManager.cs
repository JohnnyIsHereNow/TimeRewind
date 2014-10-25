using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {
	private int numberOfWeapons=5;
	private GameObject[] weapons = new GameObject[5];
	public int[] a = new int[5];
	public int activeWeapon;
	public int nextAvailableWeapon=0;
	private GameObject nextweapon;
	private NextWeapon nextweaponbutton;
	//return activeWeapon
	public int getActiveWeapon(){
				return activeWeapon;
		}

	// Use this for initialization
	void Start () {

		PlayerPrefs.SetInt ("unlockGun1", 1);
		//PlayerPrefs.DeleteAll ();
				//save weapons
		for (int i=0; i<=numberOfWeapons-1; i++) {
						a[i] = PlayerPrefs.GetInt ("unlockGun" + i);
				}

		for (int i=1; i<=numberOfWeapons-1; i++){
						if (!PlayerPrefs.HasKey ("unlockGun" + i))
								PlayerPrefs.SetInt ("unlockGun" + i, 0);
			
			nextweapon = GameObject.Find ("nextWeapon");
			nextweaponbutton = nextweapon.GetComponent<NextWeapon> ();
		}
		activeWeapon = 0;
		weapons [0] = GameObject.Find ("Gun1");
		weapons [1] = GameObject.Find ("Gun2");
		weapons [2] = GameObject.Find ("Gun3");
		weapons [3] = GameObject.Find ("Gun4");
		weapons [4] = GameObject.Find ("Gun5");
		for (int i=1; i<=numberOfWeapons-1; i++)
						weapons [i].SetActive (false);

	
	}
	
	// Update is called once per frame
	void Update () {
		//====================search for the next available weapon============
		int nr = 0;
		nr = activeWeapon + 1;
		if (nr > 4)
						nr = 0;
		while(a[nr]==0){ nr++; if(nr>4) nr=0;
		}
		nextAvailableWeapon=nr;
		//=====================================================================


		weapons [0].SetActive (false);
		if (Input.GetKeyDown ("1") || nextweaponbutton.getNextWeapon ()) {
						nextweaponbutton.setFalse ();
						
								if (activeWeapon < numberOfWeapons - 1) {
										weapons [activeWeapon].SetActive (false);
										activeWeapon=nextAvailableWeapon;
								} else {
										weapons [activeWeapon].SetActive (false);
										activeWeapon = 0;
								
								}
						}
				
		/*
			if (Input.GetKeyDown ("2")) {
						if (activeWeapon > 0) {
								weapons [activeWeapon].SetActive (false);
								activeWeapon--;
						} else {
								weapons [activeWeapon].SetActive (false);
				activeWeapon = numberOfWeapons-1;
								}
				}
				*/
		weapons [activeWeapon].SetActive (true);
		PlayerPrefs.SetInt ("weaponInUse", activeWeapon);

	}
}

