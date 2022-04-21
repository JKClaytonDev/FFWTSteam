using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GreatArcStudios;

public class Essentials : MonoBehaviour {
    public GameObject loadLevel;
    public GameObject pauseMenu;
    public GameObject prefab;
    public GameObject playerCamera;
    public GameObject instantiator;
    public GameObject player;
    public GameObject ultraGraphics;
    public int GraphicsTiersGreater;
 // properties of class


    // Use this for initialization
    void Start() {

        //Instantiate(prefab);
        //Destroy(gameObject);
        GameObject.Find("Pause Menu Manager").GetComponent<PauseManager>().mainCam = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        GameObject.Find("Pause Menu Manager").GetComponent<PauseManager>().mainCamObj = GameObject.Find("PlayerCamera");
        pauseMenu.transform.parent = null;
    }
    void OnEnable()
    {
        if (GameObject.Find("LoadLevel") == null)
        {
            //GameObject.Instantiate(loadLevel);
            playerCamera.GetComponent<CameraIntro>().enabled = false;
            playerCamera.GetComponent<CameraIntro>().enabled = true;

        }
    }

}
