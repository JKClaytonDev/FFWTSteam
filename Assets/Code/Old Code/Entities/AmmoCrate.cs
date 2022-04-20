using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour {
    public AudioSource ammoSound;

    public bool ShotgunAmmo;
    public bool AssaultRifleAmmo;
    public AudioClip sound;
    public bool RevolverAmmo;
    public bool ChaingunAmmo;
    public bool RocketLauncherAmmo;
    float[] ammo = {10, 10, 40, 15, 8, 8, 25, 10, 10, 20, 45, 15, 15, 15};
    // Use this for initialization
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag.Contains("Player") || collision.gameObject.tag.Contains("player"))
        {
            GetComponent<AudioSource>().PlayOneShot(sound);

            if (GameObject.Find("Player"))
            GameObject.Find("Player").GetComponent<Movement>().weaponAmmo = ammo;
            else
            FindObjectOfType<Movement>().GetComponent<Movement>().weaponAmmo = ammo;


            transform.position += new Vector3(999, 999, 999);
        }
    }
}
