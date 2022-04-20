using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MapCode : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Custom", 1);
        PlayerPrefs.Save();
    }
    void Update()
    {
        PlayerPrefs.SetString("MapEditor", text.text);
        PlayerPrefs.Save();
    }
    public void loadScene()
    {
        SceneManager.LoadScene("CustomMap");
    }
}
