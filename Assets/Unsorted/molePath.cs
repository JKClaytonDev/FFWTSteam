using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class molePath : MonoBehaviour
{
    public GameObject mole;
    float startY;
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = mole.transform.position;
        pos.y = startY;
        transform.position = pos;
    }
}
