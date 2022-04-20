using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetJumps : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("Player").GetComponent<Movement>().jumps = 0;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
