using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCannon : MonoBehaviour
{
    public GameObject attachedPlayer;
    float lockTime;
    public Transform target;
    public AudioClip fireSound;
    public AudioClip loadSound;
    bool fire;
    public GameObject text;
    public float rotate;
    public float rotateDiff;
    public GameObject weapons;
    public GameObject leftArm;
    public GameObject rightArm;
    float startRotY;
    Vector3 lastGrav;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Movement>().enabled = false;
        lastGrav = Physics.gravity;
        Physics.gravity = new Vector3();
        GetComponent<AudioSource>().PlayOneShot(loadSound);
        if (other.gameObject.name == "Player")
        {
            attachedPlayer = other.gameObject;
            lockTime = Time.realtimeSinceStartup + 1;
        }
        if (attachedPlayer)
        attachedPlayer.transform.position = transform.position;
        startRotY = transform.localEulerAngles.y;
    }
    private void Start()
    {
        GetComponent<AudioSource>().pitch = 0.5f;
        fire = false;
        Cursor.lockState = CursorLockMode.Locked;
        target.transform.parent = null;
        transform.LookAt(target);
        target.transform.parent = transform;
        target.transform.LookAt(transform);
        startRotY = transform.localEulerAngles.y;
    }
    // Update is called once per frame
    void Update()
    {
        
        target.GetComponent<MeshRenderer>().enabled = false;
        

        if (attachedPlayer)
        {

            if (Vector3.Distance(attachedPlayer.transform.position, target.position) < 15)
            {
                attachedPlayer.GetComponent<Movement>().enabled = true;
                Physics.gravity = lastGrav;
                attachedPlayer = null;
                if (Physics.gravity.y == 0)
                {
                    Physics.gravity = new Vector3(0, -20.81f, 0);
                }
            }
            else
            {
                attachedPlayer.transform.LookAt(target);
                if (lockTime > Time.realtimeSinceStartup + 0.2)
                {

                    attachedPlayer.transform.position = transform.position - (attachedPlayer.transform.forward * 10f * (Time.realtimeSinceStartup - lockTime));
                }
                else if (lockTime < Time.realtimeSinceStartup)
                {
                    if (!fire)
                    {
                        if (rotate != 0)
                        target.GetComponent<MeshRenderer>().enabled = true;
                        Vector3 pos = attachedPlayer.transform.position;
                        pos.y = transform.position.y;
                        attachedPlayer.transform.position = pos;
                        text.SetActive(true);
                        
                    }
                    if (Input.GetKey(KeyCode.Space) && !fire)
                    {
                        GetComponent<AudioSource>().PlayOneShot(fireSound);
                        fire = true;

                    }
                    if (fire)
                    {
                        if (!attachedPlayer.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Cannon"))
                        {
                            attachedPlayer.GetComponent<Animator>().Play("Cannon");
                        }
                        attachedPlayer.transform.position = Vector3.MoveTowards(attachedPlayer.transform.position, target.position, Time.deltaTime * 350) - Physics.gravity * Time.deltaTime;
                        attachedPlayer.transform.Rotate(Mathf.Sin(Time.realtimeSinceStartup) * 10, Mathf.Cos(Time.realtimeSinceStartup) * 10, 0);
                    }
                }
            }
        }
        else
            fire = false;
        if (!attachedPlayer)
        {
            if (!fire)
                text.SetActive(false);
            Vector3 angles = transform.localEulerAngles;
            angles.y = startRotY;
            transform.localEulerAngles = angles;
        }
        if ((attachedPlayer && !fire))
        {
            Vector3 angles = transform.localEulerAngles;
            if (rotateDiff != 0)
            angles.y = startRotY + (Mathf.Sin(Time.realtimeSinceStartup / rotateDiff) * rotate);
            transform.localEulerAngles = angles;

        }

        
    }
}
