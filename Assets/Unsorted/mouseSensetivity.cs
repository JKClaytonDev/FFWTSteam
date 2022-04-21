using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mouseSensetivity : MonoBehaviour
{
    public Slider slide;
    public Text value;
    void Update()
    {
        PlayerPrefs.SetFloat("Mouse", slide.value);
        value.text = "" + Mathf.Round(slide.value*10)/10;
    }
}
