using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ArmsAnimation : MonoBehaviour
{
    public Animator anim;
    float dropTime;
    AnimationEvent enableLeft;
    AnimationEvent disableLeft;
    AnimationEvent swap;
    AnimationEvent evt;
    public GameObject handbullet;
    public GameObject bullet;
    public GameObject wall;
    public GameObject player;
    public GameObject targetObj;
    Vector3 objTargetPos;
    RaycastHit storeHit;
    public PlayerrMovement playerMovmt;
    AnimationEvent allowJump;
    AnimationEvent disableJump;
    public bool canJump;
    bool found;
    EnemyAnimator nearestEnemy;
    public GameObject vertical;
    // Start is called before the first frame update
    void Start()
    {
        found = false;
        canJump = true;
        anim = GetComponent<Animator>();
        
        disableLeft = new AnimationEvent();
        swap = new AnimationEvent();
        swap.functionName = "SwapHands";
        disableLeft.functionName = "DisableLeft";
        allowJump.functionName = "AllowJump";
        disableJump.functionName = "DisableJump";
        evt = new AnimationEvent();
        evt.functionName = "Fire";
        targetObj = new GameObject();
        targetObj.AddComponent<Animator>();
        enableLeft = new AnimationEvent();
        enableLeft.functionName = "EnableLeft";
    }
    public void SwapHands()
    {
        Vector3 scale = vertical.transform.localScale;
        scale.x *= -1;
        vertical.transform.localScale = scale;
    }
    public void AllowJump()
    {
        canJump = true;
    }
    public void DisableJump()
    {
        canJump = false;
    }
    public void EnableLeft()
    {
        GetComponent<Animator>().SetLayerWeight(1, 1);
    }
    public void DisableLeft()
    {
        GetComponent<Animator>().SetLayerWeight(1, 0);
    }
    public void Fire()
    {
        GameObject b = Instantiate(bullet);
        b.transform.parent = null;
        b.transform.position = handbullet.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Pointing", false);
        if (Input.GetKeyDown(KeyCode.B) || Time.realtimeSinceStartup > 0.5f && Time.realtimeSinceStartup < 5)
        {
            anim.Play("CloseCall", 0);
            anim.Play("CloseCall", 1);
            anim.Play("CloseCall", 2);
        }
        if (Input.GetMouseButton(1))
        {
            if (!nearestEnemy)
            {
                EnemyAnimator[] enemiesInRange = FindObjectsOfType<EnemyAnimator>();
                float bestAngle = -1f;
                foreach (EnemyAnimator enemy in enemiesInRange)
                {
                    Vector3 vectorToEnemy = enemy.transform.position - transform.position;
                    vectorToEnemy.Normalize();
                    float angleToEnemy = Vector3.Dot(transform.forward, vectorToEnemy);
                    if (angleToEnemy > bestAngle)
                    {
                        RaycastHit hitt;
                        Physics.Raycast(transform.position, transform.forward, out hitt);
                        if (hitt.collider.gameObject.layer == 9 || Input.GetKey(KeyCode.Tab)){
                            nearestEnemy = enemy;
                            bestAngle = angleToEnemy;
                        }
                    }
                }
            }
            
            if (nearestEnemy)
            {
                anim.SetBool("Pointing", true);
                anim.Play("Point", 1);
                playerMovmt.gameObject.transform.LookAt(nearestEnemy.gameObject.transform);
                Quaternion rot = playerMovmt.transform.rotation;
                rot.x = 0;
                rot.z = 0;
                playerMovmt.transform.rotation = rot;
                transform.LookAt(nearestEnemy.gameObject.transform);

            }
        }
        else
            nearestEnemy = null;
        anim.SetBool("OnGround", playerMovmt.onGround);
        anim.SetBool("Running", Input.GetKey(KeyCode.LeftShift) && playerMovmt.onGround);
        if (Input.GetMouseButtonDown(0) && playerMovmt.onGround)
        {
            anim.Play("FireBall");
            
        }
        if (Input.GetKeyDown(KeyCode.F) && playerMovmt.onGround)
        {
            
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit);
            if (hit.transform.gameObject.GetComponent<wallRaise>())
            {
                anim.Play("CloseWall");
                hit.transform.gameObject.GetComponent<wallRaise>().closeWall = true;
            }
            else
            {
                anim.Play("RaiseWall");
                GameObject g = Instantiate(wall);
                g.transform.position = player.transform.position + player.transform.forward * 15;
                g.transform.rotation = player.transform.rotation;
            }

        }
        
        if (Input.GetKeyDown(KeyCode.G) && playerMovmt.onGround)
        {
            Debug.Log("PRESSED G");
            if (targetObj != null)
            {
                Debug.Log(targetObj.name + "I CHOKED THIS GUY COME CHECK HIM OUT SOMETIME");
                if (targetObj.GetComponent<Animator>())
                {
                    targetObj.GetComponent<Animator>().SetBool("Choking", false);
                    targetObj.GetComponent<Animator>().SetLayerWeight(2, 0);
                    dropTime = Time.realtimeSinceStartup + 3;
                    targetObj = null;
                    anim.SetBool("Lift", false);
                    return;
                }
                else if (targetObj.GetComponent<runatplayer>())
                {
                    if (targetObj.GetComponent<NavMeshAgent>())
                        targetObj.GetComponent<NavMeshAgent>().enabled = false;
                    targetObj.GetComponent<runatplayer>().enabled = true;
                    targetObj.GetComponent<runatplayer>().parent.GetComponent<Animator>().SetBool("Choking", false);
                    targetObj.GetComponent<runatplayer>().parent.GetComponent<Animator>().SetLayerWeight(2, 0);
                    dropTime = Time.realtimeSinceStartup + 3;
                    targetObj = null;
                    anim.SetBool("Lift", false);
                    return;
                }
            }
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit);
            if (!hit.collider.GetComponent<PlayerMovement>() && (hit.collider.gameObject.GetComponent<Animator>() || hit.collider.gameObject.GetComponent<runatplayer>()))
            {
                if (hit.collider.gameObject.GetComponent<Animator>())
                {
                    hit.collider.gameObject.GetComponent<Animator>().SetBool("Choking", true);
                    hit.collider.gameObject.GetComponent<Animator>().Play("Choke");
                    hit.collider.gameObject.GetComponent<Animator>().SetLayerWeight(2, 0);
                }
                else if (hit.collider.gameObject.GetComponent<runatplayer>())
                {
                    hit.collider.gameObject.GetComponent<runatplayer>().enabled = false;
                    if (hit.collider.gameObject.GetComponent<NavMeshAgent>())
                        hit.collider.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    hit.collider.gameObject.GetComponent<runatplayer>().parent.GetComponent<Animator>().SetBool("Choking", true);
                    hit.collider.gameObject.GetComponent<runatplayer>().parent.GetComponent<Animator>().Play("Choke");
                    hit.collider.gameObject.GetComponent<runatplayer>().parent.GetComponent<Animator>().SetLayerWeight(2, 0);
                }

                Debug.Log("FOUND RB " + hit.collider.gameObject.name);
                if (hit.collider.gameObject == targetObj)
                    return;
                dropTime = Time.realtimeSinceStartup + 2;
                targetObj = hit.collider.gameObject;
                objTargetPos = targetObj.transform.position + Vector3.up * 15;
                
                anim.SetBool("Lift", !anim.GetBool("Lift"));
                if (anim.GetBool("Lift"))
                {
                    anim.Play("GravityLift", 1);
                }
            }
            else
                anim.SetBool("Lift", false);
        }
    }
}
