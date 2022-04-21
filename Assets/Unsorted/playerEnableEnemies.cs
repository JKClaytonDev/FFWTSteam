using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEnableEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        foreach (GameObject e in enemies)
            e.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Movement>())
        {
            foreach (GameObject e in enemies)
                e.SetActive(true);
            Destroy(gameObject);
        }
    }
}
