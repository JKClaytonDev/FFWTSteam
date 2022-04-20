using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableafterTime : MonoBehaviour
{
    public Camera cam;
    void Update()
    {

        if (Time.realtimeSinceStartup > 3)
            cam.enabled = false;
    }
}
