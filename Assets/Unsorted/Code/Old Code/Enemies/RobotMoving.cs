using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RobotMoving : MonoBehaviour
{
    public bool lockY; float startY;
    bool Ground1;    public bool raycastHit;
    public bool FireBullet; public float health; public GameObject arm;  public bool dontUseLook;   public bool shotgunBullet;
    public GameObject lookAt; float calculateTime; Vector3 randomTarget; public Vector3 start;
    public bool StandStill; public AudioClip[] robotActivatedSounds; private bool activated;
    public GameObject EnemyBullet; GameObject enemyBullets; public float extraSpeed; public float extraArea;
    public GameObject player; public float extraSize; public bool flyer; private float OgY; public GameObject body;
    private Vector3 boxPos; public float raycastMultiplier; Vector3 lastPos; public LayerMask layers; public bool useMask;
    float maxDistance; Vector3[] edges = new Vector3[4]; public float CustomBulletSpeed; public float customBulletRange; public float extraBullets;
    [HideInInspector] public GameObject bullet; public Collider col; public Vector3 veloc; float lastlooked;    public bool dontMove;
    public float randomTime1;   public float randomTime2; public float randomTime3; bool retro; float extraDamage;  float difficulty;
    float agressiveness; public float SpeedDifficulty = 1;
    musicHost host;
    public void fireBullet()
    {
        startY = transform.position.y;
        if (!player)
            player = FindObjectOfType<Movement>().gameObject;
        if (!player)
            return;
        if (Vector3.Distance(transform.position, player.transform.position) < 25)
        {
            player.gameObject.GetComponent<Movement>().HitTimee = Time.realtimeSinceStartup;
            player.gameObject.GetComponent<Movement>().HitTime = Time.realtimeSinceStartup + 1 / difficulty;
            player.gameObject.GetComponent<Movement>().PlayerHealth -= (25 + extraDamage) * difficulty;
        }
        GetComponent<AudioSource>().Play();
        if (flyer && player)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 35)
                return;
        }
        Debug.Log("Firing");
        Quaternion oldRot = transform.rotation;
       // if (extraBullets != 0)
         //   transform.Rotate(0, customBulletRange * -1, 0);
        for (int i = 0; i < extraBullets + 1; i++)
        {
            maxDistance = 100;
            FireBullet = false;
            GameObject newBullet;
            if (EnemyBullet == null)
                newBullet = Instantiate(GameObject.Find("EnemyBullet"));
            else
                newBullet = Instantiate(EnemyBullet);
            if (lookAt)
                newBullet.transform.rotation = lookAt.transform.rotation;
            newBullet.GetComponent<enemyBullet2>().raycastHit = raycastHit;
            newBullet.GetComponent<enemyBullet2>().shotGun = shotgunBullet;
            newBullet.transform.position = transform.position + transform.forward;
            newBullet.GetComponent<enemyBullet2>().enabled = true;
            if (CustomBulletSpeed != 0)
                newBullet.GetComponent<enemyBullet2>().Speed = CustomBulletSpeed;

            newBullet.GetComponent<enemyBullet2>().player = player;
            newBullet.transform.position += transform.up * 5;
            Destroy(newBullet, 2);
            //transform.Rotate(0, customBulletRange * 2 / (extraBullets + 1), 0);
        }
        transform.rotation = oldRot;
    }
    // Update is called once per frame


    void Start()
    {
        GetComponent<Animator>().speed = SpeedDifficulty;
        agressiveness = Random.Range(1, 5);
        if (SceneManager.GetActiveScene().name.Contains("Retro"))
            transform.localScale /= 2;
        extraDamage = 1;
        if (PlayerPrefs.GetString("Mode") == "Easy")
            difficulty = 0.5f;
        else if (PlayerPrefs.GetString("Mode") == "Normal" || PlayerPrefs.GetString("Mode") == "One Life" || PlayerPrefs.GetString("Mode") == "One Shot")
            difficulty = 1;
        else
            difficulty = 1.5f;

        if (GetComponent<AudioSource>())
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
        randomTime1 = 1;
        randomTime2 = 1;
        for (int i = 0; i < Random.Range(1, 3); i++)
            randomTime1 *=  -1;
        for (int i = 0; i < Random.Range(1, 3); i++)
            randomTime2 *=  -1;
        randomTime3 = Random.Range(1, 3);
        
        
        if (CustomBulletSpeed == 0)
            CustomBulletSpeed = 45;
        start = transform.position;
        lastPos = transform.position;
        enemyBullets = GameObject.Find("EnemyBullets");
        if (!EnemyBullet)
        EnemyBullet = GameObject.Find("EnemyBullet");
        
        //transform.localScale = GameObject.Find("Player").transform.localScale * 2f;
        health = 10;
        activated = false;
        if (flyer)
            transform.position = new Vector3(transform.position.x, OgY, transform.position.z);
        if (gameObject.GetComponent<enemyHealth>() == null)
            gameObject.AddComponent<enemyHealth>();
        if (!gameObject.GetComponent<enemyHealth>().isInitialized)
        {
            GetComponent<enemyHealth>().startingHealth = health;
            GetComponent<enemyHealth>().Currenthealth = health;
            GetComponent<enemyHealth>().isInitialized = true;
        }
        retro = SceneManager.GetActiveScene().name.Contains("Retro");
        if (player == null)
            player = GameObject.Find("Player");
        host = FindObjectOfType<musicHost>();
    }

    void Update()
    {
        transform.position += (Mathf.Sin(Time.realtimeSinceStartup+start.x) * Vector3.right + Mathf.Cos(Time.realtimeSinceStartup + start.z) * Vector3.forward)*Time.deltaTime* agressiveness;
        if (Vector3.Distance(transform.position, player.transform.position) < 315)
        {
            if (host)
            host.foundTime = Time.realtimeSinceStartup;
            else
                host = FindObjectOfType<musicHost>();
            if (Vector3.Distance(transform.position, player.transform.position) < 115)
            {
                host.nowTime = Time.realtimeSinceStartup;
            }
            if (Physics.Raycast(transform.position, player.transform.position))
            {
                transform.position += (Mathf.Sin(Time.realtimeSinceStartup + start.x) * Vector3.right + Mathf.Cos(Time.realtimeSinceStartup + start.z) * Vector3.forward) * Time.deltaTime * agressiveness;
                Vector3 newPos = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * agressiveness);
                newPos.y = transform.position.y;
                transform.position = newPos;
            }
        }
            Vector3 pPos = new Vector3();
        if (!player)
            player = FindObjectOfType<Movement>().gameObject;
        if (player)
        pPos = player.transform.position;
        if (transform.position.y < start.y - 900)
            Destroy(gameObject);
        if (Vector3.Distance(transform.position, player.transform.position) < 55)
            transform.position += 30 * Time.deltaTime* (transform.right * Mathf.Sin(Time.realtimeSinceStartup) + transform.forward * Mathf.Cos(Time.realtimeSinceStartup + 1));
        else if (Vector3.Distance(transform.position, player.transform.position) < 115)
            transform.position +=15 * Time.deltaTime * (transform.right * Mathf.Sin(Time.realtimeSinceStartup) + transform.forward * Mathf.Cos(Time.realtimeSinceStartup + 1));
        else
            transform.position += 7 * Time.deltaTime * (transform.right * Mathf.Sin(Time.realtimeSinceStartup) + transform.forward * Mathf.Cos(Time.realtimeSinceStartup + 1));
        if (Vector3.Distance(transform.position, player.transform.position) < 15)
        {
            player.gameObject.GetComponent<Movement>().HitTimee = Time.realtimeSinceStartup;
            player.gameObject.GetComponent<Movement>().HitTime = Time.realtimeSinceStartup + 1 / difficulty;
            player.gameObject.GetComponent<Movement>().PlayerHealth -= (10 + extraDamage) * difficulty;
        }
        if (player && retro)
        {
            transform.LookAt(player.transform);
            
        }
        if (player)
            GetComponent<AudioSource>().volume = (1600 / (Vector3.Distance(transform.position, pPos) * Vector3.Distance(transform.position, pPos)));
        if (flyer && player && !retro)
        {
            if (randomTime3 == 0)
                randomTime3 = 1;
            if (randomTime2 == 0)
                randomTime2 = 1;
            Vector3 pos = transform.position;
            pos.y = pPos.y + randomTime3 * 5;
            transform.position = pos;
            transform.position += randomTime2/25 * transform.up * (Mathf.Sin(Time.realtimeSinceStartup/randomTime3));
            transform.position += (transform.right * randomTime2 * (Mathf.Sin(Time.realtimeSinceStartup / randomTime3)) + transform.forward * randomTime1 * Mathf.Cos(Time.realtimeSinceStartup / randomTime3));
        }
        else
        {
            
            if (!dontMove)
            {
                if (flyer)
                {
                    Vector3 pos = transform.position;
                    pos.y = start.y;
                    transform.position = pos;
                }
                Vector3 vel = new Vector3();
                if (flyer)
                    vel += new Vector3(transform.position.x, start.y, transform.position.z) - transform.position;
                if (player == null)
                    player = GameObject.Find("Player");
                if (player == null)
                    player = Object.FindObjectOfType<Movement>().gameObject;
                if (tag != "dead")// && Vector3.Distance(transform.position, player.transform.position) < 90)
                {

                    if (!dontUseLook)
                    {
                        if (lookAt && lookAt.GetComponent<InsidePlayerLook>())
                            transform.rotation = lookAt.transform.rotation;
                    }
                    if (Vector3.Distance(transform.position, player.transform.position) > 120)
                    {
                        veloc /= 10;
                    }
                    else if (Vector3.Distance(transform.position, player.transform.position) > 30)
                    {
                        veloc /= 10;
                        if (!dontUseLook)
                        {
                            transform.LookAt(player.transform.position);
                        }
                        vel += transform.forward * 1;
                    }
                    else
                        vel += (veloc / 5);
                    if (Random.Range(-10, 10) == 0)
                    {
                        veloc.x = Random.Range(-1, 1);
                        veloc.y = Random.Range(0, 0);
                        veloc.z = Random.Range(-1, 1);
                    }
                    vel /= Time.fixedDeltaTime;
                    vel.y = GetComponent<Rigidbody>().velocity.y;
                    GetComponent<Rigidbody>().velocity = vel;
                    //if (transform.position.y-10 > start.y)
                    // transform.position = new Vector3(transform.position.x, start.y, transform.position.z);
                }
                Vector3 vel3 = transform.position;
                Vector3 vel2 = GetComponent<Rigidbody>().velocity;
                if (vel3.y > start.y + 10)
                    vel3.y = start.y;
                if (vel2.y > 3)
                    vel2.y = 0;
                GetComponent<Rigidbody>().velocity = vel2;
                transform.position = vel3;
            }
        }
        Quaternion rot = transform.rotation;
        rot.x = 0;
        
        rot.z = 0;
        if (Vector3.Distance(transform.position, player.transform.position) > 45)
        transform.rotation = rot;
        
        if (lockY)
        {

            Vector3 pos = transform.position;
            pos.y = startY;
            transform.position = pos;
        }
    }
}

