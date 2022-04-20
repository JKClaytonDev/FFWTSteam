using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingRed : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Player").GetComponent<Movement>() == null)
        Debug.Log("ok");
        
       Renderer renderer = GetComponent<Renderer>();

        Material mat = renderer.material;
        float emission = Mathf.PingPong(Time.time, 1.0f);
        Color baseColor = Color.red;
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissionColor", finalColor);
    }
}
