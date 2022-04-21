using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPad : MonoBehaviour {
    public bool forward;
    // Use this for initialization
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            if (!forward)
                collision.gameObject.GetComponent<Rigidbody>().velocity += 15 * transform.up;
            else
                collision.gameObject.GetComponent<Rigidbody>().velocity += 5 * (transform.up + transform.forward);
        }
        if (collision.gameObject.GetComponent<Movement>() && forward)
        {
            collision.gameObject.GetComponent<Movement>().extraSpeed += 3 *transform.forward;
        }
            
    }

}
