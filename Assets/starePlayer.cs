using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starePlayer : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        Vector3 angles = transform.localEulerAngles;
        angles.x = 0;
        angles.z = 0;
        transform.localEulerAngles = angles;
    }
}
