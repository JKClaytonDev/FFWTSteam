using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class doneShooting : MonoBehaviour {
    public bool fireMode;   public LineRenderer line;
    public Animator animController; public AudioClip[] gunSounds;
    public bool EnabledToggle;  public GameObject muzzle;   float enabledTime;
    private bool JustSwapped;   private float muzzleLight;
    public float fireTime;  public bool JustFired;  public bool[] crosshairSizeChange;
    public GameObject[] bullets;    public bool[] useProjectiles;
    public string[] bulletNames;    public float[] CrosshairSize; public GameObject bulletParticles; public GameObject ARParticles;
    public float[] weaponDamage;    private float focus;    public double[] SpeedDivisionFactor;
    public Sprite[] insideSprite; public Sprite[] outsideSprite;    public float[] bloom;
    public Vector3 bulletTarget; Vector3 bulletActivated;  float lastFire;   float weaponVolume;
    public float[] bulletSpeeds;    GameObject crosshair; GameObject crosshairOutside; GameObject playercrosshair;
    GameObject playerCamera;    bool camEnabled;   float lastWep;  GameObject Ccrosshair;  public float turnCOffset;
    bool fireToggle;    public bool toggledFirePlatform;        public GameObject othercrosshair;
    public AnimationEvent evt;  float scale;    bool retroLevel;    bool firedgr;
    // Use this for initialization
    void Start()
    {
        bulletSpeeds[4] = 1;
        retroLevel = SceneManager.GetActiveScene().name.Contains("Retro") || PlayerPrefs.GetInt("AllGuns") == 1;
        fireToggle = GameObject.FindObjectsOfType<FireToggle>().Length != 0;
        Ccrosshair = GameObject.Find("Crosshair");
        camEnabled = false;
        playerCamera = GameObject.Find("PlayerCamera");
        
        enabledTime = 0;
        scale = 1;
        evt.functionName = "Fire";
        EnabledToggle = false;
        fireTime = Time.realtimeSinceStartup;
        transform.position = GameObject.Find("PlayerSpawn").transform.position;
        if (!GetComponent<Movement>().retroMode)
        {
            playercrosshair = GameObject.Find("PlayerCrosshair");
            crosshair = GameObject.Find("Crosshair");
            crosshairOutside = GameObject.Find("CrosshairOutside");
            if (playercrosshair)
            playercrosshair.GetComponent<Image>().sprite = outsideSprite[4 - 1];
            crosshairOutside.GetComponent<Image>().sprite = insideSprite[4 - 1];
            crosshair.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        }
        
    }
    public void Fire()
    {
        fireMode = !fireMode;
        //if ((Input.GetMouseButton(0) || Input.GetAxis("Fire1") > 0))
        {
            if (fireToggle)
                toggledFirePlatform = !toggledFirePlatform;
            Vector3 oldPos = transform.position;
            Quaternion oldRot = transform.rotation;
            transform.rotation = GameObject.Find("PlayerCamera").transform.rotation;
            transform.Rotate(turnCOffset * (Ccrosshair.GetComponent<RectTransform>().localPosition.y / -50), 0, 0);
            if (Time.realtimeSinceStartup > fireTime)
            {
                if (animController.GetInteger("WeaponNum") - 1 >= 0 && animController.GetInteger("WeaponNum") - 1 <= GetComponent<Movement>().weaponAmmo.Length - 1)
                    if (GetComponent<Movement>().weaponAmmo[animController.GetInteger("WeaponNum") - 1] >= 0)
                {
                    if (animController.GetInteger("WeaponNum") == 9 && GetComponent<Movement>().jumps != 0 &&  GetComponent<Movement>().fireground)
                    {
                        GetComponent<Movement>().fireground = false;
                        transform.position -= transform.forward * 6;

                    }
                    if (!GetComponent<Movement>().retroMode)
                        GameObject.Find("PlayerCrosshair").GetComponent<Animator>().Play("crosshairFire", -1, 0f);
                    float audioVolume = 0;
                    if (lastFire + 0.2f < Time.realtimeSinceStartup)
                        audioVolume = 1;
                    else if (lastFire + 0.5f < Time.realtimeSinceStartup)
                        audioVolume = 0.9f;
                    else
                        audioVolume = 0f;
                    GetComponent<AudioSource>().pitch = Random.Range(0.95f, 1.05f);
                    GetComponent<AudioSource>().PlayOneShot(gunSounds[animController.GetInteger("WeaponNum") - 1], audioVolume);
                    EnabledToggle = true;
                    animController.SetBool("IsFiring", false);
                    animController.SetBool("IsAltFire", false);
                    animController.SetBool("Switched", false);
                    fireTime = Time.realtimeSinceStartup + 0.2f;
                    GetComponent<Movement>().weaponAmmo[animController.GetInteger("WeaponNum") - 1]--;
                    if (useProjectiles[animController.GetInteger("WeaponNum") - 1])
                    {
                        for (int i = 0; i < bullets[animController.GetInteger("WeaponNum") - 1].GetComponent<moveBullet>().ExtraBullets + 1; i++)
                        {

                                bullets[animController.GetInteger("WeaponNum") - 1].transform.position = transform.position;
                            GameObject bullet = Instantiate(bullets[animController.GetInteger("WeaponNum") - 1], transform);
                            bullet.SetActive(true);
                            bullet.GetComponent<moveBullet>().speed = bulletSpeeds[animController.GetInteger("WeaponNum") - 1];
                            if (bullet.GetComponent<TrailRenderer>() != null)
                            {
                                bullet.GetComponent<TrailRenderer>().enabled = false;
                                bullet.GetComponent<TrailRenderer>().enabled = true;
                            }
                            bullet.GetComponent<Rigidbody>().velocity = 100 * transform.forward;
                            if (SceneManager.GetActiveScene().name != "BossFight")
                            Destroy(bullet, 2);
                            else
                                Destroy(bullet, 9);
                        }
                    }
                    else
                    {
                        Quaternion oldRotate = transform.rotation;
                        Vector3 linePos;
                            bool isTesla = false;
                        for (int i = 0; i < (2 * bullets[animController.GetInteger("WeaponNum") - 1].GetComponent<moveBullet>().ExtraBullets) + 1; i ++)
                        {
                            GetComponent<LineRenderer>().SetPosition(0, muzzle.transform.position);
                            linePos = GetComponent<Movement>().raycast();
                            transform.Rotate(new Vector3(0, Random.Range(-1 * bloom[animController.GetInteger("WeaponNum") - 1], bloom[animController.GetInteger("WeaponNum") - 1]), 0));
                            GetComponent<LineRenderer>().SetPosition(1, linePos);
                            bulletTarget = linePos;

                                GameObject copy = bulletParticles;
                            
                                if (animController.GetInteger("WeaponNum") == 7 && Input.GetMouseButton(1))
                                {
                                    isTesla = true;
                                    copy = ARParticles;
                                }

                                GameObject particles = Instantiate(copy, null);
                                particles.transform.parent = null;
                            particles.transform.SetParent(null);
                            particles.transform.rotation = transform.rotation;
                            particles.transform.Rotate(new Vector3(0, Random.Range(-1 * bloom[animController.GetInteger("WeaponNum") - 1], bloom[animController.GetInteger("WeaponNum") - 1]), 0));
                            if (animController.GetInteger("WeaponNum") == 1)
                                particles.transform.position = transform.position;
                            else
                                particles.transform.position = muzzle.transform.position;
                            if (particles.GetComponent<bulletFlash>())
                            {
                                    particles.GetComponent<bulletFlash>().retro  = retroLevel;
                                particles.GetComponent<bulletFlash>().setPlayer(gameObject);
                                particles.GetComponent<bulletFlash>().bulletTarget = bulletTarget;
                                    particles.GetComponent<bulletFlash>().speed = 25;
                                    if (!isTesla)
                                particles.GetComponent<bulletFlash>().speed = bulletSpeeds[animController.GetInteger("WeaponNum") - 1];
                                particles.GetComponent<bulletFlash>().setVel();
                            }
                                if (isTesla)
                                {
                                    
                                }
                                if (SceneManager.GetActiveScene().name == "BossFight")
                                Destroy(particles, 9);
                            else
                                Destroy(particles, 3);
                            if (GetComponent<Movement>().enemyTargeted)
                                GetComponent<Movement>().KillEnemy();
                            else
                            {
                                GameObject force = Instantiate(GameObject.Find("BulletFlash"));
                                force.SetActive(false);
                                force.SetActive(true);
                                force.transform.position = GetComponent<Movement>().flashHitPoint;
                                force.GetComponent<AutoDestroy2>().enabled = true;
                            }
                            transform.rotation = oldRotate;
                        }
                        animController.SetBool("IsFiring", false);
                        animController.SetBool("IsAltFire", false);
                            
                    }
                }
                else
                {
                    GetComponent<Movement>().animController.SetInteger("WeaponNum", 4);
                }
            }
            transform.rotation = oldRot;
        }
}

}
