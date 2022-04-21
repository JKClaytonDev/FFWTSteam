using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class resetInt : MonoBehaviour {
    public Animator clock;  private float startuptime;  private int qualityLevel;
    public bool done;   private bool pressed;
    public bool SlowDownTime;public Camera playerCamera;
    // Use this for initialization
    void Start () {
        done = false;
        pressed = false;
        SlowDownTime = false;
        startuptime = Time.realtimeSinceStartup;
        qualityLevel = QualitySettings.GetQualityLevel();
                if (qualityLevel > 2){

        }
	}

    // Update is called once per frame
    void Update()
    {

        /* 
        if (startuptime + 3 >= Time.realtimeSinceStartup && qualityLevel > 1)
        {
            playerCamera.GetComponent<PostProcessingBehaviour>().profile = startUp;
        }
        else if (SlowDownTime && clock.GetInteger("WeaponNum") == 9)
        {
            playerCamera.usePhysicalProperties = true;
            Time.timeScale = 0.25f;
            playerCamera.clearFlags = CameraClearFlags.SolidColor;
            playerCamera.backgroundColor = Color.red;
            if (QualitySettings.GetQualityLevel() != 0)
            {
                playerCamera.GetComponent<PostProcessingBehaviour>().profile = SlowMo;
            }
        }
        else
        {
            if (QualitySettings.GetQualityLevel() == 0)
            {
                playerCamera.usePhysicalProperties = false;
                playerCamera.clearFlags = CameraClearFlags.SolidColor;
                playerCamera.backgroundColor = Color.blue;
                Time.timeScale = 1.0f;
                playerCamera.GetComponent<PostProcessingBehaviour>().profile = defaultView;
            }
            else
            {
                playerCamera.usePhysicalProperties = false;
                playerCamera.clearFlags = CameraClearFlags.Skybox;
                Time.timeScale = 1.0f;
                if (qualityLevel > 1)
                playerCamera.GetComponent<PostProcessingBehaviour>().profile = defaultView;
            }
            
        }
    }
    void FixedUpdate () {
        playerCamera.fieldOfView = 70;
        if (SlowDownTime)
        {
            playerCamera.usePhysicalProperties = true;
            Time.timeScale = 0.25f;
            playerCamera.clearFlags = CameraClearFlags.SolidColor;
            playerCamera.backgroundColor = Color.red;
        }
        else
        {
            playerCamera.usePhysicalProperties = false;
            playerCamera.clearFlags = CameraClearFlags.Skybox;
            Time.timeScale = 1.0f;
        }
            

        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        if (Input.GetKey("f"))
        {
            if (!pressed) {
            if (clock.GetInteger("WeaponNum") != 9)
            clock.SetInteger("WeaponNum", 9);
                else
                {
                    clock.SetInteger("WeaponNum", 0);
                    SlowDownTime = false;
                    clock.enabled = false;
                    clock.enabled = true;
                }
            

            done = false;
            }
            pressed = true;
        }
        else
            pressed = false;

        if (done)
        {
            clock.SetInteger("WeaponNum", 0);
            done = false;
        }
        */

    }
}
