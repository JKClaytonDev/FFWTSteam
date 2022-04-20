using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKillBarrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        if (GameObject.Find("PlayerSpawn"))
        transform.position = GameObject.Find("PlayerSpawn").transform.position;
        transform.position -= Vector3.up * 350;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<enemyHealth>())
            Destroy(other);
    }
}
