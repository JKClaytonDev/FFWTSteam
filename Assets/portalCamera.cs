using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCamera : MonoBehaviour
{
    public Vector3 offset;
    public GameObject playerCamera;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (playerCamera){
            transform.position = playerCamera.transform.position + offset;
            transform.rotation = playerCamera.transform.rotation;
        }
    }
}
