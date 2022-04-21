using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().farClipPlane = 1000000;
    }

    // Update is called once per frame
   void Update()
    {
        GetComponent<Camera>().farClipPlane = 1000000;
    
}
}
