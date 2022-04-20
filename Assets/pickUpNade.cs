using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpNade : MonoBehaviour
{
    float nadeCount = 3;
    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Movement>())
            if (!other.GetComponent<Movement>().hasNade)
            {
                other.GetComponent<Movement>().hasNade = true;
                transform.localScale = new Vector3(1, 1, 1) * (10 / (4-nadeCount));
                nadeCount--;
            }
        if (nadeCount <= 0)
            Destroy(gameObject);
                }
}
