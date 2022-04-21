using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToonShader : MonoBehaviour {
    public Camera cam;
    public Shader shader;
	// Use this for initialization
	void Start () {
        cam.RenderWithShader(shader, "Platform");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
