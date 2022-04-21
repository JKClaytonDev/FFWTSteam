using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class disableGameObjects : MonoBehaviour {
    public GameObject[] objects;
    public GameObject slider;
    public GameObject text;
    public string lastScene;
    public float lastTime;
    float loadTime;
    float yPos;

    /*
    // Use this for initialization
    void Start() {
        if (SceneManager.GetActiveScene().name == lastScene)
        {
            foreach (GameObject obj in objects)
            {
                if (obj != null)
                    obj.SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        RectTransform mrect = GetComponent<RectTransform>();
        Vector2 apos = mrect.anchoredPosition;
        float xpos = apos.x;
        xpos = Mathf.Clamp(xpos, 0, Screen.width - mrect.sizeDelta.x);
        apos.x = xpos;
        mrect.anchoredPosition = apos;
	}
    */

}
