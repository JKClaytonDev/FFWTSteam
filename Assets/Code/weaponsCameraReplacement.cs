using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponsCameraReplacement : MonoBehaviour
{
    Movement player;
    Vector3 lastPos;
    float fw;
    float r;
    float u;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Movement>();
        fw = transform.localPosition.x;
        u = transform.localPosition.y;
        r = transform.localPosition.z;
    }
    void Update()
    {
        Vector3 pos = player.transPos;
        transform.position = pos + transform.forward + (0 * new Vector3(Mathf.Sin(pos.x), 0, Mathf.Sin(pos.z))) + 0 * (transform.right*r + transform.up * u + transform.forward * fw);
        
    }
}
