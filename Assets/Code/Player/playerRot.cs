using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRot : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = player.transform.rotation;
    }
}
