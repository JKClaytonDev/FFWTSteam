using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBullet : MonoBehaviour {
    public Vector3 bulletdirection;
    public float speedmodified;
    public GameObject player;
    // Use this for initialization
    void Start()
    {

        bulletdirection = transform.forward * 5 * (speedmodified+1);

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += bulletdirection / 100;
    }
}
