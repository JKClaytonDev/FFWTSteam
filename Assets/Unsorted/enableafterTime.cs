using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableafterTime : MonoBehaviour
{
    public GameObject g;
    public float startTime;
    float startxs;
    // Start is called before the first frame update
    void Start()
    {
        float startxs = Time.realtimeSinceStartup;
        g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup-startxs > startTime)
            g.SetActive(true);
        if (Input.GetKey(KeyCode.G))
        {
            Debug.Log("THE TIME IS " + Time.realtimeSinceStartup);
        }
    }
}
