using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldBulletFlash : MonoBehaviour
{
    GameObject player;
    public LayerMask layers;
    public Vector3 bulletTarget;
    public float speed;
    public bool activated;

    void OnTriggerEnter(Collider collision)
    {
        // Debug.Log(collision.gameObject.name);
        // if (collision.gameObject.layer == layers || collision.gameObject.tag == "Enemy")
        //player.GetComponent<Movement>().KillEnemy(collision.gameObject, this.gameObject );
        //Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Start()
    {
        player = GameObject.Find("Player");
        GetComponent<Rigidbody>().velocity = player.transform.forward * 120;
        var system = GetComponent<ParticleSystem>();
        var emission = system.emission;
        emission.rateOverDistance = 0.2f / speed;
        transform.localScale *= 5 / speed;
        transform.position = GameObject.Find("Player").transform.position;


    }

}
