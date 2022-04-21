using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour
{
    public Vector2[] resolutions;
    public float changeTime;

    public void changeQualityLevel(int level)
    {
        if (Time.realtimeSinceStartup > changeTime + 0.5f)
        {
            Vector2 currentRes = new Vector2(Screen.width, Screen.height);
            int resDigit = 0;
            float resDist = 500000;
            for (int i = 0; i<resolutions.Length; i++)
            {
                Vector2 v = resolutions[i];
                if (Vector2.Distance(currentRes, v) < resDist)
                {
                    resDigit = i;
                    resDist = Vector2.Distance(currentRes, v);
                }
            }
            Screen.SetResolution((int)resolutions[resDigit+level].x, (int)resolutions[resDigit + level].y, true);
            changeTime = Time.realtimeSinceStartup;
        }
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = Screen.width + " X " + Screen.height;
        
    }
}
