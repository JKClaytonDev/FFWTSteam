using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitGamMode : MonoBehaviour
{
    public int set;
    int lastSet;
    public GameObject spawn;
    public GameObject essentials;
    // Start is called before the first frame update
    void Start()
    {
        lastSet = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f"))
            GetComponent<Animator>().Play("GameBoyOutro");
        if (lastSet != set)
        {
            lastSet = set;
            SwapWithPlayer();
        }
    }

    public void SwapWithPlayer()
    {
        transform.position = GameObject.Find("LeftArm").transform.position;
        Destroy(GameObject.Find("Map"));
        GameObject news = essentials;
        news.GetComponent<Essentials>().player.GetComponent<Movement>().Intro = true;
        news.name = "Lol";
        GameObject s = Instantiate(news);
        this.enabled = false;
    }
}
