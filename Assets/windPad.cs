using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windPad : MonoBehaviour
{
    public bool pushEverything;
    public AudioClip clip;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>() || pushEverything)
        {
            if (other.GetComponent<Movement>())
            GetComponent<AudioSource>().PlayOneShot(clip);
            if (other.GetComponent<Rigidbody>().velocity.y < 100)
                other.GetComponent<Rigidbody>().velocity += transform.up * Time.deltaTime * 500;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Movement>() || pushEverything) {
            if (other.GetComponent<Rigidbody>().velocity.y < 100)
            other.GetComponent<Rigidbody>().velocity += transform.up * Time.deltaTime * 50;
            }
    }
}
