using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = GameObject.Find("Player").transform.position;
        pos.y += 40;
        GameObject.Find("Player").transform.position = pos;

    }
}
