using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeMove : MonoBehaviour {
    private float explodeTime;
    public bool checkedYet;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(900, 900, 900);
        checkedYet = false;

	}

    // Update is called once per frame
    void Update() {
        if (!checkedYet && transform.position != new Vector3(900, 900, 900)) {
            explodeTime = Time.realtimeSinceStartup;
            checkedYet = true;
        }
        if (checkedYet && explodeTime + 2 < Time.realtimeSinceStartup) {
            checkedYet = false;
            transform.position = new Vector3(900, 900, 900);
        }
    }
}
