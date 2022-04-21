using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireToggle : MonoBehaviour
{
    doneShooting shot;
    GameObject parent;
    public bool red;
    public bool green;
    float startTime;
    float lastTime;
    public Material Glowing;
    public Material Default;
    Vector3 rot;
    Vector3 targetRot;
    Vector3 target;
    bool val;
    bool lastfire;
    public float CustomSwapTime = 5;
    void Start()
    {
        shot = FindObjectOfType<doneShooting>();
        lastfire = shot.fireMode;
        val = red;
        if (red)
            transform.parent.Rotate(0, 90, 0);
        parent = transform.parent.gameObject;
        transform.parent = null;
        rot = transform.localEulerAngles;
        transform.Rotate(0, 0, 90);
        targetRot = transform.localEulerAngles;
        transform.localEulerAngles = rot;
        startTime = 0;

    }
    void Update()
    {

        startTime += Time.realtimeSinceStartup - lastTime;
        lastTime = Time.realtimeSinceStartup;
        if (startTime > 2 * CustomSwapTime)
            startTime = 0;

        if (lastfire != shot.fireMode)
        {

                val = !val;

        }
        lastfire = shot.fireMode;
        if (val)
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, rot, Time.deltaTime * 500);
        else
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, targetRot, Time.deltaTime * 500);


    }
}
