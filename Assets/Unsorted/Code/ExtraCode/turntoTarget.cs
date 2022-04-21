using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turntoTarget : MonoBehaviour {
    public GameObject parent;
    private bool isParent;
    public bool stayStill;
    public bool onlyForBeginning;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion oldRot = transform.rotation;
        transform.LookAt(parent.GetComponent<strafingLegs>().randomTarget);
        Quaternion newRot = transform.rotation;
        Quaternion mixedRot = oldRot;
        oldRot.x += 0; //(newRot.x - oldRot.x) / 15;
        oldRot.y += (newRot.y - oldRot.y) / 15;
        oldRot.z += 0; //(newRot.z - oldRot.z) / 15;
        transform.rotation = oldRot;
    }
}
