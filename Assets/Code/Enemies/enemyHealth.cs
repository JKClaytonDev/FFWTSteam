using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enemyHealth : MonoBehaviour {
    public float startingHealth;    public float Currenthealth;
    public bool isInitialized;  public string enemyClass;   public bool DontaddBonesandRigid;
    public double[] weaponDamages; float originalChildren;  public bool nofallDamage; GameObject player;
    public GameObject stunAnim; public bool cancelKillVelocity; public bool raw;    public float lastHitTime;
    bool done;  float startY; float difficulty; public Vector3 start; musicHost host;
    public Material seeThroughWall; public MeshRenderer[] rends;
    public bool instaDestroy;
    // Use this for initialization
    void Update()
    {
        if (Currenthealth < 0.08 && instaDestroy)
            Destroy(gameObject);
            if (transform.position.y < startY - 500)
            {
                Destroy(gameObject);
                Debug.Log("FELL");
            }
        if (host && Time.frameCount % 10 == 0)
        {
            if (player)
            {
                float dist = Vector3.Distance(transform.position, player.transform.position);
                if (dist > 5000)
                    Destroy(gameObject);
                if (dist < 315)
                {
                    host.foundTime = Time.realtimeSinceStartup;
                    if (dist < 115)
                    {
                        host.nowTime = Time.realtimeSinceStartup;
                    }
                }
            }
            else
            {
                player = FindObjectOfType<Movement>().gameObject;
            }
        }

    }

        void OnCollisionStay(Collision collision)
        {
        if (collision.gameObject.GetComponent<bulletFlash>())
        {
            FindObjectOfType<Movement>().KillEnemy(this.gameObject, collision.gameObject);
        }
    }
    void Start()
    {
        foreach (MeshRenderer m in rends)
        {
            m.material = seeThroughWall;
        }
        startY = transform.position.y;
        start = transform.position;
        player = FindObjectOfType<Movement>().gameObject;
        host = FindObjectOfType<musicHost>();
        
        //if (PlayerPrefs.GetString("Mode") == "Easy")
        //    difficulty = 0.5f;
        //else if (PlayerPrefs.GetString("Mode") == "Normal" || PlayerPrefs.GetString("Mode") == "One Life" || PlayerPrefs.GetString("Mode") == "One Shot" || PlayerPrefs.GetString("Mode") == "Classic")
            difficulty = 1;
        //else
         //   difficulty = 1.5f;



        startY = transform.position.y;
        if (weaponDamages.Length == 10) {
            double[] newDamages = new double[11];
            for (int i = 0; i < weaponDamages.Length; i++)
                newDamages[i] = weaponDamages[i];
            newDamages[10] = newDamages[3];
            newDamages[3] *= 3;
            weaponDamages = newDamages;
            }
        done = false;
        gameObject.layer = 16;
        gameObject.tag = "Enemy";
        isInitialized = false;
        if (startingHealth < 1)
        {
            startingHealth = 3;
        }
        if (enemyClass == null)
            enemyClass = "Robot";

        Currenthealth = startingHealth;

        originalChildren = 0;
        foreach (Transform t in transform)
        {
            originalChildren++;
        }

        float currentChildren = 0;
        foreach (Transform t in transform)
        {
            currentChildren++;
        }
        if (currentChildren < originalChildren)
        {
            foreach (Transform t in transform)
            {
                t.gameObject.tag = "dead";
            }
            gameObject.tag = "dead";
        }

        /*
        if (PlayerPrefs.GetString("Mode") == "One Shot")
        {
            for (int i = 0; i < weaponDamages.Length; i++)
                weaponDamages[i] = 9999;
        }
        if (PlayerPrefs.GetString("Mode") == "Easy")
        {
            for (int i = 0; i < weaponDamages.Length; i++)
                weaponDamages[i] *= 1.5f;
        }
        if (PlayerPrefs.GetString("Mode") == "Hard")
        {
            for (int i = 0; i < weaponDamages.Length; i++)
                weaponDamages[i] /= 1.5f;
        }
         */

        
    }
    void FixedUpdate()
    {
        if (!nofallDamage && Time.frameCount%480 == 0 && SceneManager.GetActiveScene().name != "BossFight")
        {
            if (Mathf.Abs(startY - transform.position.y) > 75)
            {
                Debug.Log("FELL");
                Destroy(gameObject);
            }
        }
    }


}
