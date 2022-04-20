using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class camMovement : MonoBehaviour
{
    Vector3 lastYPos;
    Vector3 lastPos;
    Quaternion lastRot;
    GameObject player;
    Camera c;
    Rigidbody playerRB;
    Movement playerMovement;
    Animator animCont;
    Camera cam;
    Animator animController;
    // Update is called once per frame
    private void Start()
    {
        animController = player.GetComponent<Animator>();
    }
    void Update()
    {
        if (!cam)
            cam = GetComponent<Camera>();
        
        if (!GetComponent<CameraIntro>().enabled)
        {
            Vector3 target = new Vector3();
            if (Input.GetKey(KeyCode.W))
                target -= 3 * transform.forward/2;
            if (Input.GetKey(KeyCode.A))
                target -= 3*transform.right;
            if (Input.GetKey(KeyCode.S))
                target += 3 * transform.forward/2;
            if (Input.GetKey(KeyCode.D))
                target += 3 * transform.right;
            transform.localRotation = new Quaternion();
            transform.Rotate(15+(15 * (lastRot.x - transform.parent.rotation.x)), 15*(lastRot.y-transform.parent.rotation.y), 15 * (lastRot.z - transform.parent.rotation.z));
           transform.localPosition = Vector3.MoveTowards(new Vector3(), (target-transform.localPosition)/5, 0.2f)/4;
            lastRot = transform.parent.rotation;
            lastPos = transform.parent.position;
            if (!playerRB)
            {
                if (!player)
                    player = FindObjectOfType<Movement>().gameObject;
                if (!player)
                    return;
                playerRB = player.GetComponent<Rigidbody>();
                if (player)
                {
                    playerMovement = player.GetComponent<Movement>();
                    animCont = player.GetComponent<Animator>();
                }
            }
            if (!playerRB)
                return;
            float yV = playerRB.velocity.y;
            if (yV < -10)
                yV = -10;
            float height = Mathf.Max(-15, Mathf.Min(15,  yV / 90));
            if (!animCont)
                return;
            if (animCont.GetInteger("WeaponNum") == 10)
            {
                height = 0;
                GetComponent<Animator>().speed = 0.2f;
            }
            else
            {
                GetComponent<Animator>().speed = 1;
            }
            Vector3 yPos = Vector3.MoveTowards(lastYPos, height * transform.up, 3*Time.deltaTime);
            transform.localPosition += yPos;
            lastYPos = yPos;
            
        }
    }
}
