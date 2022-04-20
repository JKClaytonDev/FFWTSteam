using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = GameObject.Find("Player").transform.position;
        pos.y += 20;
        transform.position = pos;

        if (Input.GetKey(KeyCode.Tab))
        {
            GetComponent<Camera>().enabled = true;
            GameObject.Find("PlayerCamera").GetComponent<Camera>().enabled = false;
            GameObject.Find("WeaponsCamera").GetComponent<Camera>().enabled = false;
        }
        else
        {
            GetComponent<Camera>().enabled = false;
            GameObject.Find("PlayerCamera").GetComponent<Camera>().enabled = true;
            GameObject.Find("WeaponsCamera").GetComponent<Camera>().enabled = true;
        }
    }

}
