using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class fragCount : MonoBehaviour
{
    public GameObject pressSpace;
    float nextTime;
    public bool sceneLoader;
    float number;
    public string text;
    public float targetNumber;
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("KILLS ARE " + PlayerPrefs.GetInt("Kills"));
        targetNumber = PlayerPrefs.GetInt("Deaths");
        if (GetComponent<Text>().text == "FRAGS: ")
            targetNumber = PlayerPrefs.GetInt("Kills");
        PlayerPrefs.SetInt("Kills", 0);
        PlayerPrefs.SetInt("Deaths", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (pressSpace)
        pressSpace.SetActive(false);
        if (number == targetNumber)
        {
            if (pressSpace)
            {
                pressSpace.SetActive(true);
            }
        }
            if (Time.realtimeSinceStartup > nextTime)
        {
            nextTime = Time.realtimeSinceStartup + 0.06f;
            if (number == targetNumber)
            {
                if (pressSpace)
                {
                    pressSpace.SetActive(true);
                }
                if (sceneLoader && Input.GetKey(KeyCode.K)){
                    pressSpace.SetActive(false);
                    SceneManager.LoadScene(scene);
                }
            }
            else
            {
                number++;
            }
            GetComponent<Text>().text = text + number;
            
        }
    }
}
