using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connectBones : MonoBehaviour {
    public GameObject parent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (parent != null)
        transform.position = parent.transform.position;
	}
}
