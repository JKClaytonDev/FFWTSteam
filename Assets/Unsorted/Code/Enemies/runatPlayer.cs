using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runatPlayer : MonoBehaviour {
    Vector3 start; public AudioClip[] robotActivatedSounds;
    float calculateTime; bool activated;    public float extraRange;
    public float health; public float extraSpeed; public float extraSize;
    public bool StandStill; public bool unlockedLocalScale; public Vector3 extraRot;
    public bool noCalculateTime;    Vector3 target; public GameObject player;
    bool dinoactivated; public bool dontmovetilactivated;   public bool dontUseRaycast;
    RaycastHit hit; Vector3 lastMove; Vector3 landtarget;   float Ystart;   public bool canFallOff;
    public bool greenRobot;
    
    Vector3 randomTarget;
	// Use this for initialization
	void Start () {
        if (name.Contains("Runner"))
        {
            GetComponent<Animator>().enabled = true;
        }
        Ystart = transform.position.y;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit))
            transform.position = hit.point;
        if (GetComponent<BoxCollider>())
            transform.position += transform.up * ((GetComponent<BoxCollider>().size.y / 2)-GetComponent<BoxCollider>().center.y);
        if (GetComponent<RobotMoving>())
        {
            if (GetComponent<RobotMoving>().enabled == false)
                GetComponent<RobotMoving>().enabled = true;
            GetComponent<RobotMoving>().dontMove = true;
        }
        dinoactivated = false;
        start = transform.position;
        health = 7;
        target = transform.position;
        if (player == null)
            player = GameObject.Find("Player");
        if (player != null)
            target = player.transform.position;
        if (GameObject.Find("PlayerSpawn"))
            target = GameObject.Find("PlayerSpawn").transform.position;
        activated = false;
        if (!unlockedLocalScale)
        transform.localScale = player.transform.localScale * 0.8f * (extraSize + 1);
        if (GameObject.Find("Player") != null)
            player = GameObject.Find("Player");
        if (!dontUseRaycast && dontUseRaycast)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, Vector3.down, out hit);
            start = hit.transform.position;
            transform.position = start + (Vector3.up * GetComponent<BoxCollider>().size.y);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y + 150 < Ystart)
            Destroy(gameObject);
        if (player == null && FindObjectOfType<Movement>())
            player = FindObjectOfType<Movement>().gameObject;
        if (player == null && GameObject.Find("Player"))
            player = GameObject.Find("Player");
        Vector3 pos = transform.position;
        if (player)
        pos = player.transform.position;
        pos.y = transform.position.y;
        //Debug.Log("Distance " + (Vector3.Distance(transform.position, pos)));
        if (!StandStill)
        {
            if (canFallOff)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, -20, GetComponent<Rigidbody>().velocity.y);
            }
            if (Mathf.Abs(start.y - transform.position.y) > 25)
            {
                if (Vector3.Distance(transform.position, player.transform.position) < 30)
                    Destroy(this.gameObject);
                transform.position = start;
                if (GetComponent<RobotMoving>())
                    if (GetComponent<RobotMoving>().dontMove == true)
                    {
                        GetComponent<RobotMoving>().dontMove = false;
                        GetComponent<runatPlayer>().enabled = false;
                    }
                
            }

                if (Vector3.Distance(transform.position, pos) < 25 + extraRange)
                {
                dinoactivated = true;
                if (noCalculateTime || calculateTime < 1)
                    {
                        
                        target = pos;
                        if (!activated)
                        {
                            GetComponent<AudioSource>().clip = robotActivatedSounds[Random.Range(0, robotActivatedSounds.Length)];
                            GetComponent<AudioSource>().pitch = 0.8f;
                            GetComponent<AudioSource>().enabled = false;
                            GetComponent<AudioSource>().enabled = true;
                            GetComponent<AudioSource>().Play();
                            activated = true;
                        }
                        calculateTime = 60;
                    transform.LookAt(target);
                    transform.Rotate(0, 180, 0);
                    transform.Rotate(extraRot);
                        
                    }
                Vector3 vel = new Vector3();
                GetComponent<Rigidbody>().velocity = (Vector3.MoveTowards(transform.position, target, 25 * extraSpeed))-transform.position;
                vel.x = GetComponent<Rigidbody>().velocity.x;
                vel.z = GetComponent<Rigidbody>().velocity.z;
                GetComponent<Rigidbody>().velocity = vel;
                }
                else if ((!noCalculateTime || !dontmovetilactivated) && !canFallOff)
                {
                    transform.LookAt(randomTarget);
                transform.Rotate(0, 180, 0);
                transform.Rotate(extraRot);
                    transform.position = Vector3.MoveTowards(transform.position, randomTarget, Time.deltaTime * 60);
                    
                    if (Time.frameCount%240 == 0 || Vector3.Distance(transform.position, randomTarget) < 3)
                    {
                    randomTarget = new Vector3(start.x + (Random.insideUnitCircle * 60).x, transform.position.y, start.z + (Random.insideUnitCircle * 60).y);           
                    }
                    
                }

        }
        
        calculateTime--;
        Vector3 eu = transform.localEulerAngles;
        eu.z = 0;
        eu.x = 0;
        transform.localEulerAngles = eu;
    }
    

}
