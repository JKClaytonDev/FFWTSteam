using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadsceneonkill : MonoBehaviour
{
    public GameObject obj;
    
    // Update is called once per frame
    void Update()
    {
     if (!obj)
        {
            SceneManager.LoadScene("HeavyRecoil");
        }   
    }
}
