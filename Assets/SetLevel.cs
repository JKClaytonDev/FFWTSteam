using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SetLevel : MonoBehaviour
{
    string scene;
    public Text txt;
    void Start()
    {
        PlayerPrefs.SetInt("Reverse", 0);
        PlayerPrefs.SetInt("NoClip", 0);
        PlayerPrefs.SetInt("Custom", 0);
        PlayerPrefs.Save();
    }
    public void setScene(string sc)
    {
        scene = txt.text;
    }
    public void loadScene()
    {
        scene = txt.text;
        if (scene == "reverse" || scene == "backwards" || scene == "return" || scene == "runitback")
        {
            PlayerPrefs.SetInt("Reverse", 1);
            Debug.Log("REVERSE IS " + PlayerPrefs.GetInt("Reverse"));
            GameObject.Find("Main Camera").transform.Rotate(new Vector3(0, 580, 0));
            PlayerPrefs.Save();
            return;
        }
        if (scene == "Shesez" || scene == "Boundary Break" || scene == "Noclip" || scene == "BoundaryBreak")
        {
            PlayerPrefs.SetInt("NoClip", 1);
            GameObject.Find("Main Camera").transform.Rotate(new Vector3(0, 580, 0));
            PlayerPrefs.Save();
            return;
        }
        if (scene == "Level1" || scene == "RetroLevel1")
        {
            PlayerPrefs.SetInt("AirDash", 0);
            PlayerPrefs.SetInt("SuperBounce", 0);
            PlayerPrefs.SetInt("FastFiring", 0);
            PlayerPrefs.Save();
        }

        else if (scene == "reset" || scene == "RESET" || scene == "Reset")
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetFloat("Mouse", 2);
            SceneManager.LoadScene("otherMenu");
            PlayerPrefs.Save();
            GameObject.Find("Main Camera").transform.Rotate(new Vector3(0, 580, 0));
            return;
        }
        SceneManager.LoadScene(scene);
    }
}
