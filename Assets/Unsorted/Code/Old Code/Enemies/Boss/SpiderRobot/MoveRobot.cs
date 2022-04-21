using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class MoveRobot : MonoBehaviour {
    public GameObject player; private Rigidbody explode; private GameObject explosion; private float shootTime;
    public float SpeedSlowness; public float TurnSlowness;  public GameObject brain;  public GameObject homingSpot;
    private float speed;    private float turnSpeed;    public GameObject headtarget;   public GameObject homingmissile;
    public GameObject head; private Vector3 robotPos; private float startuptime; Quaternion defaultRotate;
    private float shotUp; private float deathTime;  public AudioSource explodeSound;    private float landed;
    public AudioSource landSound;   public bool missiles;
    // Use this for initialization
    void Start () {
        shotUp = 0;
        shootTime = Time.realtimeSinceStartup + 1;
        startuptime = Time.realtimeSinceStartup;
        speed = 1;
        deathTime = 9000;
        defaultRotate = transform.rotation;
        turnSpeed = 1;
        turnSpeed /= TurnSlowness;
        landed = 1;
        if (GameObject.Find("Player") != null)
            player = GameObject.Find("Player");
    }

    // Update is called once per framew
    void Update()
    {
        if (player == null)
            player = Object.FindObjectOfType<Movement>().gameObject;
        if (Time.frameCount % 10 == 0)
            if (missiles)
            {
                GetComponent<Rigidbody>().velocity = (Vector3.MoveTowards(transform.position, player.transform.position, 15) - transform.position);
                if (shootTime < Time.realtimeSinceStartup && Time.realtimeSinceStartup > startuptime + 6)
                {
                    Object HomingMissile = GameObject.Instantiate(homingmissile, homingSpot.transform.position, homingSpot.transform.rotation);
                    shootTime = Time.realtimeSinceStartup + 2;
                }
            }
    }
}
