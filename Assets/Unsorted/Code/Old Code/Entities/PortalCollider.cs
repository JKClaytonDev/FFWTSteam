using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalCollider : MonoBehaviour {
    public float buildindex;
    public float levelnum;
    public GameObject player;
    private float teletime;
    GameObject saveData;
	// Use this for initialization
	void Start () {
        teletime = 0;
        saveData = GameObject.FindGameObjectWithTag("SaveData");

    }
	
	// Update is called once per frame
	void Update () {
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetFloat("level", 1);
        }
            
        if (PlayerPrefs.GetFloat("level") < levelnum)
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            transform.localScale = new Vector3(25, 25, 25);
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
            if (Vector3.Distance(player.transform.position, transform.position) < 5)
        {
            if (PlayerPrefs.GetFloat("level") >= levelnum)
            {
                if (PlayerPrefs.GetFloat("level") < levelnum + 1)
                    PlayerPrefs.SetFloat("level", levelnum + 1);
                PlayerPrefs.Save();
                Debug.Log("loading level");
                
                SceneManager.LoadScene("Level" + levelnum);
            }
            else
            {
                Debug.Log("You havent unlocked this level yet go to gate " + PlayerPrefs.GetFloat("level"));
            }
            
        }
            
	}
}
