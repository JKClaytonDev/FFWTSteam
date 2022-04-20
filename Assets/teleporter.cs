using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public GameObject enable;
    public GameObject otherTele;
    private void Start()
    {
        enable.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (enable)
        enable.SetActive(true);
        other.transform.position = otherTele.transform.position;
        other.transform.LookAt(otherTele.transform);
        other.transform.Rotate(0, 180, 0);
    }
}
