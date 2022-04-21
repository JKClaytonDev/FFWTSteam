using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingLegs : MonoBehaviour
{
    private float health; private float landed; public Rigidbody boss;  public AudioSource explodeSound;
    public GameObject legEnd; private Material normalMat; public Material damageMat;   
    private GameObject player; float coolofftime; Quaternion defaultRotate; private Rigidbody explode; private GameObject explosion;
    // Use this for initialization
    /*
    void Start()
    {
        defaultRotate = transform.rotation;
        landed = 1;
        coolofftime = 0;
        normalMat = legEnd.GetComponent<MeshRenderer>().material;
        player = GameObject.FindGameObjectWithTag("Player");
        explode = (GameObject.FindGameObjectWithTag("explosion")).GetComponent<Rigidbody>();
        explosion = GameObject.FindGameObjectWithTag("explosion");
        //boss = GameObject.FindGameObjectWithTag("Boss");
        health = 100;
        boss.constraints = RigidbodyConstraints.None;
    }


    // Update is called once per frame
    void Update()
    {
        boss.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        if (Mathf.Abs(transform.rotation.z) > 20)
        {
            Quaternion rot = transform.rotation;
            rot.z /= 2;
            transform.rotation = rot;
        }
        if (landed == 1)
        {
            legEnd.GetComponent<MeshRenderer>().material = normalMat;

            transform.position = boss.transform.position;
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            
            foreach (GameObject target in bullets)
            {
                float distance = Vector3.Distance(target.transform.position, legEnd.transform.position);
                if (distance < 3 && distance != 0 && Time.realtimeSinceStartup > 5)
                {
                    explode.GetComponent<MeshRenderer>().enabled = true;
                    explodeSound.Play();
                    
                    explode.AddExplosionForce(10, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), 20);
                    for (float j = 1; j < 10; j++)
                    {
                        Object Explodey = GameObject.Instantiate(explosion, new Vector3(legEnd.transform.position.x + Random.Range(-2, 2), legEnd.transform.position.y + Random.Range(-2, 2), legEnd.transform.position.z + Random.Range(-2, 2)), legEnd.transform.rotation);
                        Destroy(Explodey, 1);
                    }

                    Debug.Log("Hit! " + health);
                    coolofftime = Time.realtimeSinceStartup + 1;
                    health -= 55;
                    legEnd.GetComponent<MeshRenderer>().material = damageMat;
                    boss.velocity = new Vector3(0, 20, 0);
                    boss.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                    landed = 0;
                }
            }
        }
        if (health < 0)
        {
            
            Destroy(gameObject);
        }
        if (landed == 0 && boss.velocity.y < 0)
        {
            
            boss.transform.rotation = defaultRotate;
            landed = -1;
        }
            
        if (landed == -1 && boss.velocity.y >= 0)
        {
            Debug.Log("landed");
            boss.velocity /= 100;
            boss.constraints = RigidbodyConstraints.None;
            landed = 1;
        }
        if (transform.position.y < 9)
        {
            boss.transform.position = new Vector3(boss.transform.position.x, 40, boss.transform.position.z);
                boss.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }


        
    }
    */
}
