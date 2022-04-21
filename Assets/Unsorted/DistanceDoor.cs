using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDoor : MonoBehaviour
{
    GameObject player;
    public Vector3 endPos;
    Vector3 startPos;
    public float threshold;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        player = FindObjectOfType<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, startPos) > threshold)
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * 15);
        else
            transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * 15);
    }
}
