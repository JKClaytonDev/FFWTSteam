using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour {
    public GameObject bullet;
    public Collider col;
    public float flyingSpeed;
    public GameObject player;
    float newDamage;
    public GameObject explosion;
    public Rigidbody explode;
    public Vector3 veloc;
    public GameObject Gamesprite;
    public float extrahealth;
    public float shoottime;
    float deathtimes;
    float justdied;
    float iwasshottime;
    float alreadyshot;
    float startuptime;
    private TextMesh enemyhealth;
    float lastlooked;
    float deathtime;
    float health;
    float lastshottime;
    float active;
    public AudioSource deathsound;
    public AudioSource hitsound;
    public AudioSource shootsound;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        explode.GetComponent<MeshRenderer>().enabled = false;
        gameObject.SetActive(true);
        active = 1;
        startuptime = Time.realtimeSinceStartup;
        shoottime = Time.realtimeSinceStartup;
        deathtimes = 0;
        justdied = 0;
        lastlooked = 0;
        deathtime = -0;
        iwasshottime = 0;
        veloc.x = Random.Range(-1, 1);
        veloc.y = Random.Range(0, 0);
        veloc.z = Random.Range(-1, 1);

        gameObject.AddComponent<enemyHealth>();
        GetComponent<enemyHealth>().enabled = false;
        GetComponent<enemyHealth>().startingHealth = 4;
        GetComponent<enemyHealth>().isInitialized = true;
        GetComponent<enemyHealth>().enemyClass = "Flying Turret";
        GetComponent<enemyHealth>().weaponDamages[0] = 0.7;
        GetComponent<enemyHealth>().weaponDamages[0] = 0;
        GetComponent<enemyHealth>().weaponDamages[0] = 0.5;
        GetComponent<enemyHealth>().weaponDamages[0] = 0.6;
        GetComponent<enemyHealth>().weaponDamages[0] = 0;
        GetComponent<enemyHealth>().weaponDamages[0] = 0.6;
        GetComponent<enemyHealth>().weaponDamages[0] = 0.4;
        GetComponent<enemyHealth>().weaponDamages[0] = 0;
        GetComponent<enemyHealth>().weaponDamages[0] = 0.7;
        GetComponent<enemyHealth>().weaponDamages[0] = 0.3;
        GetComponent<enemyHealth>().enabled = true;
    }



    // Update is called once per frame
    void Update()
    {
        
            if (active == 1 && Time.realtimeSinceStartup > 3+startuptime)
        {
            alreadyshot = 0;
            if (Vector3.Distance(transform.position, player.transform.position) > 120)
            {
                veloc /= 10;
            }
            else if (Vector3.Distance(transform.position, player.transform.position) > 30 * flyingSpeed)
            {
                veloc /= 10;
                transform.LookAt(player.transform.position);
                transform.position += transform.forward * 1 * flyingSpeed;
            }
            else
                transform.position += (veloc / 5) * flyingSpeed;
            if (Random.Range(-10, 10) == 0)
            {
                veloc.x = Random.Range(-1, 1);
                veloc.y = Random.Range(0, 0);
                veloc.z = Random.Range(-1, 1);
            }
            if (lastlooked < Time.realtimeSinceStartup)
            {
                lastlooked = Time.realtimeSinceStartup + 0.2f / flyingSpeed;
                transform.LookAt(player.transform.position);
            }


            //transform.LookAt(player.transform.position);
            if (shoottime < Time.realtimeSinceStartup && Vector3.Distance(transform.position, player.transform.position) < 120)
            {
                transform.LookAt(player.transform.position);
                shootsound.Play();
                
                Object cloneEnemyBullet = GameObject.Instantiate(bullet, transform.position, transform.rotation);
                Destroy(cloneEnemyBullet, 3);
                shoottime = Time.realtimeSinceStartup + Random.Range(2, 2.5f); ;

            }
            alreadyshot = 0;
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject target in bullets)
            {
                if (alreadyshot == 0)
                {
                    float distance = Vector3.Distance(target.transform.position, transform.position);
                    if (distance < 10 && distance != 0 && Time.realtimeSinceStartup > 5)
                    {
                        if (justdied == 0)
                        {
                            justdied = 1;
                            hitsound.Play();
                            if (deathtimes > 3+extrahealth)
                            {
                                //deathsound.Play();
                                explosion = GameObject.FindGameObjectWithTag("ComplexExplosion");
                                Object Explodey = GameObject.Instantiate(explosion, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), transform.rotation);
                                Destroy(Explodey, 1);
                                Destroy(gameObject);

                                deathtime = Time.realtimeSinceStartup;
                            }
                            else
                                hitsound.Play();
                            
                            deathtimes += target.GetComponent<BulletShooting>().damage;
                            Debug.Log(target.GetComponent<BulletShooting>().damage);
                            alreadyshot = 1;
                            iwasshottime = Time.realtimeSinceStartup;

                                Vector3 EH = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
                                transform.LookAt(player.transform);
                                Quaternion textAngle = transform.rotation;
                            textAngle.y -= 120;

                            if (player.GetComponent<FireScript>().DamageTextObject != null){
                                GameObject healthtext = GameObject.Instantiate(player.GetComponent<FireScript>().DamageTextObject, EH, textAngle);
                                healthtext.GetComponent<LookatPlayer>().DamageText.text = ("-" + newDamage + "  " + (100 - Mathf.Round(100 * (deathtimes / (3 + health)))) + "%");
                                healthtext.tag = "healthtext";
                                Destroy(healthtext, .2f);
                            }

                        }

                    }
                    else
                        justdied = 0;
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 120)
            {
                
                active = 1;
            }
    }
        if (iwasshottime+1 < Time.realtimeSinceStartup)
        {
            newDamage = 0;
        }
    }

}
