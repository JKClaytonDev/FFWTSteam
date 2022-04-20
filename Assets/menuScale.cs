using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScale : MonoBehaviour
{
    public float defaultScale;
    public void swap()
    {
        Debug.Log("SWAPPED");
        if (transform.localScale.x != defaultScale)
        {
            Vector3 scale = transform.localScale;
            scale.x = defaultScale;
            transform.localScale = scale;

        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x = 0;
            transform.localScale = scale;
        }
    }
}
