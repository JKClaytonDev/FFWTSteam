using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSource : MonoBehaviour
{
    public AudioSource source;
    GameObject Player;
    public AnimationEvent evt;
    void Start()
    {
        evt.functionName = "fireSound";
    }
    public void fireSound()
    {
        if (!Player && FindObjectOfType<Movement>())
            Player = FindObjectOfType<Movement>().gameObject;
        if (!Player)
            return;
        source.PlayOneShot(source.clip, 150/Vector3.Distance(transform.position, Player.transform.position));
    } 
}
