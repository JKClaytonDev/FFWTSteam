using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughWalls : MonoBehaviour
{
    public Camera seeCam;
    float distance;
    public Animator anim;
    bool pressed;
    // Update is called once per frame
    void Update()
    {
        anim.SetBool("SeeWalls", Input.GetKey(KeyCode.Tab));
        seeCam.farClipPlane = distance;
        if (Input.GetKey(KeyCode.Tab) && distance < 1000)
        {
            if (!pressed)
            anim.Play("SeeWalls", 0);
            distance += Time.deltaTime * 160;
        }
        else
            distance = 0;
        seeCam.enabled = (distance > 5);
        pressed = Input.GetKey(KeyCode.Tab);
    }
}
