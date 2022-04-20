using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newControls : MonoBehaviour
{
    public GameObject thumb;
    public GameObject w;
    public GameObject a;
    public GameObject s;
    public GameObject d;
    Vector3 pos;
    void Start()
    {
        pos = thumb.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
        Vector3 c = new Vector3(0, 0, 0);
        int length = 0;
        if (Input.GetKey("w")){
            c += w.transform.position;
            length++;
        }
        if (Input.GetKey("a"))
        {
            c += a.transform.position;
            length++;
        }
        if (Input.GetKey("s"))
        {
            c += s.transform.position;
            length++;
        }
        if (Input.GetKey("d"))
        {
            c += d.transform.position;
            length++;
        }
        if (length != 0)
            c /= length;
        else
            c = pos; 
        thumb.transform.position = c;
    }
}
