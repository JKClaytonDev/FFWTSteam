using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLookAt : MonoBehaviour
{
    GameObject playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.Find("PlayerCamera");
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerCamera.transform);
        transform.Rotate(0, 180, 0);
    }
}
