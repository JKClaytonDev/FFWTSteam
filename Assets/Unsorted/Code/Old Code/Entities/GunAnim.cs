using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnim : MonoBehaviour {

    private Animation anim; public Rigidbody fire;
    private Animator animtr;
    public float ammo;
    private GameObject self;
    public GameObject newBullet;
    private Rigidbody playerrb;
    public AudioSource fireSound;
    float startuptime;
    public GameObject player;
    public GameObject weapons;
    Vector3 playerVel;
    Vector3 lastSpot;
    Vector3 oldVel;
    float firetime;
    float chaingunfinishtime;
    float lmbpressed;
    float chaingunspeed;
    Vector3 oldGunPos;
    Vector3 PlayerVelY;
    // Use this for initialization
    private void Start() {

        player = Object.FindObjectOfType<Movement>().gameObject;
        playerrb = player.GetComponent<Rigidbody>();
        weapons = gameObject.transform.parent.gameObject;

        if (fireSound == null)
            fireSound = GameObject.FindGameObjectWithTag("EnemyBullet").GetComponent<AudioSource>();
        

        fire = GameObject.FindGameObjectWithTag("Bullet").GetComponent<Rigidbody>();
        GameObject[] newBullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject target in newBullets)
        {
            if (target.name == "Bullet")
            {
                newBullet = target;
            }
        }
        self = gameObject;
        anim = GetComponent<Animation>();
        animtr = GetComponent<Animator>();
        fireSound = GetComponent<AudioSource>();
        ammo = 0;
        chaingunspeed = 1;
        chaingunfinishtime = 0;
        oldGunPos = transform.position - playerrb.transform.position;
        //anim[anim.name].speed = 3;
        anim.wrapMode = WrapMode.Loop;
        anim.enabled = true;
        self.gameObject.tag = "Quiet";
        firetime = 0;
        PlayerVelY = weapons.transform.position-playerrb.transform.position;
        startuptime = Time.realtimeSinceStartup;
    }
	
	// Update is called once per frame
	void Update () {
        if (lastSpot == null)
            lastSpot = playerrb.transform.position;
        playerVel = playerrb.transform.position - lastSpot;
        playerVel.y = 0;
        lastSpot = playerrb.transform.position;
        //transform.position = lastSpot;
        if (Input.GetMouseButtonDown(0))
            lmbpressed = 1;
        else if (Input.GetMouseButtonUp(0))
            lmbpressed = 0;
        else if (lmbpressed == 0 && gameObject.name == "Chaingun" && Time.realtimeSinceStartup > chaingunfinishtime+.05f && chaingunspeed > .5)
            lmbpressed = 2;
        else if (lmbpressed == 2)
            lmbpressed = 0;


        //Quaternion rot = weapons.transform.rotation;
        //rot.x += (player.transform.rotation.x - weapons.transform.rotation.x) / 10;
        //rot.y += (player.transform.rotation.y - weapons.transform.rotation.y) / 10;
        //weapons.transform.rotation = rot;

        //if (!(self.name == "Revolver"))
        //weapons.transform.position = playerrb.transform.position + PlayerVelY + playerVel/3;
        //else
        //weapons.transform.position = playerrb.transform.position;
        animtr.speed = chaingunspeed;
        if ( lmbpressed != 0 && ((gameObject.name == "Chaingun" && Time.realtimeSinceStartup > chaingunfinishtime + .05f) || (gameObject.name != "Chaingun" && Time.realtimeSinceStartup > firetime + this.animtr.GetCurrentAnimatorStateInfo(0).length)))
        {
            
            if (player.GetComponent<FireScript>().equippedweapon == 1)
            {
                ammo = player.GetComponent<FireScript>().ShotgunAmmo;
            }
            if (player.GetComponent<FireScript>().equippedweapon == 2)
            {
                ammo = player.GetComponent<FireScript>().AssaultRifleAmmo;
            }
            if (player.GetComponent<FireScript>().equippedweapon == 3)
            {
                ammo = player.GetComponent<FireScript>().RevolverAmmo;
            }
            if (player.GetComponent<FireScript>().equippedweapon == 4)
            {
                ammo = player.GetComponent<FireScript>().ChaingunAmmo;
            }
            if (player.GetComponent<FireScript>().equippedweapon == 5)
            {
                ammo = player.GetComponent<FireScript>().RocketLauncherAmmo;
            }
            if (ammo > 0)
            {
                if (gameObject.name == "Chaingun")
                {
                    if (lmbpressed == 1 && chaingunspeed < 10)
                        chaingunspeed *= 1.1f;
                    else if (lmbpressed == 2)
                        chaingunspeed *= .1f;
                    newBullet.GetComponent<BulletShooting>().damage = 0.3f;
                    Object cloneBullet = GameObject.Instantiate(newBullet, new Vector3(100, 100, 100), transform.rotation);
                    Destroy(cloneBullet, 1 / newBullet.GetComponent<Transform>().localScale.x);
                    fireSound.Play();
                    chaingunfinishtime = Time.realtimeSinceStartup + (.3f / (animtr.speed));
                }
                else
                {
                    fireSound.Play();
                    firetime = Time.realtimeSinceStartup;
                    self.gameObject.tag = "Firing";
                    gameObject.SetActive(false);
                    gameObject.SetActive(true);
                    anim.wrapMode = WrapMode.Clamp; //using clamp allows the detection of the end of the animation to be more accurate
                    animtr.enabled = true;
                    anim.enabled = true;
                    //if (anim.clip.name("Fire") != null)
                    //anim.Play("Fire");

                    if (player.GetComponent<FireScript>().equippedweapon == 1)
                        newBullet.GetComponent<BulletShooting>().damage = 1.5f;
                    if (player.GetComponent<FireScript>().equippedweapon == 2)
                        newBullet.GetComponent<BulletShooting>().damage = 0.75f;
                    if (player.GetComponent<FireScript>().equippedweapon == 3)
                        newBullet.GetComponent<BulletShooting>().damage = 1;
                    if (player.GetComponent<FireScript>().equippedweapon == 5)
                        newBullet.GetComponent<BulletShooting>().damage = 5;
                    Object cloneBullet = GameObject.Instantiate(newBullet, new Vector3(100, 100, 100), transform.rotation);
                    if (player.GetComponent<FireScript>().equippedweapon == 5)
                    {
                        GameObject[] bulletslength = GameObject.FindGameObjectsWithTag("Bullet");
                        if (bulletslength.Length > 1)
                        {
                            Destroy(cloneBullet, 1);
                        }
                        playerrb.velocity /= 2;
                        Vector3 pvel = playerrb.velocity;
                        pvel.y += 5;
                        playerrb.velocity = pvel;


                    }
                    else
                    {
                        GameObject[] bulletslength = GameObject.FindGameObjectsWithTag("Bullet");
                        if (bulletslength.Length > 1)
                        {
                            Destroy(cloneBullet, 1);
                        }

                    }
                }

                
            }
            
            
            
        }
        else
        {
            
            if (animtr.enabled == true && anim.enabled == false)
            {
                //anim["Fire"].enabled = false;
                //animtr.enabled = false;
                //anim.enabled = false;
            }
            if (gameObject.name == "Chaingun" && Time.realtimeSinceStartup > Time.realtimeSinceStartup+chaingunspeed)
            {
                if (chaingunspeed > 0.1f)
                    chaingunspeed /= 2;
                else
                    chaingunspeed = 0.1f;
            }
            else
            {
                animtr.speed = 1;
            }
        }

    }

}
