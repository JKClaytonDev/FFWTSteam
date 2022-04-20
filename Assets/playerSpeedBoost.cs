using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpeedBoost : MonoBehaviour
{
    public GameObject img;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>())
        {
            img.SetActive(true);
            img.transform.parent = null;
            Destroy(img, 10);
            other.GetComponent<Movement>().speedBoostTime = Time.realtimeSinceStartup + 10;
            Destroy(gameObject);
        }
    }
}
