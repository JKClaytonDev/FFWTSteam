using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class moveBullet : MonoBehaviour {
public bool loneSurvivor;   public float startuptime;
public float speed;     public bool ForceOnHit;
public float damage;    public bool ForceonFire;
public float force;     private bool hit;
private bool isParent;   public bool Bloom;
public float BloomRange;    public float ExtraBullets;
    private bool exploded;  public GameObject forceExample;
    public GameObject trail;    GameObject player;
private GameObject inFront; private Vector3 ogspot;
    public LayerMask enemies;
    Vector3 bulletSpeed;    GameObject particles;

    // Use this for initialization
    void OnCollisionEnter(Collision collision)
    {
        if (!exploded)
        {
            explode();
            exploded = true;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (!exploded)
        {
            explode();
            exploded = true;
        }
    }
    void Start () {
        transform.parent = null;
        transform.position = GameObject.Find("PlayerCamera").transform.position;
        transform.rotation = GameObject.Find("PlayerCamera").transform.rotation;
        exploded = false;
    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    isParent = (!gameObject.name.Contains("(Clone)"));
    {
        startuptime = Time.realtimeSinceStartup;
        hit = false;
        if (transform.position.x != -500)
            loneSurvivor = false;
        else
            loneSurvivor = true;
    float screenX = Screen.width / 2;
    float screenY = Screen.height / 2;
    transform.position = GameObject.Find("Player").transform.position;
    //transform.rotation = GameObject.Find("Player").transform.rotation;
        if (Bloom)
        {
            transform.Rotate(Random.Range(BloomRange*-1, BloomRange), Random.Range(BloomRange * -1, BloomRange), Random.Range(BloomRange * -1, BloomRange));
        }
            transform.Rotate(new Vector3(0, 45, 0));

        }
        trail.SetActive(true);
}
    void OnEnable()
    {
        transform.Rotate(new Vector3(0, 15*(transform.rotation.y-GameObject.Find("PlayerCamera").transform.rotation.y), 0));
        transform.Rotate(new Vector3(0, 45, 0));
        particles = GameObject.Instantiate(Object.FindObjectOfType<Movement>().gameObject.GetComponent<doneShooting>().bulletParticles);
        bulletSpeed = transform.forward * 2;

        Destroy(particles, 3);
    }
    // Update is called once per frame
    void Update () {

    if (particles)
       particles.transform.position = transform.position;
    {
         if (Input.GetMouseButtonDown(1))
            {
                explode();
            }
        
    }
}

void explode()
    {
        GameObject force3 = Instantiate(GameObject.Find("BulletFlash"));
        force3.SetActive(false);
        force3.SetActive(true);
        force3.transform.position = transform.position;
        force3.GetComponent<AutoDestroy2>().enabled = true;
        
        {
            GameObject force = Instantiate(forceExample);
            force.SetActive(false);
            force.SetActive(true);
            force.transform.position = transform.position;
            Destroy(force, 2);
        }
        if (!isParent && (gameObject.name.Contains("(Clone)")))
        {

            Destroy(gameObject);
        }
    }
}
