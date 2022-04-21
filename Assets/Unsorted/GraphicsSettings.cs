using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GraphicsSettings : MonoBehaviour
{
    public float changeTime;

    public void changeQualityLevel(int level)
    {
        if (Time.realtimeSinceStartup > changeTime + 0.5f) {
            QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel() + level);
        changeTime = Time.realtimeSinceStartup;
    }
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = QualitySettings.names[QualitySettings.GetQualityLevel()];
    }
}
