using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
    public GameObject player;
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = player.transform.position;
        pos.y += 32;
        transform.position = pos;
	}
}
