using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceField : MonoBehaviour
{
    public GameObject[] enemyList;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject g in enemyList)
        {
            if (g.name.Contains("Missing"))
                return;
        }
        transform.position += Vector3.up * 15 * Time.deltaTime;
    }
}
