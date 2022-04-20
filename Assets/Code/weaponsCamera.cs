using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponsCamera : MonoBehaviour {
	public float CamOffsetY;
    public Vector3[] offsets;
    public int weaponNum;
    Vector3 oldvelocity;
	// Use this for initialization
	void Start () {
		//3: 0.73, -0.17, 0
        //0: 0.54, 0, 0.01
        //6: 1.23, -0.55, 0.29
        //9: 0.97, 0, 0
	}

    // Update is called once per frame
    void Update()
    {
        transform.rotation = GameObject.Find("Player").transform.rotation;
        if (!GameObject.Find("PlayerLegs").GetComponent<Animator>().GetBool("Kicking") && !GameObject.Find("PlayerLegs").GetComponent<Animator>().GetBool("Sliding"))
        {
            if (!GameObject.Find("Player").GetComponent<Movement>().oldMovement)
            {
                weaponNum = GameObject.Find("Player").GetComponent<Movement>().animController.GetInteger("WeaponNum") - 1;
                if (!GameObject.Find("PlayerLegs").GetComponent<Animator>().GetBool("Kicking"))
                {
                    Vector3 pos = GameObject.Find("Player").transform.position;
                    pos.y += CamOffsetY;
                    transform.position = pos;
                    CamOffsetY += (-CamOffsetY) / 10;
                }
                else
                    transform.position = GameObject.Find("Player").transform.position;
                if (Input.GetMouseButton(1))
                {
                    GameObject.Find("WeaponsCamera").GetComponent<Camera>().fieldOfView = 90;
                    Vector3 Poffsets = offsets[GameObject.Find("Player").GetComponent<Movement>().animController.GetInteger("WeaponNum") - 1];
                    transform.position += transform.up * Poffsets.y;
                    transform.position += transform.right * Poffsets.x;
                    transform.position += transform.forward * Poffsets.z;
                    GameObject.Find("WeaponsCamera").transform.position = transform.position;
                    GameObject.Find("WeaponsCamera").GetComponent<Animator>().enabled = false;
                }
                else
                {
                    GameObject.Find("WeaponsCamera").GetComponent<Animator>().enabled = true;
                }
            }
            else
            {
                transform.position = GameObject.Find("Player").transform.position + (((Input.GetAxis("Horizontal") * transform.right) / 3));
            }
        }
        else
        {
            transform.position = GameObject.Find("Player").transform.position;
        }
    }

}
