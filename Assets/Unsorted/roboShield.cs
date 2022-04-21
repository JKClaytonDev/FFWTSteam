using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roboShield : MonoBehaviour
{
    public GameObject shieldPart;
    

    // Update is called once per frame
    void Update()
    {
        transform.position = shieldPart.transform.position;
        transform.rotation = shieldPart.transform.rotation;
    }
}
