using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class enemyCount : MonoBehaviour
{
    bool level2;
    bool level1;
    bool gotShotgun;
    public GameObject parent;
    GameObject player;
    LineRenderer rend;
    public GameObject topPart;
    bool foundObj;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<LineRenderer>();
        player = FindObjectOfType<Movement>().gameObject;
        //MOST LIKELY SATURDAYS ON SITE ARE APRIL 18th AND APRIL 25th
        level2 = SceneManager.GetActiveScene().name == "Level2";
        level1 = SceneManager.GetActiveScene().name == "Level1";
        if (level1)
        {
            if (GetComponent<Text>().text == "Enemies Left: 21")
                GetComponent<Text>().text = "Move with WASD";
        }
        else if (level2)
        {
            if (GetComponent<Text>().text == "Enemies Left: 21")
                GetComponent<Text>().text = "Press space to multi-jump";
        }
        else if (SceneManager.GetActiveScene().name == "BossFight")
        {
            if (!parent)
                Destroy(gameObject);
            Destroy(parent);
        }
        else if (FindObjectOfType<portalLevel>())
        {
            Destroy(topPart);
            if (!parent)
                Destroy(gameObject);
            Destroy(parent);
        }
    }
    public void activateTextLevel1()
    {
        GetComponent<Text>().text = "Press F to kick enemies";

    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().enabled = Time.timeScale != 0;
        if (level2)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (!parent)
                    Destroy(gameObject);
                Destroy(parent);
            }
        }
        else if (level1)
        {
            if (!gotShotgun && player.GetComponent<Animator>().GetInteger("WeaponNum") == 6)
            {
                GetComponent<Text>().text = "Press R to inspect";
                if (Input.GetKey(KeyCode.R))
                {
                    gotShotgun = true;
                    GetComponent<Text>().text = "";
                }

            }
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && GetComponent<Text>().text == "Move with WASD")
                GetComponent<Text>().text = "";
            if (Input.GetKey(KeyCode.F) && GetComponent<Text>().text == "Press F to kick enemies")
            {
                if (!parent)
                    Destroy(gameObject);
                Destroy(parent);
            }
        }
        else if (Time.frameCount % 5 == 0)
        {
            float count = (Object.FindObjectsOfType<enemyHealth>().Length);
            
            if (count < 5)
            {
                if (FindObjectOfType<bossObjHealth>())
                    return;
                rend.enabled = true;
                float dist = 500;
                Vector3 pos = new Vector3();
                foreach (enemyHealth e in FindObjectsOfType<enemyHealth>())
                {
                    if (Vector3.Distance(player.transform.position, e.transform.position) < dist)
                    {
                        dist = Vector3.Distance(player.transform.position, e.transform.position);
                        pos = e.transform.position;
                    }
                }
                rend.SetPosition(1, pos);
            }
            else
            {
                rend.enabled = false;
            }
            
            GetComponent<Text>().text = "Enemies Left: " + count;
        }
        bool foundBoss = FindObjectOfType<bossObjHealth>();
        if (foundBoss)
        {
            rend.enabled = false;
        }
        rend.SetPosition(0, player.transform.position - Vector3.up);
    }
}
