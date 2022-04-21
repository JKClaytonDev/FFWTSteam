using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpBar : MonoBehaviour
{
    public float jumps;
    Movement mvmt;

    // Update is called once per frame
    void Update()
    {
        if (!mvmt)
            mvmt = FindObjectOfType<Movement>();
        if (mvmt)
        {
            jumps = mvmt.jumps;
            Vector3 scale = transform.localScale;
            scale.x = 7 - (3.5f*jumps);
            transform.localScale = scale;
        }
    }
}
