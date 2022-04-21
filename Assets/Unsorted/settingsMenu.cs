using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class settingsMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameObject.SetActive(false);
        }
        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene("MainMenu");
            gameObject.SetActive(false);
        }
    }
}
