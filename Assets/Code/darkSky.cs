using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darkSky : MonoBehaviour
{
    public GameObject[] enabledOnStart;
    public GameObject[] enabledOnEnd;
    float startupTime;
    public Material tobeSwitched;
    public Material toReplace;
    // Start is called before the first frame update
    void Start()
    {
        startupTime = Time.realtimeSinceStartup;
        foreach (GameObject g in enabledOnStart)
            g.SetActive(true);
        foreach (GameObject g in enabledOnEnd)
            g.SetActive(false);
    }
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Movement>().enemyCount < 1 && startupTime + 3 < Time.realtimeSinceStartup)
        {
            Swap();
        }
    }
    void Swap()
    {
        foreach (GameObject g in enabledOnStart)
            g.SetActive(false);
        foreach (GameObject g in enabledOnEnd)
            g.SetActive(true);
        this.enabled = false;
    }
}
