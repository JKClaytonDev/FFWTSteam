using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class runatplayer : MonoBehaviour
{
    public GameObject player;
    public GameObject parent;
    public Vector3 rotOffset;
    public Vector3 offset;
    public EnemyAnimator anim;
    float setTime;
    public bool foundPlayer;
    
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Camera>().gameObject;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("START " + Mathf.Round(Time.realtimeSinceStartup) % 2);

        if (Time.realtimeSinceStartup > setTime && Mathf.Round(Time.realtimeSinceStartup) % 2 == 0)
        {
            setTime = Time.realtimeSinceStartup + Random.Range(1, 3);
            Debug.Log("TIME");
            RaycastHit hit;
            Physics.Raycast(player.transform.position, Vector3.MoveTowards(player.transform.position, transform.position, 1) - player.transform.position, out hit);
            Debug.Log(hit.transform.gameObject);
            if (hit.transform.gameObject == gameObject)
            {
                agent.stoppingDistance = 1;
                agent.speed = 30;
                agent.destination = player.transform.position;
                anim.seePlayer = false;
                Debug.Log("FOUND PLAYER");
                foundPlayer = true;
            }
            else
            {
                foundPlayer = false;
                agent.speed = 20;
                anim.seePlayer = false;
                Quaternion lastRot = transform.rotation;
                transform.Rotate(0, Random.Range(0, 360), 0);
                Physics.Raycast(transform.position, transform.forward, out hit);
                agent.destination = Vector3.MoveTowards(hit.point, transform.position, Vector3.Distance(hit.point, transform.position) / 3);
            }
            Debug.Log("HIT OBJECT");
            Debug.Log("SCRIPT COMPLETE");
        }
        
        
        parent.transform.position = transform.position + offset;
        transform.localPosition = new Vector3();
        parent.transform.rotation = transform.rotation;
        parent.transform.Rotate(rotOffset);
        transform.localRotation = new Quaternion();
        transform.Rotate(-rotOffset);
    }
}
