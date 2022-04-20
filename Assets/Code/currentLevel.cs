using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class currentLevel : MonoBehaviour {
    public GameObject newGame;
    public GameObject continueGame;
    public string level1;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetString("LevelName") == null)
        {
            PlayerPrefs.SetString("LevelName", level1);
            newGame.GetComponent<RectTransform>().position = continueGame.GetComponent<RectTransform>().position;
            continueGame.GetComponent<RectTransform>().position = new Vector3(9000, 9000);
        }
        else if (PlayerPrefs.GetString("LevelName") == level1)
        {
            newGame.GetComponent<RectTransform>().position = continueGame.GetComponent<RectTransform>().position;
            continueGame.GetComponent<RectTransform>().position = new Vector3(9000, 9000);
        }
        GetComponent<Text>().text = PlayerPrefs.GetString("LevelName");
    }
	
	// Update is called once per frame
	void Update () {

	}
}
