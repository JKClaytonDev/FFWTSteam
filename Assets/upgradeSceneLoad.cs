using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class upgradeSceneLoad : MonoBehaviour
{
    public string[] scenes;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            GetComponent<Text>().text = "";
            if (FindObjectOfType<NextLevelName>())
            {
                Debug.Log("THIS IS ME ITS ME I USED THE LOADNEXTSCENE THATSD ME HASHASHASDHASHDAHSDHASDDHSAD");
                SceneManager.LoadScene(FindObjectOfType<NextLevelName>().nextLevel);
                this.enabled = false;
                return;
            }
            if (FindObjectOfType<musicHost>())
            {
                musicHost host = FindObjectOfType<musicHost>();
                int foundvalue = -1;
                string currentScene = SceneManager.GetActiveScene().name;
                for (int i = 0; i < host.sceneOrder.Length; i++)
                {
                    if (host.sceneOrder[i] == currentScene)
                        foundvalue = i;
                }
                if (foundvalue != -1)
                {
                    Debug.Log("USED FOUND VALUE " + host.sceneOrder[foundvalue + 1]);
                    SceneManager.LoadScene(host.sceneOrder[foundvalue + 1]);
                    gameObject.SetActive(false);
                    return;

                }
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            gameObject.SetActive(false);
        }

    }
}
