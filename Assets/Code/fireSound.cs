using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSound : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (!player)
            player = GameObject.Find("Player");
        else
            GetComponent<AudioSource>().volume = 15 + 500/Mathf.Abs(transform.position.y - player.transform.position.y);
    }
}
