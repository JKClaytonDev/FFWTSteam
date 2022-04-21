using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapCutscene : MonoBehaviour
{
    public GameObject enable;
    public GameObject disable;
    // Start is called before the first frame update
    void Start()
    {
        enable.SetActive(true);
        disable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
