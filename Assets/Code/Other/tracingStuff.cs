using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracingStuff : MonoBehaviour {
    // Use this for initialization
    public Material mat;
    public int qualityLevel;
    void Start()
    {
        if (qualityLevel == 0 || qualityLevel == 1)
        {
            qualityLevel = QualitySettings.GetQualityLevel();
            GameObject[] imStuff = FindObjectsOfType(typeof(GameObject)) as GameObject[];
            foreach (GameObject item in imStuff)
            {


                if (item.GetComponent<ParticleSystem>())
                    Destroy(item.GetComponent<ParticleSystem>());
                if (item.GetComponent<ReflectionProbe>())
                    Destroy(item.GetComponent<ReflectionProbe>());


            }
        }
        Destroy(GetComponent<tracingStuff>());
    }
  

}
