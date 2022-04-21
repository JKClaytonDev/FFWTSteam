using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Continue : MonoBehaviour
{
    float loadTime;
    public GameObject NewGame;
    void Start()
    {
        Debug.Log(this.gameObject.name);
        loadTime = 200000000;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (!(PlayerPrefs.GetString("Scene") != "Level1" && PlayerPrefs.GetString("Scene") != "" && SceneManager.GetSceneByName(PlayerPrefs.GetString("Scene")) != null && PlayerPrefs.GetString("Scene") != null))
        {
            NewGame.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            Destroy(gameObject);
        }
    }
    public void ContinueGame()
    {

        if (!(PlayerPrefs.HasKey("Scene") && PlayerPrefs.GetString("Scene") != "" && SceneManager.GetSceneByName(PlayerPrefs.GetString("Scene")) != null && PlayerPrefs.GetString("Scene") != null))
            PlayerPrefs.SetString("Scene", "Level1");
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("Scene"));
        return;
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("Scene"));
        Debug.Log("PP " + PlayerPrefs.HasKey("Scene"));
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            GameObject.Find("Buttons").SetActive(false);
            GameObject.Find("Main Camera").GetComponent<Animator>().enabled = false;
            GameObject.Find("Main Camera").transform.rotation = new Quaternion(90, -2.23f, 0, 0);
            GameObject.Find("TheSmashersLogo").GetComponent<RectTransform>().localPosition = new Vector2(-45, -164);
            GameObject.Find("TheSmashersLogo").GetComponent<RectTransform>().localScale = new Vector3(1, 0.7f, 0.5f);
            GameObject.Find("GameLogo").GetComponent<RectTransform>().localPosition = new Vector2(3, 21);
            GameObject.Find("GameLogo").GetComponent<RectTransform>().localScale = new Vector3(6, 2, 2);
            loadTime = 0;
        }
        loadScene();
    }
    void loadScene()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("Scene"));
    }
}
