using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewGame : MonoBehaviour {
    public string SceneName;
    public GameObject loading;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (GetComponent<MouseButton>().MouseOver && (Input.GetMouseButton(0) || Input.GetAxis("Fire1") > 0))
        {
            PlayerPrefs.SetString("LevelName", SceneName);
            loading.SetActive(true);
            loading.GetComponent<loadScene>().SceneName = (SceneName);
        }
	}
}
