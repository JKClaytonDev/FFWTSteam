using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sloMo : MonoBehaviour
{
    public Material[] animationMat;
    private int frame;
    private float frameTime;
    public bool isParent;
    // Use this for initialization
    void Start()
    {
        isParent = (!gameObject.name.Contains("(Clone)"));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isParent && (Time.timeScale == 1))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (!isParent && (Time.timeScale == 1))
        {
            Destroy(gameObject);
        }
    }
}
