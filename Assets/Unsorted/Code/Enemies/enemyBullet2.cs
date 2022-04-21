using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enemyBullet2 : MonoBehaviour {
    bool level1;
    private Vector3 startSpot; public float extraDamage;
    private float StartTime; public float Speed = 1;
    private bool isParent;  public bool turretbullet;
    public GameObject player;   int maxParts;   public bool raycastHit;
    float healthTime;   public GameObject onImpact;
    float difficulty;   public bool shotGun;
    // Use this for initialization
    private void OnTriggerEnter(Collider collision)
    {
        if (onImpact)
            Instantiate(onImpact, transform);
        if (collision.gameObject.GetComponent<Movement>() != null)
        {
            if (collision.gameObject.GetComponent<Movement>().HitTimee + healthTime < Time.realtimeSinceStartup)
            {
                collision.gameObject.GetComponent<Movement>().HitTimee = Time.realtimeSinceStartup;
                collision.gameObject.GetComponent<Movement>().HitTime = Time.realtimeSinceStartup + 1 / difficulty;
                collision.gameObject.GetComponent<Movement>().PlayerHealth -= (12 + extraDamage) * difficulty;
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (onImpact)
            Instantiate(onImpact, transform);
        if (collision.gameObject.GetComponent<Movement>() != null)
        {
            if (collision.gameObject.GetComponent<Movement>().HitTimee + healthTime < Time.realtimeSinceStartup){
                collision.gameObject.GetComponent<Movement>().HitTimee = Time.realtimeSinceStartup;
            collision.gameObject.GetComponent<Movement>().HitTime = Time.realtimeSinceStartup + 1/difficulty;
            collision.gameObject.GetComponent<Movement>().PlayerHealth-= (12 + extraDamage)*difficulty;
        }
        Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (onImpact)
            Instantiate(onImpact, transform);
        if (collision.gameObject.GetComponent<Movement>() != null)
        {
            if (collision.gameObject.GetComponent<Movement>().HitTimee + healthTime < Time.realtimeSinceStartup)
            {
                collision.gameObject.GetComponent<Movement>().HitTimee = Time.realtimeSinceStartup;
                collision.gameObject.GetComponent<Movement>().HitTime = Time.realtimeSinceStartup + 1 / difficulty;
                collision.gameObject.GetComponent<Movement>().PlayerHealth -= (12 + extraDamage) * difficulty;
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (onImpact)
            Instantiate(onImpact, transform);
        if (collision.gameObject.GetComponent<Movement>() != null)
        {
            if (collision.gameObject.GetComponent<Movement>().HitTimee + healthTime < Time.realtimeSinceStartup)
            {
                collision.gameObject.GetComponent<Movement>().HitTimee = Time.realtimeSinceStartup;
                collision.gameObject.GetComponent<Movement>().HitTime = Time.realtimeSinceStartup + 1 / difficulty;
                collision.gameObject.GetComponent<Movement>().PlayerHealth -= (12 + extraDamage) * difficulty;
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (onImpact)
            Instantiate(onImpact, transform);
        if (collision.gameObject.GetComponent<Movement>() != null)
        {
            if (collision.gameObject.GetComponent<Movement>().HitTimee + healthTime < Time.realtimeSinceStartup)
            {
                collision.gameObject.GetComponent<Movement>().HitTimee = Time.realtimeSinceStartup;
                collision.gameObject.GetComponent<Movement>().HitTime = Time.realtimeSinceStartup + 1 / difficulty;
                collision.gameObject.GetComponent<Movement>().PlayerHealth -= (12 + extraDamage) * difficulty;
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start() {
        level1 = raycastHit || SceneManager.GetActiveScene().name == "Level1";
        if (shotGun)
            transform.Rotate(0, Random.Range(-20, 20), 0);
        gameObject.AddComponent<CapsuleCollider>();
        gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        GetComponent<CapsuleCollider>().center = new Vector3();
        GetComponent<CapsuleCollider>().radius = 4;
        GetComponent<CapsuleCollider>().height = 1;

        healthTime = 1.5f;
        if (PlayerPrefs.GetString("Mode") == "Easy")
            healthTime = 2.5f;
        if (PlayerPrefs.GetString("Mode") == "Hard")
            healthTime = 0.5f;
        if (PlayerPrefs.GetString("Mode") == "One Shot")
            healthTime = 0;
        if (!player)
        {
            if (!FindObjectOfType<Movement>())
                return;
            player = FindObjectOfType<Movement>().gameObject;
        }
        if (!GetComponent<Rigidbody>())
            this.gameObject.AddComponent<Rigidbody>();
        if (PlayerPrefs.GetString("Mode") == "Easy")
            difficulty = 0.5f;
        else if (PlayerPrefs.GetString("Mode") == "Normal" || PlayerPrefs.GetString("Mode") == "One Life" || PlayerPrefs.GetString("Mode") == "One Shot")
            difficulty = 1;
        else
            difficulty = 1.5f;

        if (GetComponent<SphereCollider>())
            GetComponent<SphereCollider>().radius = 2 * difficulty;
        transform.Rotate(-transform.rotation.x, 0, -transform.rotation.z);
        isParent = (!gameObject.name.Contains("(Clone)"));
        StartTime = Time.realtimeSinceStartup;
        startSpot = transform.position;
        Vector3 forward = transform.forward;
        if (turretbullet)
        {
            forward.y = 0;
        }
        if (PlayerPrefs.GetString("Mode") == "Easy")
            Speed /= 2;
        if (PlayerPrefs.GetString("Mode") == "Hard")
            Speed *= 2;
        
        forward.y = 0;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = transform.forward * 2 * Speed * difficulty;
    }
    void Update()
    {
        if (level1)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (!(hit.collider.gameObject.GetComponent<Movement>() || hit.collider.gameObject.name.Contains("Player")))
                {
                    if (hit.distance < 5)
                    Destroy(gameObject);
                }
            }
        }
        if (player)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 15)
            {
                if (onImpact)
                    Instantiate(onImpact, transform);
                if (player.GetComponent<Movement>() != null)
                {
                    if (player.gameObject.GetComponent<Movement>().HitTimee + healthTime < Time.realtimeSinceStartup)
                    {
                        player.gameObject.GetComponent<Movement>().HitTimee = Time.realtimeSinceStartup;
                        player.gameObject.GetComponent<Movement>().HitTime = Time.realtimeSinceStartup + 1 / difficulty;
                        player.gameObject.GetComponent<Movement>().PlayerHealth -= (5 + extraDamage) * difficulty;
                    }
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}
