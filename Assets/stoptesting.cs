using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class stoptesting : MonoBehaviour
{
    public GameObject[] activate;
    public bool[] active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.T))
        {
           for (int i = 0; i<activate.Length; i++)
            {
                activate[i].SetActive(active[i]);
            }
        }   
    }
}
