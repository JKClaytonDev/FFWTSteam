using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class tips : MonoBehaviour {
    public string[] tip;
	// Use this for initialization
	void Start () {
        GetComponent<TextMeshProUGUI>().text = tip[Random.Range(0, tip.Length - 1)];
        GetComponent<TextMeshProUGUI>().fontSize = 36 / ((GetComponent<TextMeshProUGUI>().text.Length) / 20);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
