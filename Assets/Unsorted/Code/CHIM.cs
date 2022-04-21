using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CHIM : MonoBehaviour
{
    public AudioClip sound;
    bool c;
    bool h;
    bool i;
    bool m;
    // Start is called before the first frame update
    void Start()
    {
        c = false;
        h = false;
        i = false;
        m = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!c && !h && !i && !m)
            c = true;
            else
            {
                c = false;
                h = false;
                i = false;
                m = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (c && !h && !i && !m)
            {
                h = true;
                GetComponent<AudioSource>().PlayOneShot(sound);
            }
            else
            {
                c = false;
                h = false;
                i = false;
                m = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (c && h && !i && !m) {
                i = true;
                GetComponent<AudioSource>().PlayOneShot(sound);
            }
            else
            {
                c = false;
                h = false;
                i = false;
                m = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (c && h && i && !m)
            {
                m = true;
                GetComponent<AudioSource>().PlayOneShot(sound);
            }
            else
            {
                c = false;
                h = false;
                i = false;
                m = false;
            }
        }

        if (c && h && i && m)
            SceneManager.LoadScene("DogRoom");
    }
}
