using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class flashLight : MonoBehaviour
{
    public Vector3 offset;
    // Update is called once per frame
    void Start()
    {
        Destroy(gameObject);
        if (SceneManager.GetActiveScene().name == "Level111")
            Destroy(this.gameObject);
    }
    void Update()
    {
        transform.position = GameObject.Find("Player").transform.position;// + transform.up;
        transform.rotation = GameObject.Find("Player").transform.rotation;
        transform.Rotate(offset);
    }
}
