using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeChildren : MonoBehaviour
{
    private void OnEnable()
    {
        foreach (GameObject g in transform)
        {
            g.transform.parent = null;
        }
    }
}
