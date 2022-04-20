using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartgame : MonoBehaviour
{
    public GameObject animatione;
    float saveTime;
    bool saved = false;
    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup > saveTime)
        {
            for (int i = 0; i < 13; i++)
            {
                PlayerPrefs.SetInt(i + "", 0);
            }
            PlayerPrefs.Save();
            saveTime = Time.realtimeSinceStartup  + 30;
        }
            Time.timeScale = 1;
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!saved)
            {
                for (int i = 0; i < 13; i++)
                {
                    PlayerPrefs.SetInt(i + "", 0);
                }
                PlayerPrefs.Save();
                saved = true;
            }
            animatione.SetActive(true);
        }
    }
}
