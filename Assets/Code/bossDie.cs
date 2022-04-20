using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bossDie : MonoBehaviour
{
    public GameObject text;
    bool lastHeal;
    public bool heal;
    public GameObject head;
    public GameObject[] disable;
    public GameObject enable;
    float EndTime;
    public AudioClip dieSound;
    // Update is called once per frame

    void Update()
    {
        if (head.GetComponent<enemyHealth>().Currenthealth == 500)
            head.GetComponent<enemyHealth>().Currenthealth = 120;
        else if (heal != lastHeal)
        {
            heal = lastHeal;
            if (head.GetComponent<enemyHealth>().Currenthealth+5 < head.GetComponent<enemyHealth>().startingHealth)
            head.GetComponent<enemyHealth>().Currenthealth += 5;
        }
        
        lastHeal = heal;
        if ((head.GetComponent<enemyHealth>().Currenthealth < 10 || (head.GetComponent<enemyHealth>().Currenthealth == 500)) && EndTime == 0)
        {
            text.SetActive(false);
            foreach (GameObject g in disable)
                g.SetActive(false);
            enable.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(dieSound);
            EndTime = Time.realtimeSinceStartup + 5;
        }
        if (EndTime != 0 && Time.realtimeSinceStartup > EndTime)
        {
            PlayerPrefs.SetFloat("Completed", 1);
            SceneManager.LoadScene("PreCredits");
                EndTime = 0;
        }

    }
}
