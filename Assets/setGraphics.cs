using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setGraphics : MonoBehaviour
{
    public int quality;

    void OnMouseOver()
    {
        Debug.Log("PRESSED!");
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("PRESSED!");
            QualitySettings.SetQualityLevel(quality);
        }
    }
    void OnMouseEnter()
    {
        Debug.Log("PRESSED!");
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("PRESSED!");
            QualitySettings.SetQualityLevel(quality);
        }
    }
    public void setQuality(int quality)
    {
        Debug.Log("PRESSED!");
        QualitySettings.SetQualityLevel(quality);

    }
}
