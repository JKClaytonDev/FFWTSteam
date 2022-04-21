using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSceneKills : MonoBehaviour {
    public float KillsNeeded;
    public Vector3 Direction;
    public float Distance;
    public bool activated;
    private float DistanceSoFar;
    // Use this for initialization
    void Start()
    {
        transform.position -= Direction*Distance;
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        KillsNeeded = Enemies.Length - KillsNeeded;
        DistanceSoFar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (DistanceSoFar < Distance) {
                transform.position += Direction;
                DistanceSoFar++;
            }
        }
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (!activated && Enemies.Length <= KillsNeeded)
        {
            activated = true;
        }

    }
}
