using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legs : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.layer = 2;
        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>(true))
        {
            child.gameObject.layer = LayerMask.NameToLayer("TransparentFX");  // add any layer you want. 
        }
        this.enabled = false;

    }
}
