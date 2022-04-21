using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class videoPlayer : MonoBehaviour
{
    bool hasplayed;
    public GameObject texture;
    public GameObject[] enableNow;
    public videoPlayer v;
    public bool loadCredits;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject g in enableNow)
            g.SetActive(false);
        texture.SetActive(true);
        Time.timeScale = 1;
        hasplayed = false;
    }
   void Update()
    {
        if (GetComponent<VideoPlayer>().isPlaying)
        {
            
            hasplayed = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) || (!GetComponent<VideoPlayer>().isPlaying && hasplayed))
        {
            if (loadCredits)
                SceneManager.LoadScene("Credits");
            foreach (GameObject g in enableNow)
                g.SetActive(true);
            texture.SetActive(false);
            Time.timeScale = 1;
            GetComponent<VideoPlayer>().enabled = false;
            
            this.enabled = false;
        }
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

}
