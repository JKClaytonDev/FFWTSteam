using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public KeyCode key;
    void Start()
    {
        Destroy(gameObject, 20);  
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
            Destroy(gameObject);
    }
}
