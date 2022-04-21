
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour {
    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    public float levelsunlocked;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Awake()
    {
        // 1
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetFloat("level", 1);
            toggle.isOn = true;
            PlayerPrefs.Save();
        }
        // 2
    }
}
