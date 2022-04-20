using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AnimatorReadyIntro : MonoBehaviour {
    public string enabledScene;
    public Sprite[] images;
	// Use this for initialization
	void Start () {
        enabledScene = SceneManager.GetActiveScene().name;
        
        
	}
	
	// Update is called once per frame
	void Update () {
		if (enabledScene != SceneManager.GetActiveScene().name)
        {
            GetComponent<Animator>().SetBool("LoadDone", true);
            GetComponent<Animator>().SetBool("Play", false);
            enabledScene = SceneManager.GetActiveScene().name;
            enabled = false;
        }
	}
}
