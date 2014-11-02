using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {
	private int numberOfWeapons=5;
	private GameObject[] weapons = new GameObject[6];
	public int[] a;
	public int activeWeapon;
	public int nextAvailableWeapon=1;
	private GameObject nextweapon;
	private NextWeapon nextweaponbutton;
	private int nr=1;
	//return activeWeapon
	public int getActiveWeapon(){
				return activeWeapon;
		}

	// Use this for initialization
	void Start () {
		a= new int[6];
		//PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt ("unlockGun1", 1);
				//save weapons


		for (int i=1; i<=numberOfWeapons; i++){
						if (!PlayerPrefs.HasKey ("unlockGun" + i))
								PlayerPrefs.SetInt ("unlockGun" + i, 0);
		}
			nextweapon = GameObject.Find ("nextWeapon");
			nextweaponbutton = nextweapon.GetComponent<NextWeapon> ();

		for (int i=1; i<=5; ++i) {
			a[i] = PlayerPrefs.GetInt ("unlockGun" + i);
		}
		activeWeapon = 1;
		weapons [1] = GameObject.Find ("Gun1");
		weapons [2] = GameObject.Find ("Gun2");
		weapons [3] = GameObject.Find ("Gun3");
		weapons [4] = GameObject.Find ("Gun4");
		weapons [5] = GameObject.Find ("Gun5");
		for (int i=1; i<=numberOfWeapons; i++)
						weapons [i].SetActive (false);

	
	}
	
	// Update is called once per frame
	void Update () {
		//====================search for the next available weapon============
		//int nr = 0;
		nr = activeWeapon + 1;
		if (nr > 5)
						nr = 1;
		while(a[nr]==0){ 
			nr++; 
			if(nr>5)
				nr=1;
		}
		nextAvailableWeapon=nr;

		//=====================================================================
		
		weapons [1].SetActive (false);


		if (Input.GetKeyDown ("1") || nextweaponbutton.getNextWeapon ()) {
						nextweaponbutton.setFalse ();
						
								if (activeWeapon < numberOfWeapons ) {
										weapons [activeWeapon].SetActive (false);
										activeWeapon=nextAvailableWeapon;
								} else {
										weapons [activeWeapon].SetActive (false);
										activeWeapon = 1;
								
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

