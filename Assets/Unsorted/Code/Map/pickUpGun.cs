using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class pickUpGun : MonoBehaviour {
    public int weaponNum;   private bool isParent;
    public string message = "";
    public AudioClip[] pickUpSounds;
    float[] ammo = { 5, 10, 35, 10, 5, 6, 25, 8, 8, 45, 15 };
    // Use this for initialization

    /*
void OnTriggerEnter(Collider collision) {
    if (collision.gameObject.name == "Player")
    {
        transform.position = new Vector3(900, 900, 900);
        GameObject.Find("Player").GetComponent<Movement>().weaponAmmo[weaponNum - 1] = GameObject.Find("Player").GetComponent<Movement>().PlayerOriginalAmmo[weaponNum - 1];
        if (!GameObject.Find("Player").GetComponent<Movement>().equippedWeapons[weaponNum])
        {
            //GameObject.Find("AbilityGUI").GetComponent<TextMeshProUGUI>().text = message;
            GameObject.Find("Player").GetComponent<Movement>().equippedWeapons[weaponNum] = true;
            GameObject.Find("Player").GetComponent<Movement>().nextWeapon = weaponNum;
            GameObject.Find("Player").GetComponent<Movement>().animController.SetInteger("WeaponNum", weaponNum);
        }
            Destroy(gameObject);
    }
}
*/
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>())
        {
            Animator animController = other.GetComponent<Animator>();

            if (animController.GetInteger("WeaponNum") == 3)
                animController.Play("uziVidEquip");
            else if (animController.GetInteger("WeaponNum") == 1)
                animController.Play("flipGat");
            else if (animController.GetInteger("WeaponNum") == 6)
            {
                if (UnityEngine.Random.Range(1, 10) != 6)
                    animController.Play("InspectShotgun");
                else
                    animController.Play("RareInspect");
            }
            else if (animController.GetInteger("WeaponNum") == 7)
            {
                animController.Play("ARInspect");
            }
            else if (animController.GetInteger("WeaponNum") == 4)
            {
                if (UnityEngine.Random.Range(1, 2) == 3)
                    animController.Play("csgoPistolInspect");
                else
                    animController.Play("csgodefaultInspect");
            }
            else if (animController.GetInteger("WeaponNum") == 9)
            {
                animController.Play("DoubleBarrelFlip");
            }
            else
                animController.Play("weaponInspect", 4);
        }
    }
    void Start () {
        if (PlayerPrefs.GetString("Mode") == "Easy")
            ammo = new float[] { 10, 20, 70, 20, 10, 12, 12, 4, 4, 90, 30 };
        else if (PlayerPrefs.GetString("Mode") == "Hard")
            ammo = new float[] { 3, 5, 17, 5, 3, 3, 12, 4, 4, 24, 7 };
        else
         ammo = new float[]{ 5, 10, 35, 10, 5, 6, 25, 8, 8, 45, 15 };
        if (PlayerPrefs.GetString("Mode") == "Hard" && Random.Range(1, 5) == 5)
            Destroy(gameObject);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
            transform.position = hit.point + Vector3.up * (111.4f - 105.8f)/2;
        
        if (!(Physics.Raycast(transform.position, Vector3.down, 25)))
            Destroy(gameObject);    
        transform.position += transform.up * 7;
        //GetComponent<BoxCollider>().isTrigger = true;
        //GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().constraints = (RigidbodyConstraints.FreezeAll);
        isParent = (!gameObject.name.Contains("(Clone)"));
        transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
        //transform.localScale = new Vector3(4.6f, 2.5f, 7);
    }

	

}
