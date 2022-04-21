using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReplaceText : MonoBehaviour {
    public GameObject target;
	// Use this for initialization
	void Start () {
            TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
            textmeshPro.SetText("hamburger", target.transform);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
