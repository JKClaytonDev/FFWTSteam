using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bossObjHealth : MonoBehaviour
{
    public GameObject[] enemies;
    public enemyHealth health;
    public string customTitle = "Boss";
    public GameObject setActiveafterLowHealth;
    // Update is called once per frame
    void Update()
    {
        
        if (health)
        {

            GetComponent<Text>().text = customTitle+" Health: " + Mathf.RoundToInt(health.Currenthealth/health.startingHealth * 100) + "%";
            if (FindObjectOfType<enemyCount>())
                FindObjectOfType<enemyCount>().enabled = false;
            FindObjectOfType<enemyCount>().gameObject.GetComponent<Text>().text = "";
            FindObjectOfType<enemyCount>().transform.parent.gameObject.SetActive(false);
            return;
        }
        float count = enemies.Length;
        foreach (GameObject g in enemies)
        {
            
            if (!g)
                count -= 1;
        }
        GetComponent<Text>().text = customTitle+" Health: " + (count / enemies.Length) * 100 + "%";
        if (setActiveafterLowHealth)
        setActiveafterLowHealth.SetActive((count / enemies.Length) < 40);
        if (count == 0)
            GetComponent<Text>().text = "";
    }
}
