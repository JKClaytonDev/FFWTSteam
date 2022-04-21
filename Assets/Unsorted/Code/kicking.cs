using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kicking : MonoBehaviour {
    public AnimationEvent evt;
    public AnimationEvent evt2;
    float kickTime;
    private bool kickingKey;
    // Use this for initialization
    void Start () {
        kickTime = 0;
        kickingKey = false;
        evt.functionName = "resetKick";
        evt2.functionName = "resetKickOnly";
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("f") && !((GetComponent<Animator>().GetBool("Kicking") || (GetComponent<Animator>().GetBool("Sliding")))) && Time.realtimeSinceStartup < kickTime)
        {
            kickTime = Time.realtimeSinceStartup  +2;
            GetComponent<Animator>().SetBool("Kicking", false);
            GetComponent<Animator>().SetBool("Sliding", false);
            kickingKey = true;
            Vector3 vel = GameObject.Find("Player").GetComponent<Rigidbody>().velocity;
            vel.x *= 4;
            vel.z *= 4;
            vel.y -= Mathf.Abs(vel.y * 2);
            GameObject.Find("Player").GetComponent<Rigidbody>().velocity = vel;
            if (!GetComponent<Animator>().GetBool("Sliding"))
                GameObject.Find("Player").GetComponent<Movement>().extraSpeed += GameObject.Find("Player").transform.forward / 2;
            if (GameObject.Find("Player").GetComponent<Movement>().jumps != 0 || Mathf.Abs(GameObject.Find("Player").GetComponent<Rigidbody>().velocity.y) > 1)
                GetComponent<Animator>().SetBool("Kicking", true);
            else
                GetComponent<Animator>().SetBool("Sliding", true);
        }
        if ((GetComponent<Animator>().GetBool("Kicking") || (GetComponent<Animator>().GetBool("Sliding")))){
            if (GetComponent<Animator>().GetBool("Kicking"))
            {
                //GameObject.Find("WeaponsCamera").transform.rotation = GameObject.Find("Player").transform.rotation;
                //GameObject.Find("WeaponsCamera").transform.Rotate(5, 0, -5);
            }
            else
            {
                //GameObject.Find("WeaponsCamera").transform.rotation = GameObject.Find("Player").transform.rotation;
            }
            transform.rotation = GameObject.Find("Player").transform.rotation;
            if (GetComponent<Animator>().GetBool("Sliding"))
            {
                Quaternion rot = GameObject.Find("Player").transform.rotation;
                rot.x = 0;
                rot.z = 0;
                transform.rotation = rot;
            }
        }
    }

    public void resetKick()
    {
        GetComponent<Animator>().SetBool("Kicking", false);
        GetComponent<Animator>().SetBool("Sliding", false);
        kickingKey = false;
    }

    public void resetKickOnly()
    {
        GetComponent<Animator>().SetBool("Kicking", false);

    }
}
