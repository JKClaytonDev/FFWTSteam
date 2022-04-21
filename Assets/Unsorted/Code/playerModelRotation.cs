using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerModelRotation : MonoBehaviour {
	public bool x;
	public bool y;
	public bool z;
	public bool w;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = GameObject.Find("Player").transform.position;
		Quaternion rot = transform.rotation;
		if (x)
		rot.x = GameObject.Find("Player").transform.rotation.x;
		if (y)
		rot.y = GameObject.Find("Player").transform.rotation.y;
		if (z)
		rot.z = GameObject.Find("Player").transform.rotation.z;
		if (w)
		rot.w = GameObject.Find("Player").transform.rotation.w;

		transform.rotation = rot;
	}
}
