using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableRBafterTime : MonoBehaviour
{
    public float time;
    void OnEnable()
    {
        Destroy(GetComponent<Rigidbody>(), time);
    }
}
