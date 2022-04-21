using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePosition : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = cam.transform.localEulerAngles;
        rot.x = (Input.mousePosition.y-Screen.height/2)/ Screen.height*-500;
        rot.y = (Input.mousePosition.x - Screen.width / 2) / Screen.width * 500;
        cam.transform.localEulerAngles = rot / 55;
    }

}
