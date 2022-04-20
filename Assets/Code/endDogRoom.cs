using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endDogRoom : MonoBehaviour
{
    public bool loadScene;
    // Start is called before the first frame update
    void Start()
    {
        loadScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (loadScene)
        SceneManager.LoadScene("Level10");
    }
}
