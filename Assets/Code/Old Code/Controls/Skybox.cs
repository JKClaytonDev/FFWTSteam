using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox : MonoBehaviour {

	// Use this for initialization
	void Start () {
            RenderSettings.skybox.SetColor("_Ground", Color.red);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
