using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingBlue : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        Renderer renderer;
        renderer = GetComponent<Renderer>();
        if (!renderer)
            renderer = GetComponent<MeshRenderer>();
        if (!renderer)
            renderer = GetComponent<SkinnedMeshRenderer>();
        Material mat = renderer.material;
        float emission = Mathf.PingPong(Time.time, 1.0f);
        Color baseColor = Color.blue;
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        mat.SetColor("_EmissiveColor", finalColor);
    }
}
