using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 transpos;
    public bool offset;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transpos += (player.GetComponent<Rigidbody>().velocity - (transpos));
        transform.position = player.transform.position + transpos/-30;
    }
}
