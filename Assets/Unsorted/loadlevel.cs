using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadlevel : MonoBehaviour
{
    public void loadScene(string scene) {
        SceneManager.LoadScene(scene);
    }
    public void openDir()
    {
        Application.OpenURL("https://docs.google.com/document/d/1HwhY2lLRQx5Q04nctSu5fRtPMpezpr5oKDwnapTedD0/edit?usp=sharing");
    }
}
