using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class returntoMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetMouseButton(0) || Input.GetAxis("Fire1") > 0) && GetComponent<MouseButton>().MouseOver)
        {
            //SceneManager.LoadScene("MainMenu");
        }
	}
}
