using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeSound : MonoBehaviour
{
    public AudioClip[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
    }
}
