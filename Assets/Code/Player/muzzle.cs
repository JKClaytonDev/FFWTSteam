using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzzle : MonoBehaviour {
    public GameObject cameraPlayer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = GameObject.Find("Player").GetComponent<Movement>().hitPoint;
	}
}
