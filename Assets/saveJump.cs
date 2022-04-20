using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class saveJump : MonoBehaviour
{
    bool use = false;
    float jumpTime;
    public Movement player;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
            Destroy(gameObject);
    }
    void Update()
    {
        if (player.jumps == 0 || Time.realtimeSinceStartup > jumpTime+9)
            use = false;
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("WALLJUMP");
        if (!use && player.jumps != 0 && Input.GetKey(KeyCode.Space))
        {
            Color color = GameObject.Find("ScreenFlash").GetComponent<Image>().color;
            color = Color.blue;
            color.a = 0.05f;
            GameObject.Find("ScreenFlash").GetComponent<Image>().color = color;
            player.jumps = 1;
            if (!Physics.Raycast(transform.position, Vector3.up) && !Physics.Raycast(transform.position, Vector3.down))
            player.transform.position += transform.up * 15;
            use = true;
            jumpTime = Time.realtimeSinceStartup;
        }
    }
}
