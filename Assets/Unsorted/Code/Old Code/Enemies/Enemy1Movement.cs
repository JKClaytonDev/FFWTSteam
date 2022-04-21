using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour {
    public GameObject playerObject;
    public float speed;
    public AudioSource blowup;
    public GameObject bullet;
    public GameObject explosion;
    public ParticleSystem particles;
    public Rigidbody explode;
    public float startuptime;
    // Use this for initialization
    void Start () {
        startuptime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup > 3 + startuptime)
        {
            transform.LookAt(playerObject.transform.position);
        transform.position = transform.position + (Vector3.MoveTowards(transform.position, playerObject.transform.position, 5)- transform.position)/speed;
            if (Vector3.Distance(transform.position, playerObject.transform.position) < 5)
            {
                blowup.Play();
                
                playerObject.GetComponent<FireScript>().Playerhealth--;
                playerObject.GetComponent<FireScript>().hitdelay = Time.realtimeSinceStartup + 1;
                explode.GetComponent<MeshRenderer>().enabled = true;
                explode.AddExplosionForce(10, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), 20);
                for (float i = 1; i < 20; i++)
                {
                    Object Explodey = GameObject.Instantiate(explosion, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), transform.rotation);
                    Destroy(Explodey, 1);
                }
                transform.localPosition = new Vector3(500, 500, 500);
                Destroy(gameObject);
            }
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject target in bullets)
            {

                float distance = Vector3.Distance(target.transform.position, transform.position);
                if (distance < 10 && distance != 0 && Time.realtimeSinceStartup > 5)
                {
                    
                    explode.AddExplosionForce(10, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), 20);
                    for (float i = 1; i < 25; i++)
                    {
                        Object Explodey = GameObject.Instantiate(explosion, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), transform.rotation);
                        Destroy(Explodey, 1);
                    }
                    transform.localPosition = new Vector3(500, 500, 500);
                    Destroy(gameObject);
                }
            }
        }

    }

}
