using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSceneLoader : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = true;
    }
    public void loadScene(string scene)
    {
        
        SceneManager.LoadScene(scene);
    }
}
