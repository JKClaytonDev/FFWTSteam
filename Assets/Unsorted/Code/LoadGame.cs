using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadGame : MonoBehaviour
{
    public GameObject loading;
    public string SceneName;

    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MouseButton>().MouseOver && (Input.GetMouseButton(0) || Input.GetAxis("Fire1") > 0))
        {
            loading.SetActive(true);
            loading.GetComponent<loadScene>().SceneName = (PlayerPrefs.GetString("LevelName"));
        }
    }
}
