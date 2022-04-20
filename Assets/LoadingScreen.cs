    using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    float started;
    public GameObject hideText;
    public GameObject showprogress;
    float spaceTime;
    void Start()
    {
        showprogress.SetActive(false);
        hideText.SetActive(true);
        started = 0;
       
        
    }
    private void Update()
    {
     if (started == 0 && Input.GetKey(KeyCode.Space))
        {
            showprogress.SetActive(true);
            spaceTime = Time.realtimeSinceStartup;
            hideText.SetActive(false);
            started = 1;
            
            
        }   
     if (started == 1 && Time.realtimeSinceStartup > spaceTime+0.3f)
        {
            started = 2;
            LoadLevel(PlayerPrefs.GetInt("SceneLoad"));
            
        }
    }
    public Slider slider;
    public void LoadLevel (int sceneIndex)
    {
        Debug.Log("LOADING");
        StartCoroutine(LoadAsynchronously(PlayerPrefs.GetInt("SceneLoad")));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        UnityEngine.AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;
        }
    }
}
