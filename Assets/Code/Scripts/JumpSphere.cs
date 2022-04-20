using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JumpSphere : MonoBehaviour
{

    public AudioSource saurs;
    public float boost = 1;
    public GameObject[] children;
    public AudioClip clip;
    float time;
    float oldY;
    bool dead;
    Vector3 oldPos;
    Vector3 startPos;
    GameObject player;
    GameObject realPlayer;
    float distance;
    float posTime = 0;
    Vector3 defaultScale;
    float speed = 55;
    float Falldistance = 30;
    bool reachedPos;
    void Start()
    {
        reachedPos = false;
        startPos = transform.position;
        oldY = transform.position.y;
        oldPos = transform.position;
        time = -10;
        dead = false;
        defaultScale = transform.localScale;
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Movement>() != null)
        {


                saurs.pitch = Random.Range(0.6f, 1.4f);
            saurs.Play();
            transform.position += new Vector3(900, 900, 900);
            time = Time.realtimeSinceStartup + 6;
            dead = true;
            Color color = GameObject.Find("ScreenFlash").GetComponent<Image>().color;
            color = Color.blue;
            color.a = 0.5f;
            GameObject.Find("ScreenFlash").GetComponent<Image>().color = color;
            collision.gameObject.GetComponent<Movement>().jumps = 0;
            Vector3 vel = collision.gameObject.GetComponent<Rigidbody>().velocity;
            vel.y = 25*boost;
            collision.gameObject.GetComponent<Rigidbody>().velocity = vel;
            collision.gameObject.GetComponent<AudioSource>().PlayOneShot(clip, 1);
            
            
        }
    }
    void Update()
    {

            transform.localScale = defaultScale;
            if (dead)
            {
                if (Time.realtimeSinceStartup > time)
                {
                    transform.position = oldPos;
                }
            }

        
        
    }
}
