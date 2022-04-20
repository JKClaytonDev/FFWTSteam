using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class autoloadscene : MonoBehaviour {
    private float time;
    /*
	// Use this for initialization
	void Start () {
        time = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
        if ((PlayerPrefs.GetString("lastLevel")) != "MainHub")
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("lastLevel"));
        }
        else if (time + 5 < Time.realtimeSinceStartup)
            SceneManager.LoadScene("MainMenu");
	}
    */
}
