using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSkin : MonoBehaviour
{
    public void SetSkin(string s)
    {
        PlayerPrefs.SetString("Skin", s);
        PlayerPrefs.Save();
    }
}
