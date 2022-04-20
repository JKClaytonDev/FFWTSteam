using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsidePlayerLook : MonoBehaviour {
    public bool unlocked;
    public bool slow;
    private float y;
    Vector3 pos;
    Movement PlayerPos;
    bool keepLooking;
    public GameObject player;
    Vector3 ogLocalRot;
    // Use this for initialization
    void Start()
    {
        keepLooking = false;
        Quaternion r = transform.localRotation;
        ogLocalRot = new Vector3(r.x, r.y, r.z);
        if (player == null)
        player = GameObject.Find("Player");
        PlayerPos = player.GetComponent<Movement>();
        if (GameObject.Find("Player") != null)
            player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (!keepLooking)
        {
            keepLooking = GameObject.Find("Player");
        }
        if (player == null)
        {
            if (!FindObjectOfType<Movement>())
                return; 
            player = FindObjectOfType<Movement>().gameObject;
        }
            if (player == null)
            player = GameObject.Find("Player");
        if (player == null)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject p in players)
            {
                if (p.GetComponent<Movement>())
                {
                    player = p;
                    player.name = "Player";
                }
            }
        }

        Vector3 oldPos = transform.position;

        Vector3 oldPos2;
        if (transform.parent)
            oldPos2 = transform.parent.position;
        else
            oldPos2 = transform.position;
        pos = player.transform.position;
        if (!unlocked && !slow)
        {
            if (transform.parent)
            {
                pos.y = transform.parent.position.y;
                transform.parent.LookAt(pos);
            }
            else
            {
                pos.y = transform.position.y;
                transform.LookAt(pos);
            }
        }
        else
        {
            
            if (slow)
                y += (pos.y - y) / 30;

            transform.LookAt(pos);
        }
        transform.position = oldPos;
        if (transform.parent)
        transform.parent.position = oldPos2;
        transform.LookAt(player.transform);
    }
}
