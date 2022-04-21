using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotFire : MonoBehaviour {
    public bool fire;
    private bool set;
    public GameObject mommy;
    public AnimationEvent evt2;
    GameObject force;
    public AnimationEvent evt3;
    public AnimationEvent evt4;
    // Use this for initialization
    void Start() {
        evt2.functionName = "Reset";
        evt3.functionName = "Started";
        evt4.functionName = "Fire";
        GetComponent<Animator>().SetBool("hit", true);
        GetComponent<Animator>().speed = Random.Range(1.2f, 0.8f);
    }

    // Update is called once per frame
    void Fire()
    {
            mommy.GetComponent<RobotMoving>().fireBullet();
    }
	void FixedUpdate () {
        if (fire)
            mommy.GetComponent<RobotMoving>().fireBullet();
        if (GetComponent<Animator>().GetBool("hit") && !set)
        {
            set = true;
            GetComponent<Animator>().Play("robotHit");
        }
        else if (!GetComponent<Animator>().GetBool("hit"))
            set = false;
        transform.localPosition.Set(0, 0, 0);
	}
    public void Reset()
    {
        GetComponent<Animator>().SetBool("hit", false);
        GetComponent<Animator>().SetBool("started", false);
    }
    public void Started()
    {
        GetComponent<Animator>().SetBool("started", true);
    }
}
