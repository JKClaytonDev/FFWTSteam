using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class confirmWorkshop : MonoBehaviour
{
    public GameObject inputField;
    public GameObject inputText;
    public GameObject loading;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MouseButton>().MouseOver && Input.GetMouseButtonDown(0))
        {
            if (Application.CanStreamedLevelBeLoaded(inputText.GetComponent<Text>().text))
            {
                loading.SetActive(true);
                loading.GetComponent<loadScene>().SceneName = (inputText.GetComponent<Text>().text);
            }
            else
                inputText.GetComponent<Text>().text = "invalid!";
        }
    }
}
