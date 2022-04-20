using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class myAchievements : MonoBehaviour {
    public string[] achievements;
    public string[] descriptions;
    // Use this for initialization
    public void Reset()
    {
        foreach (string str in achievements)
        {
            if (Random.Range(0, 10) > 5)
                PlayerPrefs.SetInt(str,1) ;
            else
                PlayerPrefs.SetInt(str, 0);
        }
    }
    void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {
        string text = "";
        int num = 0;
        foreach (string str in achievements)
        {
            if (PlayerPrefs.GetInt(str) == 1)
            {
                text += str + ": \n\t" + descriptions[num] + "\n\n";
            }
            num++;
        }
        GetComponent<Text>().text = text;
    }
}
