using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    //Declaring Variables
    [HideInInspector] public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 };
    [HideInInspector] public RotationAxes axes = RotationAxes.MouseXAndY; public GameObject explosion;
    [HideInInspector] public float sensitivityX = 15F;[HideInInspector] public float sensitivityY = 15F;[HideInInspector] public float minimumX = -360F;[HideInInspector] public float startuptime;
    [HideInInspector] public float minimumY = -60F;[HideInInspector] public float maximumY = 60F; float rotationY = 0F; float rotationX = 0F;[HideInInspector] public float maximumX = 360F;[HideInInspector] public float PlayerHealth;
    [HideInInspector] public Animator animController; public float speed;[HideInInspector] public float jumps; Vector3 prevVelocity;
    GameObject GlobalControl; private float JumpTime; private bool canDoit; private float JumpStreak; private float startYpos; public int enemyCount;
    private float slowness; private float lastDelta; private int ScrollCount; private float delay; private Vector2 blackboxtarget; public GameObject damageText;
    [HideInInspector] public bool switchBack; private int tempLastweapon; private float jumptime; private Vector3 outsideVelocity; GameObject crosshairOutside;
    [HideInInspector] public Vector3 hitPoint; private Animator stopWatch; private GameObject leftUzi; private GameObject leftHand; private Vector2 blackboxcurrent;
    public GameObject[] weaponModels; private GameObject BoxCollider;[HideInInspector] private bool isGrounded;[HideInInspector] public float playerHealth;
    private Vector3 introcurrent; private Vector3 introtarget; private float escStage; private bool escPressed; private bool tb; private bool bb; private bool quitb;
    private float mouseXratio; private float mouseYratio; private float lastWep; string topB; string bottomB; string middleB; float lastPistol;
    private GameObject health; private GameObject ammo;[HideInInspector] public float HitTime; public float[] weaponAmmo; private float Ammp; public bool enemyTargeted;
    [HideInInspector] public AudioClip hitSound;[HideInInspector] public AudioClip killSound; private float lastWeapon; bool GrappledYet; GameObject enemyname; int lastButtonPressed;
    [HideInInspector] public int nextWeapon; private bool Enemiesdisabled; private bool JustSwitched; private Vector3 slide; private GameObject EnemyGameObject; Vector3 ePos;
    [HideInInspector] public bool justSlid; private float slideTime; private Vector3 newPos; private float Ammo; private Vector3 moveF; Ray ray5; public doneShooting doneShot;
    private bool forwardVell; private Vector3 airDirection; private float airLength; bool upPressed; public float StartY; float healthBarTargetY; private Vector3 targetPoint;
    bool downPressed; bool leftPressed; bool rightPressed; public AudioClip jumpSound; private SpriteRenderer Crosshair;[HideInInspector] public Vector3 flashHitPoint;
    public bool SuperBoots; public bool GrappleHook; private float rotateOffsetcount;[HideInInspector] public bool Sliding; private float rotX; private Quaternion Oldrot;
    public Animator CameraJumping; public Vector3 extraSpeed; public float startupTime; public bool[] equippedWeapons; private Rigidbody PlayerRigidBody; public GameObject EdamageText;
    public bool ClassicControls; public bool oldMovement; public GameObject particleExplosion;[HideInInspector] public float jumpSpeed; private float lastJumps; private float speedMultiplier = 1;
    bool spaceUp; public float[] PlayerOriginalAmmo; SphereCollider sphcollide; bool scanRefresh; public GameObject ForceExample; Animator wepCamera; AudioSource colliderSource; GameObject playerCrosshair;
    RectTransform crosshairObject; weaponsCamera wepcameraOffset; GameObject wepCameraobj; public GameObject enemySparks; public Vector3 transPos; GameObject enemyHealthh; public GameObject totalHealth;
    float lastAmmo; float lastTime; float lastEnemies; float lastHealth; string lastLevel; bool camdisabled; float lastEquippedWep; GameObject playerSpawn; float wintime; Vector3 kickMove;
    public bool retroMode; public bool Intro; public float crosshairOffset; private GameObject Ccrosshair; GameObject playerCamera; bool graphicsOptions; public AudioClip kickSound;
    private GUIStyle labelText = new GUIStyle(); private GUIStyle button = new GUIStyle(); private GUIStyle button2 = new GUIStyle(); private GUIStyle quitbutton = new GUIStyle(); Vector3 lastPos; Vector3 lastVel;
    private GUIStyle numText = new GUIStyle(); GameObject hitMarker; public GameObject menuEnabled; public float speedBoost; public float enemycount; public LayerMask enemylayer;
    private GUIStyle winText = new GUIStyle(); public bool loadLevel; float lookAtEnemyRatio; Vector3 targetPos; public GameObject legAnimObj; Animator legAnim; Vector3 targetRot;
    public string[] gunAnims;
    public float gravity = 3f; public float ground_accelerate = 50f; public float max_velocity_ground = 4f; public float air_accelerate = 150f;
    public float max_velocity_air = 2f; public float friction = 8; bool onGround; public float jump_force = 5f;
    private Vector3 lastFrameVelocity = Vector3.zero; public Camera camObj; Rigidbody rb; public BoxCollider coll;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        legAnim = legAnimObj.GetComponent<Animator>();
        lookAtEnemyRatio = 0;
        loadLevel = GameObject.Find("LevelPortal");
        speedBoost = 1;
        lastPistol = 0;
        menuEnabled = GameObject.Find("PauseMenuGameMask");
        lastButtonPressed = 0;
        topB = "Low";
        middleB = "Medium";
        bottomB = "High";
        hitMarker = GameObject.Find("PMarker");
        playerCamera = GameObject.Find("PlayerCamera");
        Ccrosshair = GameObject.Find("Crosshair");
        if (Intro)
            transform.position = new Vector3(137.894f, 646, 577.79f);
        GetComponent<Animator>().SetBool("RetroMode", retroMode);
        wintime = 0;
        playerSpawn = GameObject.Find("LevelPortal");
        enemyCount = 100;
        if (!retroMode)
        {
            crosshairOutside = GameObject.Find("CrosshairOutside");
            enemyname = GameObject.Find("EnemyName");
            playerCrosshair = GameObject.Find("PlayerCrosshair");
            crosshairObject = GameObject.Find("PlayerCrosshair").GetComponent<RectTransform>();
            totalHealth = GameObject.Find("TotalHealth");
            enemyHealthh = GameObject.Find("EnemyHealthBar");
        }
        button.normal.textColor = Color.white;
        button.fontStyle = FontStyle.Bold;
        button.fontSize = 50;
        button2.normal.textColor = Color.white;
        button2.fontStyle = FontStyle.Bold;
        button2.fontSize = 50;
        quitbutton.normal.textColor = Color.white;
        quitbutton.fontStyle = FontStyle.Bold;
        quitbutton.fontSize = 100;
        GUIStyle labelText = new GUIStyle();
        GUIStyle numText = new GUIStyle();
        labelText.fontSize = 20;
        numText.fontSize = 50;
        winText.alignment = TextAnchor.MiddleCenter;
        winText.fontSize = 50;
        labelText.fontStyle = FontStyle.Bold;
        labelText.fontSize = 20;
        numText.fontSize = 50;
        labelText.fontStyle = FontStyle.Bold;
        CameraJumping.SetBool("Standing", true);
        colliderSource = GameObject.Find("PlayerCollider").GetComponent<AudioSource>();
        doneShot = GetComponent<doneShooting>();
        GetComponent<SphereCollider>().enabled = true;
        sphcollide = GetComponent<SphereCollider>();
        PlayerRigidBody = GetComponent<Rigidbody>();
        if (retroMode)
        {
            if (GameObject.Find("RetroPlayerSpawn") != null)
                StartY = GameObject.Find("RetroPlayerSpawn").transform.position.y;
            else
                StartY = transform.position.y;
        }
        else
        {
            if (GameObject.Find("PlayerSpawn") != null)
                StartY = GameObject.Find("PlayerSpawn").transform.position.y;
            else
                StartY = transform.position.y;
        }

        for (int i = 0; i < PlayerOriginalAmmo.Length; i++)
        {
            PlayerOriginalAmmo[i] = weaponAmmo[i];
        }
        spaceUp = false;

        startupTime = Time.realtimeSinceStartup;
        JumpStreak = 1;
        animController = GetComponent<Animator>();
        leftHand = GameObject.Find("Hand");
        leftUzi = GameObject.Find("UziL");
        BoxCollider = GameObject.Find("PlayerCollider");
        escStage = 1;
        if (retroMode)
        {
            if (GameObject.Find("RetroPlayerSpawn") != null)
                transform.position = GameObject.Find("RetroPlayerSpawn").transform.position;
        }
        else
        {
            if (GameObject.Find("PlayerSpawn") != null)
                transform.position = GameObject.Find("PlayerSpawn").transform.position;
        }
        JumpTime = 0;
        airLength = 0;
        HitTime = 0;
        if (!retroMode)
        {
            ammo = GameObject.Find("AmmoGUI");
            health = GameObject.Find("HPGUI");
        }
        PlayerHealth = 100;
        startuptime = Time.realtimeSinceStartup;
        tempLastweapon = 1;
        JumpTime = Time.realtimeSinceStartup;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        ;
        animController.SetFloat("WeaponNum", 11);
        coll = BoxCollider.GetComponent<BoxCollider>();
    }
    void Update()
    {

        if (Time.timeScale != 0)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            if (!retroMode)
                rotationY += Input.GetAxisRaw("Mouse Y") * sensitivityY * Time.fixedDeltaTime * 15;
            else if (animController.GetInteger("WeaponNum") != 9)
            {
                animController.SetInteger("WeaponNum", 9);
                animController.SetBool("Switched", true);
            }

            rotationX += Input.GetAxisRaw("Mouse X") * sensitivityY * Time.fixedDeltaTime * 15;

            if (lookAtEnemyRatio == 0)
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            else
            {
                /*
                Vector3 rot = new Vector3(-rotationY, rotationX, 0);
                transform.position = Vector3.MoveTowards(transform.position, targetPos, 10);
                transform.Rotate((transform.eulerAngles * lookAtEnemyRatio) + (targetRot * (1 - lookAtEnemyRatio)) - transform.localEulerAngles);
                //transform.eulerAngles = (transform.eulerAngles * lookAtEnemyRatio) + (targetRot * (1 - lookAtEnemyRatio));
                */
                kickMove = Vector3.MoveTowards(kickMove, targetPos, 2);
                Vector3 fm = kickMove;
                fm.y = transform.position.y;
                Vector3 tp = targetPos;
                tp.y = transform.position.y;
                Vector3 ep = ePos;
                ep.y = transform.position.y;
                Vector3 fw = Vector3.MoveTowards(fm, ep, 2);
                transform.position = fm;
                transform.LookAt(fw);
                if (kickMove == targetPos)
                    lookAtEnemyRatio = 0;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


    }
    void FixedUpdate()
    {
        //Movement
        //transPos += 
        //Vector3 accelDir = Time.fixedDeltaTime * 60 * speedBoost * 45 * ((rot * Vector3.right) * Input.GetAxis("Horizontal") + (rot * Vector3.forward) * Input.GetAxis("Vertical")) / (52 / 1 + (JumpStreak / 9) + speedMultiplier);
        Moving();
        transform.position += prevVelocity;
        lastPos = transform.position;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Quaternion oldQuat = transform.rotation;
            Vector3 oldrot = transform.localEulerAngles;
            Collider[] enemies = Physics.OverlapSphere(transform.position, 40, enemylayer);
            Ray rwj = new Ray(transform.position, Vector3.down);
            if (enemies.Length >= 1)
            {
                bool done = false;
                foreach (Collider e in enemies)
                {
                    if (!done)
                    {
                        kickMove = transform.position;
                        ePos = e.transform.position;
                        colliderSource.PlayOneShot(kickSound, 1);
                        if (Physics.Raycast(rwj, 15))
                        {
                            legAnim.Play("interruptKick");
                            targetPos = transform.up * 3 + e.transform.position - transform.forward * 23;
                        }
                        else
                        {
                            legAnim.Play("interruptAirKick");
                            targetPos = e.transform.position - transform.forward * 13;
                        }

                        lookAtEnemyRatio = 1;
                        DestroyEnemy(e.gameObject);
                        Time.timeScale = 0.4f;

                        done = true;
                    }

                }
            }
            else
            {
                if (Physics.Raycast(rwj, 15))
                    legAnim.Play("slide");
                else
                    legAnim.Play("kick");
            }
            transform.localEulerAngles = oldrot;
            transform.rotation = oldQuat;
        }
        if (Time.timeScale > 0 && Time.timeScale < 1)
            Time.timeScale += (1 - Time.timeScale) / 20;
        if (Time.realtimeSinceStartup < startuptime + 10)
            playerHealth = 100;
        if (Time.timeScale > 0.95)
            Time.timeScale = 1;

        if (!loadLevel && Time.frameCount % 120 == 0)
        {
            Object[] enemies = GameObject.FindObjectsOfType<enemyHealth>();
            enemycount = enemies.Length;
            if (enemycount < 10)
            {
                //foreach(GameObject g in enemycount)

            }
            if (enemies.Length == 0)
            {   /*if (GameObject.Find("LoadLevel") != null)
                {
                    GameObject.Find("LoadLevel").GetComponent<LevelLoader>().loading = true;
                    if (GameObject.Find("LoadLevel"))
                        DontDestroyOnLoad(GameObject.Find("LoadLevel"));
                    GameObject.Find("LoadLevel").GetComponent<LevelLoader>().backGround.GetComponent<AnimatorReadyIntro>().enabled = false;
                    GameObject.Find("LoadLevel").GetComponent<LevelLoader>().LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
                    enabled = false;
                }
                else
                */
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        /*
        Vector3 vel = PlayerRigidBody.velocity;
        if (Mathf.Abs(vel.x) > 15)
            vel.x = 15 * vel.x / Mathf.Abs(vel.x);
        if (Mathf.Abs(vel.z) > 15)
            vel.z = 15 * vel.z / Mathf.Abs(vel.z);
        if (Mathf.Abs(vel.y) > 25)
            vel.y = 25 * vel.y / Mathf.Abs(vel.y);
        PlayerRigidBody.velocity = vel;

        vel = extraSpeed;
        if (Mathf.Abs(vel.x) > 15)
            vel.x = 15 * vel.x / Mathf.Abs(vel.x);
        if (Mathf.Abs(vel.z) > 15)
            vel.z = 15 * vel.z / Mathf.Abs(vel.z);
        if (Mathf.Abs(vel.y) > 25)
            vel.y = 25 * vel.y / Mathf.Abs(vel.y);
        extraSpeed = vel;
        */
        animController.SetBool("IsAltFire", Input.GetMouseButton(1));
        if (Time.timeScale != 0)
        {

            if (lastEquippedWep != animController.GetInteger("WeaponNum") - 1)
            {
                for (int i = 0; i < weaponModels.Length; i++)
                {
                    if (weaponModels[i] != null)
                        weaponModels[i].SetActive(i == animController.GetInteger("WeaponNum") - 1);
                }

                lastEquippedWep = animController.GetInteger("WeaponNum") - 1;
            }
            if (!retroMode)
                GetComponent<Animator>().SetBool("Move", jumps == 0 && (Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")) > 0));
            transPos = transform.position + extraSpeed;
            Quaternion rot = transform.rotation;
            rot.x = 0;
            rot.z = 0;

            /*
            CameraJumping.SetBool("Jumping", jumps != 0);
            if (jumps < 2)
            {
                if (jumps == 0)
                {
                    extraSpeed /= 1.1f;
                    jumpSpeed /= 1.1f;
                    if (lastJumps != jumps)
                    {
                        if ((Input.GetKey("a") || Input.GetKey("d")) && (Input.GetKey("w") || Input.GetKey("s")))
                            JumpStreak += Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")) / 15;
                        else
                            JumpStreak = 0;
                        lastJumps = jumps;
                    }

                    jumpSpeed += 0.1f;
                }
                if ((Input.GetKey(KeyCode.Space) && PlayerRigidBody.velocity.y == 0) || (Input.GetKeyDown(KeyCode.Space) && spaceUp))
                {
                    jumptime = Time.realtimeSinceStartup + 0.1f;
                    colliderSource.PlayOneShot(jumpSound, 1);
                    JumpTime = Time.realtimeSinceStartup + 0.2f;
                    jumps++;
                    PlayerRigidBody.velocity += new Vector3(0, 20, 0)*speedBoost;
                }
            }
            */
            spaceUp = !Input.GetKey(KeyCode.Space);
            Ammo = weaponAmmo[animController.GetInteger("WeaponNum") - 1];
            animController.SetBool("mouseDown", (Input.GetMouseButtonDown(0) && doneShot.fireTime < Time.realtimeSinceStartup && weaponAmmo[animController.GetInteger("WeaponNum") - 1] > 1));

            if ((Input.GetMouseButton(0) || Input.GetAxis("Fire1") > 0) && weaponAmmo[animController.GetInteger("WeaponNum") - 1] > 1)
            {
                animController.SetBool("Switched", true);
                rotateOffsetcount = 0;
            }
            animController.SetBool("IsFiring", (Input.GetMouseButton(0) || Input.GetAxis("Fire1") > 0) && weaponAmmo[animController.GetInteger("WeaponNum") - 1] > 1);
            {
                bool switched = true;

                if (Input.GetKeyDown("1"))
                {
                    animController.SetInteger("WeaponNum", 4);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;

                    animController.enabled = false;
                    animController.enabled = true;

                    switched = true;
                    lastPistol = 0;
                }
                if (Input.GetKeyDown("2") && equippedWeapons[6])
                {
                    animController.SetInteger("WeaponNum", 6);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;

                    animController.enabled = false;
                    animController.enabled = true;

                    switched = true;
                }
                if (Input.GetKeyDown("3") && equippedWeapons[9])
                {
                    animController.SetInteger("WeaponNum", 9);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;

                    animController.enabled = false;
                    animController.enabled = true;

                    switched = true;
                }
                if (Input.GetKey("4") && equippedWeapons[7] || nextWeapon == 7)
                {
                    animController.SetInteger("WeaponNum", 7);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;

                    animController.enabled = false;
                    animController.enabled = true;

                    switched = true;
                }
                if (Input.GetKey("5") && equippedWeapons[1] || nextWeapon == 1)
                {
                    animController.SetInteger("WeaponNum", 1);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;
                    animController.enabled = false;
                    animController.enabled = true;

                    switched = true;
                }
                if (Input.GetKey("6") && equippedWeapons[3] || nextWeapon == 3)
                {
                    animController.SetInteger("WeaponNum", 3);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;
                    animController.enabled = false;
                    animController.enabled = true;

                    switched = true;
                }
                if (Input.GetKey("7") && equippedWeapons[5] || nextWeapon == 5)
                {
                    animController.SetInteger("WeaponNum", 5);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;
                    animController.enabled = false;
                    animController.enabled = true;

                    switched = true;
                }
                if (Input.GetKey("8") && equippedWeapons[10] || nextWeapon == 10)
                {
                    animController.SetInteger("WeaponNum", 10);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;
                    animController.enabled = false;
                    animController.enabled = true;

                    switched = true;
                }
                if (Input.GetKey("v"))
                {
                    animController.SetInteger("WeaponNum", 8);
                    animController.SetBool("Switched", true);
                    animController.SetBool("IsFiring", true);
                    animController.enabled = false;
                    animController.enabled = true;
                    switched = true;
                }
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    for (int i = animController.GetInteger("WeaponNum") + 1; i < equippedWeapons.Length; i++)
                    {
                        if (equippedWeapons[i])
                        {
                            animController.SetInteger("WeaponNum", i);
                            animController.SetBool("Switched", true);
                            animController.enabled = false;
                            animController.enabled = true;
                            switched = true;
                            i = 500;
                        }
                    }

                }
                if (Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    for (int i = animController.GetInteger("WeaponNum") - 1; i > 0; i--)
                    {
                        if (equippedWeapons[i])
                        {
                            animController.SetInteger("WeaponNum", i);
                            animController.SetBool("Switched", true);
                            animController.enabled = false;
                            animController.enabled = true;
                            switched = true;
                            i = -500;
                        }
                    }

                }
            }
            if (!playerCamera.GetComponent<CameraIntro>().enabled)
            {
                if (Ccrosshair.GetComponent<RectTransform>().localPosition.y != -50)
                {
                    hitMarker.GetComponent<RectTransform>().localPosition = Ccrosshair.GetComponent<RectTransform>().localPosition;
                    playerCamera.transform.position = transform.position + transform.up * (crosshairOffset * (Ccrosshair.GetComponent<RectTransform>().localPosition.y + 50));
                    playerCamera.transform.rotation = transform.rotation;
                    playerCamera.transform.Rotate((15 * (Ccrosshair.GetComponent<RectTransform>().localPosition.y + 50) / 50), 0, 0);
                    playerCamera.GetComponent<Camera>().fieldOfView = 90 - (Ccrosshair.GetComponent<RectTransform>().localPosition.y + 50) / 50 * 15;
                }
                else
                {
                    playerCamera.transform.rotation = transform.rotation;
                }

                if (!retroMode && !Intro)
                {
                    crosshairOutside.SetActive(true);
                    playerCrosshair.SetActive(true);
                    crosshairObject.GetComponent<Image>().color = Color.white;
                    playerCrosshair.GetComponent<Image>().color = crosshairObject.GetComponent<Image>().color;
                    scanRefresh = false;
                }
                if (StartY - 180 > transPos.y && StartY != 0 && !camdisabled)
                {
                    playerCamera.transform.parent = null;
                    playerCamera.AddComponent<LookAt>();
                    playerCamera.GetComponent<Animator>().enabled = false;
                    camdisabled = true;
                }
            }

            if ((StartY - 230 > transPos.y || StartY + 230 < transPos.y) && StartY != 0 && !Intro || PlayerHealth < 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            transform.position = transPos;
        }

        if (PlayerHealth < 1 && !Intro)
        {
            PlayerHealth = 100;
            /*
            if (GameObject.Find("LoadLevel") != null)
            {
                GameObject.Find("LoadLevel").GetComponent<LevelLoader>().loading = true;
                if (GameObject.Find("LoadLevel"))
                    DontDestroyOnLoad(GameObject.Find("LoadLevel"));
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            */
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    public Vector3 raycast()
    {
        return transform.position - (playerCamera.transform.position - transform.position) + transform.forward * 100;
    }

    public void KillEnemy()
    {
        KillEnemy(EnemyGameObject);
    }
    void Moving()
    {

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 tempVelocity = CalculateFriction(rb.velocity);

        tempVelocity += CalculateMovement(input, tempVelocity);

        rb.velocity = tempVelocity;

        lastFrameVelocity = rb.velocity;

        rb.velocity += new Vector3(0f, -gravity, 0f) * Time.deltaTime;

    }

    public Vector3 CalculateFriction(Vector3 currentVelocity)
    {
        onGround = Grounded();
        float speed = currentVelocity.magnitude;
        
        if (!onGround || Input.GetKey(KeyCode.Space) || speed == 0f)
            return currentVelocity;

        float drop = speed * friction * Time.deltaTime;
        return currentVelocity * (Mathf.Max(speed - drop, 0f) / speed);
    }

    //Do movement input here
    public Vector3 CalculateMovement(Vector2 input, Vector3 velocity)
    {
        onGround = Grounded();

        //Different acceleration values for ground and air
        float curAccel = ground_accelerate;
        if (!onGround)
            curAccel = air_accelerate;

        //Ground speed
        float curMaxSpeed = max_velocity_ground;

        //Air speed
        if (!onGround)
            curMaxSpeed = max_velocity_air;


        //Get rotation input and make it a vector
        Vector3 camRotation = new Vector3(0f, camObj.transform.rotation.eulerAngles.y, 0f);
        Vector3 inputVelocity = Quaternion.Euler(camRotation) *
            new Vector3(input.x * air_accelerate, 0f, input.y * air_accelerate);

        //Ignore vertical component of rotated input
        Vector3 alignedInputVelocity = new Vector3(inputVelocity.x, 0f, inputVelocity.z) * Time.deltaTime;

        //Get current velocity
        Vector3 currentVelocity = new Vector3(velocity.x, 0f, velocity.z);

        //How close the current speed to max velocity is (1 = not moving, 0 = at/over max speed)
        float max = Mathf.Max(0f, 1 - (currentVelocity.magnitude / curMaxSpeed));

        //How perpendicular the input to the current velocity is (0 = 90°)
        float velocityDot = Vector3.Dot(currentVelocity, alignedInputVelocity);

        //Scale the input to the max speed
        Vector3 modifiedVelocity = alignedInputVelocity * max;

        //The more perpendicular the input is, the more the input velocity will be applied
        Vector3 correctVelocity = Vector3.Lerp(alignedInputVelocity, modifiedVelocity, velocityDot);

        //Apply jump
        correctVelocity += GetJumpVelocity(velocity.y);

        //Return
        return correctVelocity;
    }

    private Vector3 GetJumpVelocity(float yVelocity)
    {
        Vector3 jumpVelocity = Vector3.zero;

        //Calculate jump
        if (Input.GetKey(KeyCode.Space) && yVelocity < jump_force && Grounded())
        {
            Debug.Log("Jumping");
            jumpVelocity = new Vector3(0f, jump_force - yVelocity, 0f);
        }

        return jumpVelocity;
    }


    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, coll.bounds.extents.y + 0.1f);
    }
    public void KillEnemy(GameObject collision)
    {
        if (retroMode)
        {
            Destroy(collision.gameObject);
        }
        else
        {
            bool customDamage = false;
            if (collision.GetComponent<enemyHealth>())
            {
                if (Time.realtimeSinceStartup > colliderSource.GetComponent<enemyHealth>().lastHitTime)
                    colliderSource.GetComponent<enemyHealth>().lastHitTime = Time.realtimeSinceStartup + 0.1f;
                else
                    return;
                float original = collision.GetComponent<enemyHealth>().Currenthealth;
                collision.GetComponent<enemyHealth>().Currenthealth -= Mathf.Abs((float)(collision.GetComponent<enemyHealth>().startingHealth * ((collision.GetComponent<enemyHealth>().weaponDamages[animController.GetInteger("WeaponNum") - 1]))));
                float newF = collision.GetComponent<enemyHealth>().Currenthealth;
                if (newF < 0)
                    newF = 0;

                if (!customDamage && collision.GetComponent<enemyHealth>() != null)
                {
                    if (collision.GetComponent<enemyHealth>().stunAnim != null)
                    {
                        if (collision.GetComponent<enemyHealth>().stunAnim.GetComponent<Animator>())
                            collision.GetComponent<enemyHealth>().stunAnim.GetComponent<Animator>().SetBool("hit", true);

                        GameObject force = Instantiate(enemySparks);
                        force.SetActive(false);
                        force.SetActive(true);
                        force.transform.position = collision.transform.position;
                        force.GetComponent<AutoDestroy2>().enabled = true;
                    }

                    if (collision.GetComponent<enemyHealth>().Currenthealth < 0.1f)
                    {
                        if (PlayerHealth < 75)
                        {
                            PlayerHealth += 1 * (2 - collision.GetComponent<enemyHealth>().Currenthealth);
                            if (PlayerHealth > 75)
                                PlayerHealth = 75;
                        }
                        if (collision.GetComponent<enemyHealth>().DontaddBonesandRigid)
                            Destroy(collision.gameObject);
                        else
                        {
                            if (!retroMode)
                                GameObject.Find("HitMarker").GetComponent<Animator>().Play("HitMarker", -1, 0f);

                            {

                                var go = collision.gameObject;
                                var allChildren = go.GetComponentsInChildren<Transform>();
                                foreach (Transform childTrans in allChildren)
                                {

                                    GameObject child = childTrans.gameObject;
                                    child.tag = "dead";

                                    MonoBehaviour[] comps = child.GetComponents<MonoBehaviour>();
                                    foreach (MonoBehaviour c in comps)
                                    {
                                        if (c != child.GetComponent<killEnemy>() && c != child.GetComponent<Renderer>() && c != child.GetComponent<Material>())
                                            c.enabled = false;
                                    }

                                    if (child.GetComponent<Animator>() != null)
                                        child.GetComponent<Animator>().enabled = false;
                                    if (child.GetComponent<BoxCollider>() != null)
                                    {
                                        child.GetComponent<BoxCollider>().size /= 2;
                                        //child.GetComponent<BoxCollider>().enabled = false;
                                    }

                                    child.name = "Dead";
                                    child.layer = 13;
                                    /*
                                    //if (!child.GetComponent<enemyHealth>().DontaddBonesandRigid)
                                    {
                                        if (child.GetComponent<BoxCollider>() == null)
                                        {
                                            child.AddComponent<BoxCollider>();
                                        }
                                        if (child.GetComponent<Rigidbody>() == null)
                                        {
                                            child.AddComponent<Rigidbody>();
                                        }
                                        if (!collision.gameObject.GetComponent<enemyHealth>().cancelKillVelocity)
                                            child.GetComponent<Rigidbody>().velocity = (child.transform.position - collision.gameObject.transform.position) * 5;
                                        else
                                            child.GetComponent<Rigidbody>().velocity = Vector3.down;
                                    }
                                    if (child.GetComponent<BoxCollider>() && child.GetComponent<Rigidbody>() == null)
                                    {
                                        child.AddComponent<Rigidbody>();
                                    }
                                    */
                                    Destroy(child, 1);

                                }
                                if (collision.gameObject.GetComponent<BoxCollider>() != null)
                                {
                                    GetComponent<BoxCollider>().size /= 2;
                                }
                                //else
                                //collision.gameObject.AddComponent<BoxCollider>();
                                collision.gameObject.transform.LookAt(transform);
                                collision.gameObject.transform.Rotate(-90, 0, 0);
                                collision.GetComponent<Rigidbody>().velocity = (Vector3.up * 30) - (transform.forward * 20);
                                if (collision.GetComponent<Rigidbody>() == null)
                                    collision.AddComponent<Rigidbody>();
                                collision.transform.position += transform.up;
                                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

                                collision.gameObject.tag = "dead";
                                collision.transform.tag = "dead";
                                foreach (Transform t in collision.transform)
                                {
                                    t.gameObject.tag = "dead";
                                }


                                //GameObject pExplosion = Instantiate(particleExplosion);
                                //pExplosion.transform.position = collision.transform.position;
                                //Destroy(pExplosion, 2);
                                if (animController.GetInteger("WeaponNum") == 4)
                                    Destroy(collision.gameObject, 0.5f);
                                else
                                    DestroyEnemy(collision.gameObject);
                            }
                        }
                    }
                    else if (!retroMode)
                    {
                        GameObject.Find("HitMarker").GetComponent<Animator>().Play("HitMarker", -1, 0f);
                        GameObject epicHealth = Instantiate(EdamageText);
                        epicHealth.transform.position = collision.transform.position + transform.up * 5;
                        epicHealth.GetComponent<TextMesh>().text = 100 * ((original - newF) / collision.GetComponent<enemyHealth>().startingHealth) + "%";
                        epicHealth.GetComponent<Rigidbody>().velocity.Set(0, 3, 0);
                    }
                }
            }
        }
    }
    void DestroyEnemy(GameObject collision)
    {
        if (collision.GetComponent<enemyHealth>())
        {
            GameObject epicHealth = Instantiate(EdamageText);
            epicHealth.transform.position = collision.transform.position + transform.up * 5;
            float original = collision.GetComponent<enemyHealth>().Currenthealth;
            if (Time.realtimeSinceStartup > colliderSource.GetComponent<enemyHealth>().lastHitTime)
                colliderSource.GetComponent<enemyHealth>().lastHitTime = Time.realtimeSinceStartup + 0.1f;
            else
                return;
            collision.GetComponent<enemyHealth>().Currenthealth -= Mathf.Abs((float)(collision.GetComponent<enemyHealth>().startingHealth * ((collision.GetComponent<enemyHealth>().weaponDamages[animController.GetInteger("WeaponNum") - 1]))));
            float newF = collision.GetComponent<enemyHealth>().Currenthealth;
            if (newF < 0)
                newF = 0;
            epicHealth.GetComponent<TextMesh>().text = 100 * ((original - newF) / collision.GetComponent<enemyHealth>().startingHealth) + "%";
            epicHealth.GetComponent<Rigidbody>().velocity.Set(0, 3, 0);

            var go = collision.gameObject;
            var allChildren = go.GetComponentsInChildren<Transform>();
            foreach (Transform childTrans in allChildren)
            {
                GameObject child = childTrans.gameObject;
                child.tag = "dead";

                MonoBehaviour[] comps = child.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour c in comps)
                {
                    if (c != child.GetComponent<killEnemy>() && c != child.GetComponent<Renderer>() && c != child.GetComponent<Material>())
                        c.enabled = false;
                }

                if (child.GetComponent<Animator>() != null)
                    child.GetComponent<Animator>().enabled = false;

                child.name = "Dead";
                child.layer = 13;
                //if (!child.GetComponent<enemyHealth>().DontaddBonesandRigid)
                {
                    if (child.GetComponent<BoxCollider>() == null)
                    {
                        child.AddComponent<BoxCollider>();
                    }
                    if (child.GetComponent<Rigidbody>() == null)
                    {
                        child.AddComponent<Rigidbody>();
                    }
                    if (!collision.gameObject.GetComponent<enemyHealth>().cancelKillVelocity)
                        child.GetComponent<Rigidbody>().velocity = (child.transform.position - collision.gameObject.transform.position) * 5;
                    else
                        child.GetComponent<Rigidbody>().velocity = Vector3.down;
                }
                if (child.GetComponent<BoxCollider>() && child.GetComponent<Rigidbody>() == null)
                {
                    child.AddComponent<Rigidbody>();
                }
                Destroy(child, 1);

            }

            collision.gameObject.tag = "dead";
            collision.transform.tag = "dead";
            foreach (Transform t in collision.transform)
            {
                t.gameObject.tag = "dead";
            }


            GameObject pExplosion = Instantiate(particleExplosion);
            pExplosion.transform.position = collision.transform.position;
            Destroy(pExplosion, 2);

            Destroy(collision.gameObject, 1.5f);
        }
    }
    public void gibEnemy(Transform t)
    {
        Destroy(t.gameObject);
    }

}

