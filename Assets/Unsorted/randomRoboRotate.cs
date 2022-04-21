using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRoboRotate : MonoBehaviour
{
    float rot;
    void Update()
    {
        if (Random.Range(1, 255) > 250)
            rot = Random.Range(-1.1f, 1.1f);
        transform.Rotate(0, rot, 0);
    }
}
