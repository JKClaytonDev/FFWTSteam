using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
