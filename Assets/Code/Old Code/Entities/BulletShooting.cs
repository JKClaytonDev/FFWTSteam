using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour {

    Quaternion weaponRot;
    public float damage;
    public float size;
    public bool useVelocity;
    float alreadyexploded;
    public Vector3 weaponPos;
    public Animator ShotgunAnim;
    private Rigidbody rb;
    public Rigidbody fire;
    float shoottime;
    Vector3 v2;
    public GameObject bullet;
    Vector3 fullweaponpos;
    public GameObject tempmuzzle; public GameObject tempexit;
    public Rigidbody muzzle;
    public Rigidbody exit;
    public Rigidbody gunModel;
    Vector3 fullspeed;
    public GameObject me;
    public float speed;
    public GameObject nullObject;
    Vector3 bulletSpeed;
    float deathtimes;
    float justdied;
    private GameObject player;
    public float ammo;
    float iwasshottime;
    float alreadyshot;
    bool ready;
    float lastlooked;
    float deathtime;
    public AudioSource explodeSound;
    //public AudioSource deathsound;
    //public AudioSource hitsound;
    //public AudioSource shootsound;
    GameObject explode;
    float fireTime;
    Rigidbody explosion;
    float startuptime;
    public float FireRate; public float GunDamage; public float gunPower; public Vector3 vel;

    // Use this for initialization
    void Start () {

        startuptime = Time.realtimeSinceStartup;
        ready = false;
        player = GameObject.Find("Player");
        alreadyexploded = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<FireScript>().startuptime + 3 > Time.realtimeSinceStartup || player.GetComponent<FireScript>().startuptime == 0)
        {
            transform.position = new Vector3(900, 900, 900);
        }
        rb = player.GetComponent<Rigidbody>();
        ammo = 0;
        if (player.GetComponent<FireScript>().equippedweapon == 1)
        {
            player.GetComponent<FireScript>().ShotgunAmmo--;
            ammo = player.GetComponent<FireScript>().ShotgunAmmo;
        }
        if (player.GetComponent<FireScript>().equippedweapon == 2)
        {
            player.GetComponent<FireScript>().AssaultRifleAmmo--;
            ammo = player.GetComponent<FireScript>().AssaultRifleAmmo;
        }
        if (player.GetComponent<FireScript>().equippedweapon == 3)
        {
            player.GetComponent<FireScript>().RevolverAmmo--;
            ammo = player.GetComponent<FireScript>().RevolverAmmo;
        }
        if (player.GetComponent<FireScript>().equippedweapon == 4)
        {
            player.GetComponent<FireScript>().ChaingunAmmo--;
            ammo = player.GetComponent<FireScript>().ChaingunAmmo;
        }
        if (player.GetComponent<FireScript>().equippedweapon == 5)
        {
            player.GetComponent<FireScript>().RocketLauncherAmmo--;
            ammo = player.GetComponent<FireScript>().RocketLauncherAmmo;
        }
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        GetComponent<SphereCollider>().enabled = false;

        if (1 < Time.realtimeSinceStartup)
        {


            transform.position = muzzle.position;
            
            shoottime = Time.realtimeSinceStartup;
            v2 = (me.transform.position - muzzle.transform.position) * 105 * gunPower * speed * 2;
            
            //rb.AddForceAtPosition(v2, muzzle.transform.position, ForceMode.Impulse);
            bullet.transform.position = rb.transform.position;

            fullweaponpos = weaponPos;
            fullweaponpos.y = 0;

            tempmuzzle.transform.position = muzzle.position;
            tempexit.transform.position = exit.position;
            
            bulletSpeed = Vector3.MoveTowards(tempmuzzle.transform.position, tempexit.transform.position, 15) - muzzle.position;
            fullspeed = bulletSpeed * 1;
            gunModel.transform.position += v2 / 100;
            //rb.AddForceAtPosition(v2, tempmuzzle.transform.position, ForceMode.Impulse);
            vel = (tempexit.transform.position - tempmuzzle.transform.position) * (16 / FireRate);
        
        }
    }
    void OnTriggerEnter()
    {

        if (player.GetComponent<FireScript>().equippedweapon == 5 && Vector3.Distance(player.transform.position, transform.position) > 10 && alreadyexploded == 0)
        {
            if (Vector3.Distance(rb.transform.position, transform.position) < 10)
            {
                rb.GetComponent<FireScript>().Playerhealth--;
            }
            explodeSound.Play();
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject target in bullets)
            {
                if (target.GetComponent<TurretCode>().enabled == true)
                {
                    explosion = target.GetComponent<TurretCode>().explode;
                    explode = target.GetComponent<TurretCode>().explosion;
                }
                
            }
            explosion.AddExplosionForce(10, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), 20);
            alreadyexploded = 1;
            for (float j = 1; j < 20; j++)
            {
                Object Explodey = GameObject.Instantiate(explosion, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), transform.rotation);
                Destroy(Explodey, 1);
            }

            bullets = GameObject.FindGameObjectsWithTag("Bullet");
            float x = 0;
            foreach (GameObject target in bullets)
            {
                x++;

            }
            GameObject[] bulletslength = GameObject.FindGameObjectsWithTag("Bullet");
            if (bulletslength.Length > 1 && x > 2 && fireTime > 3 + rb.GetComponent<FireScript>().startuptime)

            {
                //Destroy(gameObject, 1);
            }
            
            

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (startuptime + 0.5f < Time.realtimeSinceStartup && ready == false && GetComponent<SphereCollider>() == null)
        {
            ready = true;
            SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        }

        transform.localScale = new Vector3(size, size, size);
        if (useVelocity)
            GetComponent<Rigidbody>().velocity = speed * (vel / -20) * 15;
        else
            transform.position += speed * (vel / -20);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        /*
         foreach (GameObject target in enemies)
         {
             float distance = Vector3.Distance(target.transform.position, transform.position);
             if (distance < 15 && Time.realtimeSinceStartup > 2)
             {
                 gameObject.transform.position = nullObject.transform.position;
                 target.transform.position = nullObject.transform.position;
                 Object.Destroy(target);
                 Object.Destroy(gameObject);
             }
         }
         */
    }



}
