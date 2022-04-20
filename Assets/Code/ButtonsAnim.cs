using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsAnim : MonoBehaviour
{
    public bool LeftArm;
    public bool RightArm;
    
    void Update()
    {
        if (LeftArm)
        {
            GetComponent<Animator>().SetBool("ButtonPressed", Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"));
        }
        if (RightArm)
        {
            GetComponent<Animator>().SetBool("ButtonPressed", (Input.GetMouseButton(0) || Input.GetAxis("Fire1") > 0) || Input.GetMouseButton(1) || Input.GetKey(KeyCode.Space));
        }
    }
}
