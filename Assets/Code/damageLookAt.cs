using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageLookAt : MonoBehaviour
{
    GameObject playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.Find("PlayerCamera");
        Destroy(gameObject, 5);
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.3f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerCamera.transform);
        transform.Rotate(0, 180, 0);
        transform.localScale *= 0.99f;
    }
}
