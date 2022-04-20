using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cutScene : MonoBehaviour
{
    public bool sound;
    public bool loadScene;
    public string scene;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        loadScene = false;
        sound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (loadScene)
        {
            loadScene = false;
            SceneManager.LoadScene(scene);
        }
        if (sound)
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
