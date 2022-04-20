using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotRotate : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion oldRot = transform.rotation;
        transform.LookAt(GameObject.Find("Player").transform);
        Quaternion newRot = transform.rotation;
        oldRot.x += (newRot.x - oldRot.x) / 25;
        oldRot.y += (newRot.y - oldRot.y) / 25;
        oldRot.z += (newRot.z - oldRot.z) / 25;
        transform.rotation = oldRot;
    }
}
