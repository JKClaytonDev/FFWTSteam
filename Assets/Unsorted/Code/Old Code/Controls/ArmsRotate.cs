using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ArmsRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            transform.rotation = GameObject.Find("Player").transform.rotation;
            Quaternion rot = transform.rotation;
            rot.x /= 55;
            rot.z /= 55;
            rot.y = 0;
            transform.rotation = rot;
        }
    }
}
