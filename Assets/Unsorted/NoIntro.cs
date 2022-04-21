using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        transform.parent = GameObject.Find("Player").transform;
        Destroy(GetComponent<Rigidbody>());
        transform.position = GameObject.Find("Player").transform.position;
        transform.rotation = GameObject.Find("Player").transform.rotation;

        if (GameObject.Find("Player").GetComponent<Animator>().GetInteger("WeaponNum") == 4)
            GameObject.Find("Player").GetComponent<Animator>().Play("spawnEquip");
        GameObject.Find("Player").transform.position = GameObject.Find("PlayerSpawn").transform.position;
        this.enabled = false;
    }
}
