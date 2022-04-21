using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noYouStayThere : MonoBehaviour {
    private Vector3 pos;
	// Use this for initialization
	void Start () {
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = pos;
	}
}
