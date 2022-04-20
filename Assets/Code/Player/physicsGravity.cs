using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsGravity : MonoBehaviour {
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OH MY GOD MY ANUS");
        collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
