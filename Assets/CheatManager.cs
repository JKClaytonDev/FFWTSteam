using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Chaingun", 0);
        PlayerPrefs.SetInt("Mirror", 0);
        PlayerPrefs.SetInt("TinyPlayer", 0);
        PlayerPrefs.SetInt("SuperHot", 0);
        PlayerPrefs.SetInt("MoonGravity", 0);
        PlayerPrefs.SetInt("NoHUD", 0);
        PlayerPrefs.SetInt("NoClip", 0);
        PlayerPrefs.SetInt("BunnyHop", 0);
        PlayerPrefs.SetInt("Reverse", 0);
        PlayerPrefs.SetInt("AllGuns", 0);
        PlayerPrefs.SetInt("InfAmmo", 0);
        
        PlayerPrefs.Save();
    }

    public void disableAll()
    {
        PlayerPrefs.SetInt("Chaingun", 0);
        PlayerPrefs.SetInt("Mirror", 0);
        PlayerPrefs.SetInt("TinyPlayer", 0);
        PlayerPrefs.SetInt("SuperHot", 0);
        PlayerPrefs.SetInt("MoonGravity", 0);
        PlayerPrefs.SetInt("NoHUD", 0);
        PlayerPrefs.SetInt("NoClip", 0);
        PlayerPrefs.SetInt("BunnyHop", 0);
        PlayerPrefs.SetInt("Reverse", 0);
        PlayerPrefs.SetInt("AllGuns", 0);
        PlayerPrefs.SetInt("InfAmmo", 0);

        PlayerPrefs.Save();
    }
    public void EnableCheat(string cheat)
    {
        Debug.Log(PlayerPrefs.GetInt(cheat) + "OLD");
        PlayerPrefs.SetInt(cheat, 1);
        Debug.Log(PlayerPrefs.GetInt(cheat) + "NEW");
        PlayerPrefs.Save();
    }
}
