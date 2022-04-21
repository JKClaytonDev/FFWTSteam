using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformposition : MonoBehaviour {
    public float speed;
    public Vector3 pos;
    public GameObject player;
    Vector3 playerpos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	void Update () {
        playerpos = player.transform.position;
        if (Input.GetKey("w"))
        {
            playerpos += transform.forward * speed;
        }
        if (Input.GetKey("d"))
        {
            playerpos += transform.right * speed;
        }
        if (Input.GetKey("s"))
        {
            playerpos += transform.forward * -1 * speed;
        }
        if (Input.GetKey("a"))
        {
            playerpos+= transform.right * -1 * speed;
        }
        pos = playerpos;
        transform.position = playerpos;
    }
}
