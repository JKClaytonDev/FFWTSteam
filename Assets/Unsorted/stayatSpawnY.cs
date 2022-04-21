using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayatSpawnY : MonoBehaviour
{
    float yPos;
    // Start is called before the first frame update
    void Start()
    {
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = yPos;
        transform.position = pos;
    }
}
