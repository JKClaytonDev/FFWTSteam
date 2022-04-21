using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingParticles : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Start()
    {
        if (!player)
            player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.position = player.transform.position;
    }
}
