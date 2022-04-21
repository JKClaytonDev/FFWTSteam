using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextMaster : MonoBehaviour
{
    public string[] messages;
    int messageNum;
    int letterCount;
    double lastLetter;
    public GameObject space;
    // Start is called before the first frame update
    void Start()
    {
        messageNum = 0;
        letterCount = 0;
        lastLetter = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if (letterCount <= messages[messageNum].Length-1 && lastLetter+0.1 < Time.realtimeSinceStartup)
        {
            letterCount++;
            lastLetter = Time.realtimeSinceStartup;
        }
        GetComponent<Text>().text = messages[messageNum].Substring(0, letterCount);
        if (letterCount == messages[messageNum].Length)
        {
            space.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (messageNum < messages.Length-1)
                {
                    letterCount = 0;
                    messageNum++;
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
        else
            space.SetActive(false);
    }
}
