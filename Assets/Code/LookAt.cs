using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {
    public bool dontSet;
    GameObject player;
	// Use this for initialization
	void Start () {
        if (!FindObjectOfType<Movement>())
            return;
        if (!player)
            player = FindObjectOfType<Movement>().gameObject;

    }
    void FixedUpdate()
    {
        if (Time.frameCount % 45 != 0 && !player)
            return;
        if (!FindObjectOfType<Movement>())
            return;
        if (!player)
            player = FindObjectOfType<Movement>().gameObject;
        if (!player)
            return;
        transform.LookAt(player.transform);
        if (!dontSet)
        transform.Rotate(-transform.rotation.x, 0, -transform.rotation.z);
    }

}
