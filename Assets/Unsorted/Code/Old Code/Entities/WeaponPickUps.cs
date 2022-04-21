using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUps : MonoBehaviour {
    public string weaponName;
    public AudioSource ammoSound;
	// Use this for initialization
	void Start () {
        foreach (GameObject obj in transform)
            obj.AddComponent<GlowingBlue>();
	}

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (Physics.Raycast(transform.position, Vector3.up, 10) && Vector3.Distance(player.transform.position, transform.position) < 10)
        {
            if (PlayerPrefs.GetFloat(weaponName) == 0)
            {
                PlayerPrefs.SetFloat(weaponName, 1);
                
                if (weaponName == "Shotgun")
                    player.GetComponent<FireScript>().equippedweapon = 1;
                if (weaponName == "AssaultRifle")
                    player.GetComponent<FireScript>().equippedweapon = 2;
                if (weaponName == "Revolver")
                    player.GetComponent<FireScript>().equippedweapon = 3;
                if (weaponName == "Chaingun")
                    player.GetComponent<FireScript>().equippedweapon = 4;
                if (weaponName == "RocketLauncher")
                    player.GetComponent<FireScript>().equippedweapon = 5;
            }
            PlayerPrefs.Save();
            if (weaponName == "Shotgun")
                player.GetComponent<FireScript>().ShotgunAmmo = 15;
            if (weaponName == "AssaultRifle")
                player.GetComponent<FireScript>().AssaultRifleAmmo = 25;
            if (weaponName == "RocketLauncher")
                player.GetComponent<FireScript>().RocketLauncherAmmo = 5;
            if (weaponName == "Chaingun")
                player.GetComponent<FireScript>().ChaingunAmmo = 75;
            if (weaponName == "Revolver")
                player.GetComponent<FireScript>().RevolverAmmo = 20;

            ammoSound.Play();
            transform.position = new Vector3(650, 650, 650);
        }
    }
}
