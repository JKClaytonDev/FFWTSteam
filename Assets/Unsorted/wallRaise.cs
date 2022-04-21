using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallRaise : MonoBehaviour
{
    Vector3 target;
    public bool closeWall;
    // Start is called before the first frame update
    void Start()
    {
        closeWall = false;
        target = transform.position;
        transform.position -= Vector3.up * 10;
    }

    // Update is called once per frame
    void Update()
    {

        
        GetComponent<MeshRenderer>().material.SetFloat("Vector1_13DBC9D6", (target.y - transform.position.y) / 20);
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime*15);
        if (closeWall)
            transform.localScale /= 1 + 15*Time.deltaTime;
        if (transform.localScale.x < 0.01f)
            Destroy(gameObject);
    }
}
