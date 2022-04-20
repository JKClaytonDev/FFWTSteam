using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastCamera : MonoBehaviour {
	public Camera PlayerCamera;
	// Use this for initialization
	void Start () {
		int Quality = QualitySettings.GetQualityLevel();
		if (Quality < 2){
				GetComponent<Camera>().renderingPath = RenderingPath.VertexLit;
		}
		else
		{
			GetComponent<Camera>().renderingPath = RenderingPath.DeferredLighting;
		}
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Camera>().fieldOfView = 90;


    }
}
