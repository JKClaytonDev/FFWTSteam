using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bossHealth : MonoBehaviour
{
    public GameObject text;


    // Update is called once per frame
    void Update()
    {
        text.GetComponent<Text>().text = (Mathf.Round(GetComponent<enemyHealth>().Currenthealth) + "/" + Mathf.Round(GetComponent<enemyHealth>().startingHealth));
    }
}
