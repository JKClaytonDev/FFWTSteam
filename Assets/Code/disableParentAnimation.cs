using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableParentAnimation : MonoBehaviour {
    public GameObject obj;
	// Use this for initialization
	void Start () {
        GameObject.Find("LoadLevel").GetComponent<LevelLoader>().loading = false;
        obj.SetActive(false);
        enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
