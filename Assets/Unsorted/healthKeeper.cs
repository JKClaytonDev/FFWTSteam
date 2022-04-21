using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthKeeper : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
     if (other.GetComponent<Movement>())
        {
            other.GetComponent<Movement>().PlayerHealth = 100;
            other.GetComponent<Movement>().playerHealth = 100;
            
        }   
    }
}
