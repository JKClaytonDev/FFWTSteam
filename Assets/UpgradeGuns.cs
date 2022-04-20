using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UpgradeGuns : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public GameObject loading;
    public void left()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        loading.SetActive(true);
        PlayerPrefs.SetInt("AirDash", 1);
        PlayerPrefs.SetInt("SuperBounce", 0);
        PlayerPrefs.SetInt("FastFiring", 0);
        PlayerPrefs.SetInt("LoadingScene", 14);
        SceneManager.LoadScene("FireWorld4");
    }
    public void middle()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        loading.SetActive(true);
        PlayerPrefs.SetInt("AirDash", 0);
        PlayerPrefs.SetInt("SuperBounce", 1);
        PlayerPrefs.SetInt("FastFiring", 0);
        PlayerPrefs.SetInt("LoadingScene", 14);
        SceneManager.LoadScene("FireWorld4");
    }
    public void right()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        loading.SetActive(true);
        PlayerPrefs.SetInt("AirDash", 0);
        PlayerPrefs.SetInt("SuperBounce", 0);
        PlayerPrefs.SetInt("FastFiring", 1);
        PlayerPrefs.SetInt("LoadingScene", 14);
        SceneManager.LoadScene("FireWorld4");
    }
}
