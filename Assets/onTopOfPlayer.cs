using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTopOfPlayer : MonoBehaviour
{
    public bool playerCamera;
    public GameObject player;
    public Vector3 change;
    public bool includeY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            if (playerCamera)
                player = FindObjectOfType<Camera>().gameObject;
            else
            player = FindObjectOfType<Movement>().gameObject;
            return;
        }
        if (playerCamera)
            transform.rotation = player.transform.rotation;
        Vector3 pos = player.transform.position;
        if (!includeY)
        {
            pos.y = transform.position.y;
        }
        transform.position = pos+(transform.forward*change.z) + (transform.up * change.y) + (transform.right * change.x);
    }
}
