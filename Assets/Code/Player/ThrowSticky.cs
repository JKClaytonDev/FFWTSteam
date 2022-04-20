using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSticky : MonoBehaviour {
    public bool hit;
    public bool Survivor;
    public bool boomin;
    public GameObject explode;
    public float radius = 5.0F;
    public float power = 10.0F;
    private string lastName;
    private float destroyTime;
    private Vector3 dir;
    void Start()
        {
        destroyTime = 15000;
        GetComponent<Light>().enabled = false;
        lastName = "";
        Survivor = gameObject.name.Contains("(Clone)");


        boomin = false;
        hit = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        //if (name != "Bullet")
                //GameObject.Destroy(gameObject, 1f);
            

        Transform playertrans = GameObject.Find("Muzzle").transform;
        playertrans.rotation = GameObject.Find("Player").transform.rotation;
        Quaternion playerrot = playertrans.rotation;
        playerrot.x = 0;
        playerrot.z = 0;
        playertrans.position += playertrans.forward;
        transform.position = playertrans.position;
        //transform.rotation = playertrans.rotation;
        dir = playertrans.forward;
        }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Player" && hit == false)
        {
            GetComponent<Light>().enabled = true;
            if (collision.gameObject.transform != null)
                transform.LookAt(collision.gameObject.transform);
            else if (collision.gameObject.transform.rotation != null)
                transform.rotation = collision.gameObject.transform.rotation;
            else
                transform.rotation = collision.transform.rotation;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity /= 100;
            hit = true;
        }
        
    }
        // Update is called once per frame
        void Update()
        {

            if (Time.realtimeSinceStartup > destroyTime)
            {
                explode.transform.position = new Vector3(500, 500, 500);
                Destroy(gameObject, 0.1f);
                
            }
            if (hit == true)
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().velocity /= 100;
            }
            if (GetComponent<MeshRenderer>() != null)
            GetComponent<MeshRenderer>().enabled = true;

            if (!hit)
                transform.position += dir / 1.3f;

            if (Input.GetMouseButton(1))
            {
                explode.transform.position = transform.position;
                
                Debug.Log("BOOM!");
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                Vector3 explosionPos = transform.position;
                Collider[] colliders = Physics.OverlapSphere(explosionPos, 5);
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                foreach (Collider hit in colliders)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null && rb.transform.position != null && rb != GetComponent<Rigidbody>())
                    {
                        Debug.Log((transform.position - rb.transform.position));
                        rb.velocity -= 5 * ((transform.position - rb.transform.position) / Vector3.Distance(transform.position, rb.transform.position));
                    }
                    //rb.AddExplosionForce(power, explosionPos, radius, 15.0f, ForceMode.Impulse);
                }
                destroyTime = Time.realtimeSinceStartup + 0.5f;
        

            
        }
        else
        {

        }
        }

    }
