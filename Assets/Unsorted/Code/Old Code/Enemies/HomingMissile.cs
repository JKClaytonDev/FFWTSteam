using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour {
    private GameObject player;
    private Rigidbody explode; private GameObject explosion;
    public float slowness;  public AudioSource explodeSound;
    public AudioSource damageSound;
    private float speed;
	// Use this for initialization
	void Start () {
        GetComponent<BoxCollider>().size.Set(2, 1, 2);
        transform.localScale = new Vector3(5, 5, 5);
        speed = 1 / slowness;
        player = GameObject.FindGameObjectWithTag("Player");
        explode = (GameObject.FindGameObjectWithTag("explosion")).GetComponent<Rigidbody>();
        explosion = GameObject.FindGameObjectWithTag("explosion");
    }

    // Update is called once per frame
    void Update()
    {
        

        GameObject[] legsleft = GameObject.FindGameObjectsWithTag("leg");
        speed = (5-legsleft.Length) / slowness;
        if (transform.position.x == 100 && transform.position.y == 100)
        {
            
            //(TempForLag)Debug.log((legsleft.Length + "legs left");
        }
        else {
            transform.LookAt(player.transform);

            Vector3 movepos = transform.position;
            if (transform.position.x < player.transform.position.x)
                movepos.x += speed;
            else
                movepos.x -= speed;
            if (transform.position.z < player.transform.position.z)
                movepos.z += speed;
            else
                movepos.z -= speed;
            if (transform.position.y < player.transform.position.y)
                movepos.y += speed;
            else
                movepos.y -= speed;
            transform.position = movepos;

            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            float distance = 10;
            foreach (GameObject target in bullets)
            {
                distance = Vector3.Distance(target.transform.position, transform.position);
                if (distance < 3 && distance != 0 && Time.realtimeSinceStartup > 5)
                {
                    explodeSound.Play();
                    explode.AddExplosionForce(10, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), 20);
                    for (float j = 1; j < 10; j++)
                    {
                        Object Explodey = GameObject.Instantiate(explosion, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), transform.rotation);
                        Destroy(Explodey, 1);

                    }
                    Destroy(gameObject);
                }
            }
            distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance < 5 && Time.realtimeSinceStartup > 5)
            {
                player.GetComponent<FireScript>().Playerhealth--;
                Destroy(gameObject);
                damageSound.Play();
                explode.AddExplosionForce(10, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), 20);
                for (float j = 1; j < 10; j++)
                {
                    Object Explodey = GameObject.Instantiate(explosion, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), transform.rotation);
                    Destroy(Explodey, 1);
                }

            }
        }
    }
}
