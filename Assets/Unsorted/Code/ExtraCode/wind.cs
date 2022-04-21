using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind : MonoBehaviour {
    public GameObject push;
    private void OnTriggerStay(Collider other)
    {
        Vector3 pos = other.transform.position;
        pos.y = transform.position.y;
        other.transform.position = pos;
        other.transform.position += transform.forward;
    }
    private void OnTriggerExit(Collider other)
    {
        push = null;
    }
    public float WF_speed = 0.75f;

    private Renderer WF_renderer;

    void Start()
    {
        WF_renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector3 pos = push.transform.position;
        pos.y = transform.position.y+Mathf.Sin(Time.realtimeSinceStartup/5)*2;
        push.transform.position = pos;
        push.transform.position += transform.forward;
        
    }
}
