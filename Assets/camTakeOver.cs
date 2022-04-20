using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTakeOver : MonoBehaviour
{
    public GameObject playercamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!playercamera)
        {
            Camera[] cams = FindObjectsOfType<Camera>();
            foreach (Camera c in cams)
            {
                if (c.gameObject.name == "PlayerCamera")
                    playercamera = c.gameObject;
                playercamera.GetComponent<Camera>().enabled = false;
            }

        }
        if (!playercamera)
            playercamera = GameObject.Find("PlayerCamera");
        if (playercamera)
        {
            transform.position = playercamera.transform.position;
            transform.rotation = playercamera.transform.rotation;
        }
    }
}
