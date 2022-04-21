using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fumes : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Movement>())
        {
            other.GetComponent<Movement>().PlayerHealth--;
        }
    }
}
