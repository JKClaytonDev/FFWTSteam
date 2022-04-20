using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instaKill : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Movement>())
        {
            other.gameObject.GetComponent<Movement>().PlayerHealth -= 200;
        }
        if (other.gameObject.GetComponent<enemyHealth>())
        {
            other.gameObject.GetComponent<enemyHealth>().Currenthealth -= 200;
            Destroy(other.gameObject);
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.GetComponent<Movement>())
        {
            other.gameObject.GetComponent<Movement>().PlayerHealth -= 200;
        }
        if (other.gameObject.GetComponent<enemyHealth>())
        {
            other.gameObject.GetComponent<enemyHealth>().Currenthealth -= 200;
            Destroy(other.gameObject);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Movement>())
        {
            other.gameObject.GetComponent<Movement>().PlayerHealth -= 200;
        }
        if (other.gameObject.GetComponent<enemyHealth>())
        {
            other.gameObject.GetComponent<enemyHealth>().Currenthealth -= 200;
            Destroy(other.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Movement>())
        {
            other.gameObject.GetComponent<Movement>().PlayerHealth -= 200;
        }
        if (other.gameObject.GetComponent<enemyHealth>())
        {
            other.gameObject.GetComponent<enemyHealth>().Currenthealth -= 200;
            Destroy(other.gameObject);
        }
    }
}
