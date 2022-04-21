using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class forceRenderer : MonoBehaviour {
    public float ForceTime;
    private float lastChecked;
    public GameObject[] sprites;
    private GameObject picked;
	// Use this for initialization
	void Start () {
        lastChecked = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (ForceTime > Time.realtimeSinceStartup)
        {
            GetComponent<AudioSource>().volume = 1;
            GetComponent<Image>().enabled = true;
            if (lastChecked + 0.01f < Time.realtimeSinceStartup)
            {
                foreach (GameObject obj in sprites)
                {
                    obj.SetActive(false);
                }
                sprites[Random.Range(0, sprites.Length)].SetActive(true);
                lastChecked = Time.realtimeSinceStartup;
            }

        }
        else
        {
            GetComponent<AudioSource>().volume /= 1.2f;
            GetComponent<Image>().enabled = false;
            foreach (GameObject obj in sprites)
            {
                    obj.SetActive(false);
            }
        }
	}
}
