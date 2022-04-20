using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {
    private float destroytime;
	// Use this for initialization
	void Start () {
        destroytime = Time.realtimeSinceStartup+10;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.realtimeSinceStartup > destroytime)
            Destroy(gameObject);
	}
}
