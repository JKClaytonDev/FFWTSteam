using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Enabled");
        GetComponent<doneShooting>().Fire();
        GetComponent<FireBullet>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
