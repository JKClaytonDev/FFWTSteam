using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableOnTrigger : MonoBehaviour
{
    public GameObject[] enable;
    public Component[] enableO;
    public bool keepmeAlive;
    public bool disableBoth;
    public GameObject disable;
    public AudioClip clip;
    public bool destroy = true;
    void Start()
    {

        this.GetComponent<MeshRenderer>().enabled = false;
        foreach (MonoBehaviour g in enableO)
            g.enabled = false;
        if (disableBoth)
        {
            foreach (GameObject g in enable)
                g.SetActive(false);
        }
           
    }
    void OnTriggerEnter(Collider other)
    {
        if (clip)
            GetComponent<AudioSource>().PlayOneShot(clip);
        if (disable)
            Destroy(disable);
        Debug.Log("TRIGGERED!!!");
        if (transform.position.x == 146.3f)
        {
            enemyCount[] g = FindObjectsOfType<enemyCount>();
            foreach (enemyCount f in g)
            f.activateTextLevel1();
        }
        Debug.Log("asdf");
        if (keepmeAlive)
        {
            foreach (GameObject g in enable)
            {
                g.SetActive(true);
            }
        }
       
        foreach (MonoBehaviour g in enableO)
        {
            g.enabled = true;
            if (destroy)
            Destroy(g.gameObject, 15);
        }
        if (!keepmeAlive)
        Destroy(this.gameObject);
    }
}
