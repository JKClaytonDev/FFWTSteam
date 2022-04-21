using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCode : MonoBehaviour {
    public bool noSpin;
    public GameObject Player;
    public GameObject cube;
    public GameObject model;
    float shoottime;
    public float extrahealth;
    public GameObject bullet;
    float deathtimes;
    private TextMesh enemyhealth;
    float justdied;
    float iwasshottime;
    float alreadyshot;
    float lastlooked;
    float deathtime;
    public float firespeed;
    public AudioSource deathsound;
    public AudioSource hitsound;
    public AudioSource shootsound;
    public GameObject explosion;
    public float startuptime;
    public Rigidbody explode;
    public float startupoptime;
    float newDamage;
    public bool fixedb;
    public float fireTime = 1;
    public GameObject parent;
    public AnimationEvent evt;
    public bool targetPlayer;
    public int destroyTime = 3;
    // Use this for initialization
    void Start () {
        evt = new AnimationEvent();
        evt.functionName = "Fire";
        Player = GameObject.Find("Player");
        if (!Player && FindObjectOfType<Movement>())
            Player = FindObjectOfType<Movement>().gameObject;
        shoottime = 0;
        deathtimes = 0;
        justdied = 0;
        lastlooked = 0;
        deathtime = -0;
        iwasshottime = 0;
        startuptime = Time.realtimeSinceStartup;
        newDamage = 0;
        
    }
	public void Fire()
    {
        if (!Player && FindObjectOfType<Movement>())
            Player = FindObjectOfType<Movement>().gameObject;
        Debug.Log("SHOOTING! + FIRE FIRE FIRE");
        //shootsound.Play();

        float dir = Random.Range(1, 90) * 10;
        if (!fixedb)
                dir = 0;
        GameObject cloneEnemyBullet = GameObject.Instantiate(bullet, transform.position, transform.rotation);
        if (cloneEnemyBullet.GetComponent<moveBullet>())
        {
            Destroy(cloneEnemyBullet.GetComponent<moveBullet>());
        }
        cloneEnemyBullet.name = "TURRETNAME";
        cloneEnemyBullet.transform.rotation = transform.rotation;
        if (!fixedb)
            cloneEnemyBullet.transform.Rotate(0, 90 * Random.Range(-3, 3), 0);
        if (targetPlayer)
            cloneEnemyBullet.transform.LookAt(Player.transform);
        cloneEnemyBullet.transform.position += cloneEnemyBullet.transform.forward * 15;
        Destroy(cloneEnemyBullet, destroyTime);
        shoottime = Time.realtimeSinceStartup + (1 / (firespeed + 1));
    }
	// Update is called once per frame
	void FixedUpdate () {
        if (Time.realtimeSinceStartup % fireTime == 0)
            Fire();
        if (deathtime + 1 > Time.realtimeSinceStartup && deathtime != 0)
        {
            Vector3 fall = transform.position;
            fall.y -= 10;
            transform.position = fall;
        }
        else if (deathtime != 0)
        {

            Object.Destroy(gameObject);
        }
        alreadyshot = 0;

    }


}
