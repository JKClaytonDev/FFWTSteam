using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotShooting : MonoBehaviour {
    private Animator anim;
    public AnimationClip walking;
    public AnimationClip shooting;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //anim.enabled = false;
	}
}
