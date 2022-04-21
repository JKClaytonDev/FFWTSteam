using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;
using System;
using UnityEngine.Rendering;


public class Movement : MonoBehaviour
{
    //Declaring Variables
    public float speedBoostTime;
    public float comboCounter;
    public Text comboValue;
    public Text comboText;
    public SkinnedMeshRenderer[] arms;
    public Material comboArm;
    public Material normalArm;
    public bool heightlive;
    float combochangetime;
    float combTime;
    public AudioClip LUSound;
    [HideInInspector] public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 };  float firstJumpTime;    //public GameObject THREEDCam;
    [HideInInspector] public RotationAxes axes = RotationAxes.MouseXAndY; public GameObject explosion;  bool retroLevel;
    [HideInInspector] public float sensitivityX = 15F;[HideInInspector] public float sensitivityY = 15F;[HideInInspector] public float minimumX = -360F;[HideInInspector] public float startuptime;
    [HideInInspector] public float minimumY = -60F;[HideInInspector] public float maximumY = 60F; float rotationY = 0F; float rotationX = 0F;[HideInInspector] public float maximumX = 360F;[HideInInspector] public float PlayerHealth;
    [HideInInspector] public Animator animController; public float speed;[HideInInspector] public float jumps;
    GameObject GlobalControl; private float JumpTime; private bool canDoit; private float JumpStreak; private float startYpos; public int enemyCount;
    private float slowness; private float lastDelta; private int ScrollCount; private float delay; private Vector2 blackboxtarget; public GameObject damageText;
    [HideInInspector] public bool switchBack; private int tempLastweapon; private float jumptime; private Vector3 outsideVelocity; GameObject crosshairOutside;
    [HideInInspector] public Vector3 hitPoint; private Animator stopWatch; private GameObject leftUzi; private GameObject leftHand; private Vector2 blackboxcurrent;
    public GameObject[] weaponModels; private GameObject BoxCollider;[HideInInspector] private bool isGrounded;[HideInInspector] public float playerHealth;
    private Vector3 introcurrent; private Vector3 introtarget; private float escStage; private bool escPressed; private bool tb; private bool bb; private bool quitb;
    private float mouseXratio; private float mouseYratio; private float lastWep; string topB; string bottomB; string middleB; float lastPistol;
    private GameObject health; private GameObject ammo;[HideInInspector] public float HitTime; public float[] weaponAmmo; private float Ammp; public bool enemyTargeted;
    [HideInInspector] public AudioClip hitSound;[HideInInspector] public AudioClip killSound; private float lastWeapon; bool GrappledYet; GameObject enemyname; int lastButtonPressed;
    [HideInInspector] public int nextWeapon; private bool Enemiesdisabled; private bool JustSwitched; private Vector3 slide; private GameObject EnemyGameObject;    Vector3 ePos;
    [HideInInspector] public bool justSlid; private float slideTime; private Vector3 newPos; private float Ammo; private Vector3 moveF; Ray ray5; public doneShooting doneShot;
    private bool forwardVell; private Vector3 airDirection; private float airLength; bool upPressed; public float StartY; float healthBarTargetY; private Vector3 targetPoint;
    bool downPressed; bool leftPressed; bool rightPressed; public AudioClip jumpSound; private SpriteRenderer Crosshair;[HideInInspector] public Vector3 flashHitPoint;
    public bool SuperBoots; public bool GrappleHook; private float rotateOffsetcount;[HideInInspector] public bool Sliding; private float rotX; private Quaternion Oldrot;
    public Animator CameraJumping; public Vector3 extraSpeed; public float startupTime; public bool[] equippedWeapons; public Rigidbody PlayerRigidBody; public GameObject EdamageText;
    public bool ClassicControls; public bool oldMovement; public GameObject particleExplosion;[HideInInspector] public float jumpSpeed; private float lastJumps; private float speedMultiplier = 1;
    bool spaceUp; public float[] PlayerOriginalAmmo; SphereCollider sphcollide; bool scanRefresh; public GameObject ForceExample; Animator wepCamera; AudioSource colliderSource; GameObject playerCrosshair;
    RectTransform crosshairObject; weaponsCamera wepcameraOffset; GameObject wepCameraobj; public GameObject enemySparks; public Vector3 transPos; GameObject enemyHealthh; public GameObject totalHealth;
    float lastAmmo; float lastTime; float lastEnemies; float lastHealth; string lastLevel; bool camdisabled; float lastEquippedWep; GameObject playerSpawn; float wintime;  Vector3 kickMove;
    public bool retroMode; public bool Intro; public float crosshairOffset; private GameObject Ccrosshair; GameObject playerCamera; bool graphicsOptions;   public AudioClip kickSound;
    private GUIStyle labelText = new GUIStyle(); private GUIStyle button = new GUIStyle(); private GUIStyle button2 = new GUIStyle(); private GUIStyle quitbutton = new GUIStyle(); Vector3 lastPos; Vector3 lastVel;
    private GUIStyle numText = new GUIStyle(); GameObject hitMarker; public GameObject menuEnabled; public float speedBoost;    public float enemycount;    public LayerMask enemylayer;    float fireTime;
    private GUIStyle winText = new GUIStyle();  public bool loadLevel;  float lookAtEnemyRatio;   Vector3 targetPos;    public GameObject legAnimObj;  Animator legAnim;    Vector3 targetRot;
    public string[] gunAnims;   float accelerate;   public float[] fireLength; public string[] fireAnims;   Vector3 lastVelt;   float kickTime; public GameObject screenFlash;  float landTime;
    public float HitTimee;  bool easterEgg; GameObject g;   float lastText; public float lastFOV;   public bool Ground1; public GameObject transition;   float size;
    float loadMap;  bool noTransiiton;  bool rifle; public GameObject retroGraphics;    public GameObject[] setActiveStart; Vector3 portalLocation; bool portalFound;   bool Ground1t; float moveTime;
    public GameObject deadCamera;   public AudioSource jettSource;  public AudioClip jettClip;  public float bhopspeed; Vector3 lastHotPos;
    public MeshRenderer[] galaxyRenderers; public SkinnedMeshRenderer[] skinnedGalaxyRenderers; bool onejump;
    public Material spaceShader;    public Material goldShader; public Material transparentShader;  public Material lavaShader; int lastGunSwitch; float lastSwitchTime;
    public Material superHotRed;    public Material superHotBlack;  public Material superHotWhite;  bool tinyPlayer;
    float dashes;   public GameObject SHVolume; bool superHot;  public bool spaceDown;  float CombospeedBoost;
    public Vector3 strafeVel;   bool chaingun;  public AudioSource host;
    AnimationEvent pause; bool scenename; public LineRenderer line; public Transform linePoint; public bool hasNade; bool groundLevels;
    AnimationEvent unpause; float lastUpdateTime;



    double delayy;  public bool fireground; enemyHealth nearestEnemy = null;    bool jetpack = true;
    void Start()
    {
        PlayerPrefs.SetString("Mode", "Normal");
        if (SceneManager.GetActiveScene().name == "Ground1")
        {
            PlayerPrefs.SetInt("Kills", 0);
            PlayerPrefs.SetInt("Deaths", 0);
            for (int i = 0; i < equippedWeapons.Length; i++)
            {
                PlayerPrefs.SetInt(i + "", 0);
            }
        }
        groundLevels = false;
        scenename = SceneManager.GetActiveScene().name.Contains("City") || SceneManager.GetActiveScene().name.Contains("Ground");

        /*
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject g in allObjects)
        {
            if (!g.isStatic && g.transform.parent == null)
            {
                    g.AddComponent<CreateLevel>();
            }
        }
        */
        onejump = SceneManager.GetActiveScene().name == "Ground1";
        chaingun = PlayerPrefs.GetInt("Chaingun") == 1;
        if (chaingun)
        {
            equippedWeapons[9] = true;
            equippedWeapons[8] = true;
            equippedWeapons[10] = true;
        }
        tinyPlayer = PlayerPrefs.GetInt("TinyPlayer") == 1;
        if (tinyPlayer)
        {
            foreach (Camera c in FindObjectsOfType<Camera>())
            {
                c.useOcclusionCulling = false;
            }
            GameObject dad = new GameObject();
            dad.transform.position = transform.position;
            GameObject[] obj = FindObjectsOfType<GameObject>();
            foreach (GameObject g in obj)
            {
                
                if (g.transform.parent == null)
                {
                    if (g.isStatic)
                    {

                        Destroy(g);
                    }
                    else
                    g.transform.parent = dad.transform;
                }
            }
            transform.parent = null;
            dad.transform.localScale *= 3;
            dad.name = "Dad";
        }
        if (PlayerPrefs.GetInt("Mirror") == 1)
        {
            foreach (Camera c in FindObjectsOfType<Camera>())
            {
                c.useOcclusionCulling = false;
            }
            GameObject dad = new GameObject();
            dad.transform.position = transform.position;
            GameObject[] obj = FindObjectsOfType<GameObject>();
            foreach (GameObject g in obj)
            {

                if (g.transform.parent == null)
                {
                    if (g.isStatic)
                    {
                        g.isStatic = false;
                        GameObject f = Instantiate(g);
                        f.transform.position += Vector3.up * 25;
                        f.transform.parent = dad.transform;
                    }
                    else
                        g.transform.parent = dad.transform;
                }
            }
            dad.transform.localScale = new Vector3(-1, 1, 1);
            transform.parent = null;
            dad.name = "Dad";
        }
        superHot = PlayerPrefs.GetInt("SuperHot") == 1;
        if (PlayerPrefs.GetInt("NoHUD") == 1)
        {
            foreach (Canvas c in FindObjectsOfType<Canvas>())
                c.enabled = false;
        }

        firstJumpTime = 0;
        Time.timeScale = 0.01f;
        if (goldShader && spaceShader)
        {
            string skin = PlayerPrefs.GetString("Skin");
            Material sh = goldShader;
            if (skin == "Gold")
                sh = goldShader;
            if (skin == "Space")
                sh = spaceShader;
            if (skin == "Lava")
                sh = lavaShader;
            if (skin != "None" && ((skin == "Lava") || (skin == "Gold") || (skin == "Space")))
            {
                foreach (MeshRenderer m in galaxyRenderers)
                {
                    m.material = sh;
                    for (int i = 0; i < m.materials.Length; i++)
                        m.materials[i] = sh;
                }
                foreach (SkinnedMeshRenderer m in skinnedGalaxyRenderers)
                {
                    m.material = sh;
                    for (int i = 0; i < m.materials.Length; i++)
                        m.materials[i] = sh;
                }
                foreach (GameObject a in GameObject.FindGameObjectsWithTag("playerWeapons"))
                {
                    Debug.Log(a.name);
                    if (a.GetComponent<MeshRenderer>())
                    {
                        a.GetComponent<MeshRenderer>().material = sh;
                        for (int i = 0; i < a.GetComponent<MeshRenderer>().materials.Length; i++)
                            a.GetComponent<MeshRenderer>().materials[i] = sh;
                    }
                    if (a.GetComponent<SkinnedMeshRenderer>())
                    {
                        a.GetComponent<SkinnedMeshRenderer>().material = sh;
                        for (int i = 0; i < a.GetComponent<SkinnedMeshRenderer>().materials.Length; i++)
                            a.GetComponent<SkinnedMeshRenderer>().materials[i] = sh;

                    }
                }
            }

        }
        
        bool reverse = PlayerPrefs.GetInt("Reverse") == 1;



            if (reverse)
            {
                if (FindObjectOfType<portalLevel>() && SceneManager.GetActiveScene().name != "Ground1")
                {
                    Vector3 pos = GameObject.Find("PlayerSpawn").transform.position;
                    GameObject.Find("PlayerSpawn").transform.position = (FindObjectOfType<portalLevel>().transform.position);
                    FindObjectOfType<portalLevel>().transform.position = pos;

                }
            }

            if (SceneManager.GetActiveScene().name == "Ground1" || SceneManager.GetActiveScene().name == "RetroGround1")
            {
                PlayerPrefs.SetInt("AirDash", 0);
                PlayerPrefs.SetInt("SuperBounce", 0);
                PlayerPrefs.SetInt("FastFiring", 0);
            }
            pause = new AnimationEvent();
            unpause = new AnimationEvent();
            pause.functionName = "Pause";
            unpause.functionName = "Unpause";
            Destroy(GameObject.Find("SpaceShip"));
            Destroy(GameObject.Find("SpaceShip (1)"));
            Destroy(GameObject.Find("SpaceShip (2)"));
            Destroy(GameObject.Find("SpaceShip (3)"));
            Destroy(GameObject.Find("SpaceShip (4)"));
            Destroy(GameObject.Find("SpaceShip (5)"));
            Ground1t = GameObject.FindObjectOfType<portalLevel>();
            if (Ground1t)
                portalFound = GameObject.FindObjectOfType<portalLevel>().gameObject;
            if (portalFound)
                portalLocation = GameObject.FindObjectOfType<portalLevel>().gameObject.transform.position;
            retroLevel = SceneManager.GetActiveScene().name.Contains("Retro");
            size = 1;
            if (SceneManager.GetActiveScene().name.Contains("Retro"))
                size = 3;

            rifle = false;
            if (SceneManager.GetActiveScene().name == "Ground111")
            {
                bool found = false;
                GameObject g = GameObject.Find("Cube (3)");
                while (!found)
                {
                    if (g.transform.position.x == 1010)
                    {
                        g.name = "FOUND";
                        found = true;
                    }
                    else
                    {
                        g.name = "JEFF";
                        g = GameObject.Find("Cube (3)");
                    }

                }


                GameObject f = GameObject.Instantiate(g);
                g.SetActive(false);
                f.transform.parent = null;
                if (f.GetComponent<MeshRenderer>())
                    f.GetComponent<MeshRenderer>().enabled = false;
                f.transform.localScale = new Vector3(2017.933f, 360.003f, 7.2458f);
                //f.transform.position = new Vector3(486.2f, -7, -508);
                GameObject wall = Instantiate(f);
                wall.transform.parent = null;
                wall.transform.position = new Vector3(379.9f, -7, -508);
                wall.transform.rotation = new Quaternion(0, 0, 0, 0);
                wall.transform.Rotate(new Vector3(0, 90, 0));
                GameObject wall2 = Instantiate(f);
                wall2.transform.parent = null;
                wall2.transform.position = new Vector3(-12.3f, 44.5f, -508);
                wall2.transform.rotation = new Quaternion(0, 0, 0, 0);
                wall2.transform.Rotate(new Vector3(0, 90, 0));
            }


            if (SceneManager.GetActiveScene().name == "SkyGrass1")
                GameObject.Find("PlayerSpawn").transform.position += Vector3.up * 10;
            loadMap = 0;
            Ground1 = false;
        if (SceneManager.GetActiveScene().name.Contains("Ground") || SceneManager.GetActiveScene().buildIndex == 1)
        {
            Physics.gravity = new Vector3(0, -500, 0);
        }
        if (SceneManager.GetActiveScene().name.Contains("Space"))
            {
                Physics.gravity = new Vector3(0, -15, 0);
            }
            else
            {
                Physics.gravity = new Vector3(0, -20.81f, 0);
            }
            if (PlayerPrefs.GetInt("MoonGravity") == 1)
                Physics.gravity = new Vector3(0, -5, 0);
            lastFOV = 80;
            if (!playerCamera)
            {
                playerCamera = FindObjectOfType<Camera>().gameObject;
                if (playerCamera)
                    lastFOV = playerCamera.GetComponent<Camera>().fieldOfView;
            }
            if (lastFOV > 80)
                lastFOV = 80;
            Time.timeScale = 1;
            easterEgg = SceneManager.GetActiveScene().name == "Storm1";
            if (easterEgg)
            {
                g = new GameObject();
                g.AddComponent<TextMesh>();
                g.transform.position = new Vector3(-106.31f, -52.8f, -187.87f);
                g.GetComponent<TextMesh>().text = "Type Chim on Level 5";
                g.transform.localScale = new Vector3(5, 5, 5);
                g.transform.rotation = new Quaternion(0, -125.235f, 0, 0);
                g.name = "guide";
            }
            if (SceneManager.GetActiveScene().name == "BossFight")
                equippedWeapons[5] = false;
            if (PlayerPrefs.GetInt("Difficulty") <= 0)
                PlayerPrefs.SetInt("Difficulty", 0);
            if (PlayerPrefs.GetFloat("Mouse") <= 0)
                PlayerPrefs.SetFloat("Mouse", 15);
            PlayerPrefs.SetString("Scene", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();
            kickTime = 0;
            HitTimee = 0;
            lastVelt = new Vector3();
            fireTime = 0;
            legAnim = legAnimObj.GetComponent<Animator>();
            lookAtEnemyRatio = 0;
            loadLevel = FindObjectOfType<portalLevel>();
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
            if (FindObjectOfType<portalLevel>() && !(PlayerPrefs.GetString("Mode") == "Classic"))
                playerSpawn = FindObjectOfType<portalLevel>().gameObject;
            enemyCount = 100;
            if (!retroMode)
            {
                crosshairOutside = GameObject.Find("CrosshairOutside");
                enemyname = GameObject.Find("EnemyName");
                playerCrosshair = GameObject.Find("PlayerCrosshair");
                if (playerCrosshair)
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
            Debug.Log("Test1" +
                "");
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
            jumps = 0;
            Debug.Log("Test2");
            if (PlayerPrefs.GetFloat("Mouse") < 0.01f)
                PlayerPrefs.SetFloat("Mouse", 0.5f);
            if (PlayerPrefs.GetFloat("FOV") < 1)
                PlayerPrefs.SetFloat("FOV", 70);

            if (SceneManager.GetActiveScene().name == "Ground1")
                transform.Rotate(new Vector3(90, 90, 90));
            lastFOV = PlayerPrefs.GetFloat("FOV");
            //playerCamera.GetComponent<Camera>().fieldOfView = lastFOV;
            Debug.Log("Test3");
            if (PlayerPrefs.GetInt("NoClip") == 1)
                this.enabled = false;
            foreach (GameObject g in setActiveStart)
                g.SetActive(true);
            if (!playerCamera.GetComponent<camMovement>())
                playerCamera.AddComponent<camMovement>();

        if (superHot)
        {
            Instantiate(SHVolume);
            MeshRenderer[] enemies = FindObjectsOfType<MeshRenderer>();
            foreach (MeshRenderer g in enemies)
            {

                Material setMat = superHotWhite;
                if (g.tag == "playerWeapons" || g.tag == "Player")
                    setMat = superHotBlack;
                if (g.tag == "Enemy")
                    setMat = superHotRed;
                if (g.GetComponent<MeshRenderer>())
                {
                    g.GetComponent<MeshRenderer>().sharedMaterial = setMat;
                    for (int i = 0; i < g.GetComponent<MeshRenderer>().sharedMaterials.Length; i++)
                        g.GetComponent<MeshRenderer>().sharedMaterials[i] = setMat;
                }


            }
            SkinnedMeshRenderer[] enemies2 = FindObjectsOfType<SkinnedMeshRenderer>();
            foreach (SkinnedMeshRenderer g in enemies2)
            {
                Material setMat = superHotWhite;
                if (g.tag == "playerWeapons" || g.tag == "Player")
                    setMat = superHotBlack;
                if (g.tag == "Enemy")
                    setMat = superHotRed;
                if (g.GetComponent<SkinnedMeshRenderer>())
                {
                    g.GetComponent<SkinnedMeshRenderer>().sharedMaterial = setMat;
                    for (int i = 0; i < g.GetComponent<SkinnedMeshRenderer>().sharedMaterials.Length; i++)
                        g.GetComponent<SkinnedMeshRenderer>().sharedMaterials[i] = setMat;
                }
            }
        }
        if (!FindObjectOfType<bossObjHealth>())
        {
            for (int i = 0; i < equippedWeapons.Length; i++)
            {
                equippedWeapons[i] = (PlayerPrefs.GetInt(i + "") == 1);
            }
            equippedWeapons[4] = true;
            //GameObject ce = Instantiate(THREEDCam);
            //ce.transform.parent = null;
            //ce.GetComponent<camTakeOver>().playercamera = playerCamera;

            if (SceneManager.GetActiveScene().buildIndex == PlayerPrefs.GetInt("NextSceneName"))
            {

                if (equippedWeapons[PlayerPrefs.GetInt("EqWP")])
                {
                    animController.SetInteger("WeaponNum", PlayerPrefs.GetInt("EqWP"));
                }
            }
            if (SceneManager.GetActiveScene().name == "BossFight")
            {
                for (int i = 0; i < 13; i++)
                    equippedWeapons[i] = true;
            }
        }
        else
        {
            for (int i = 0; i < 13; i++)
                equippedWeapons[i] = false;
            equippedWeapons[4] = true;
        }
        if (FindObjectOfType<bossObjHealth>())
        {
            if (FindObjectOfType<bossObjHealth>().health)
                transform.LookAt(FindObjectOfType<bossObjHealth>().health.transform);
        }
    }
    public void Pause() {
        
        
    }
    public void Unpause()
    {
        animController.speed = 1;
    }
    public void tryEquipWeapon()
    {
        if (Time.realtimeSinceStartup > lastSwitchTime + 1f)
        {
            lastSwitchTime = Time.realtimeSinceStartup;
        }
        else
            return;
        if (hasNade)
        {

        }
        else
        {
            animController.enabled = false;
            animController.enabled = true;

    }
        if (animController.GetInteger("WeaponNum") == 0)
        {
            //animController.Play("");
        }
        if (animController.GetInteger("WeaponNum") == 1)
        {
            animController.Play("ShotgunIdle");
        }
        if (animController.GetInteger("WeaponNum") == 2)
        {
           // animController.Play("");
        }
        if (animController.GetInteger("WeaponNum") == 3)
        {
            animController.Play("UziEquip 2");
        }
        if (animController.GetInteger("WeaponNum") == 4)
        {
            animController.Play("RevolverEquip 0");
        }
        if (animController.GetInteger("WeaponNum") == 5)
        {
            animController.Play("RocketLauncherEquip");
        }
        if (animController.GetInteger("WeaponNum") == 6)
        {
            animController.Play("PumpEquip");
        }
        if (animController.GetInteger("WeaponNum") == 7)
        {
            animController.Play("AutoIdle");
        }
        if (animController.GetInteger("WeaponNum") == 8)
        {
            //animController.Play("");
        }
        if (animController.GetInteger("WeaponNum") == 9)
        {
            //animController.Play("");
        }
        if (animController.GetInteger("WeaponNum") == 10)
        {
            animController.Play("ChaingunIdle");
        }
        if (animController.GetInteger("WeaponNum") == 11)
        {
            animController.Play("StartPistolIdle");
        }
        if (animController.GetInteger("WeaponNum") == 12)
        {
            //animController.Play("");
        }
        if (animController.GetInteger("WeaponNum") == 9)
        {
            animController.Play("DoubleBarreldle");
        }
        if (animController.GetInteger("WeaponNum") == 13)
        {
            //animController.Play("");
        }
    }
    void Update()
    {
        if (Time.realtimeSinceStartup < 10)
        {
            playerHealth = 100;
            PlayerHealth = 100;
        }
        if (lastUpdateTime < Time.realtimeSinceStartup)
        {
            lastUpdateTime = Time.realtimeSinceStartup + 8;
            for (int i = 0; i < equippedWeapons.Length; i++)
            {
                int isTrue = 0;
                if (equippedWeapons[i])
                    isTrue = 1;
                PlayerPrefs.SetInt(i + "", isTrue);
            }
        }
        if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.F))
            hasNade = false;

        animController.SetBool("nade", hasNade);

        comboValue.text = "";
        if (comboCounter != 0)
        comboValue.text = ""+Mathf.Round(comboCounter);
        if (Time.realtimeSinceStartup > combochangetime - 0.2f)
            comboText.fontSize = 80;
        else if (Time.realtimeSinceStartup > combochangetime - 0.2f)
            comboText.fontSize = 70;
        else
            comboText.fontSize = 66;
        CombospeedBoost = 0;
        String newtext = "";
        if (comboCounter > 20)
            newtext = "F";
        if (comboCounter > 35)
            newtext = "FR";
        if (comboCounter > 55)
            newtext = "FRA";
        if (comboCounter > 75)
            newtext = "FRAG";
        if (comboText.text != newtext && newtext.Length > comboText.text.Length)
        GetComponent<AudioSource>().PlayOneShot(LUSound);
        comboText.text = newtext;
        comboCounter -= Time.deltaTime * 5;
        if (comboCounter < 0)
            comboCounter = 0;
        if (comboCounter > 100)
        {
            comboCounter -= Time.deltaTime * 5;
            comboCounter = 100;
        }
        if (!((Input.GetMouseButton(1) || Input.GetAxis("Fire2") > 0) && animController.GetInteger("WeaponNum") - 1 == 0))
        playerCamera.GetComponent<Camera>().fieldOfView = 60;
        if (host)
            host.pitch = 1;
        if (comboCounter > 75)
        {
            if (host)
                host.pitch = 1.2f;
            playerCamera.GetComponent<Camera>().fieldOfView = 75;
            comboCounter -= Time.deltaTime * 1;
            foreach (SkinnedMeshRenderer m in arms)
                m.material = comboArm;
            playerHealth+=25*Time.deltaTime;
            if (comboCounter > 90)
                PlayerHealth += 25 * Time.deltaTime;
            if (PlayerHealth > 100)
                PlayerHealth = 100;
            CombospeedBoost = 1;
        }
        else
        {
            foreach (SkinnedMeshRenderer m in arms)
                m.material = normalArm;
        }
        if ((Input.GetMouseButton(0) || Input.GetAxis("Fire1") > 0) && animController.GetInteger("WeaponNum") == 6 && weaponAmmo[5] > 1)
        {
            animController.Play("PumpFire");
        }


        
        if (chaingun)
        {
            equippedWeapons[9] = true;
            equippedWeapons[8] = true;
            equippedWeapons[10] = true;
            animController.SetInteger("WeaponNum", 10);
        }

        if (animController.GetInteger("WeaponNum") == 4 && Input.GetMouseButtonDown(0) && weaponAmmo[animController.GetInteger("WeaponNum") - 1] > 1)
        {
            if (hasNade)
            {
                animController.Play("csgoFire");
            }
            else {
                        int weaponNum = animController.GetInteger("WeaponNum");
                        animController.Rebind();
                        animController.SetInteger("WeaponNum", weaponNum);
                        animController.SetBool("IsFiring", true);
                        animController.SetBool("mouseDown", true);
                    }}
        
            animController.speed = 1;
        if (PlayerPrefs.GetInt("FastFiring") == 1 && animController.GetInteger("WeaponNum") != 4)
        animController.speed = 2;
        

        if (jumps == 0)
            fireground = true;

        if (Input.GetKeyDown(KeyCode.Tilde))
        {
            if (GameObject.Find(retroGraphics.name+"(Clone)"))
                Destroy(GameObject.Find(retroGraphics.name + "(Clone)"));
            else
            {
                Instantiate(retroGraphics);
            }
        }
        transform.localScale = new Vector3(1/size, 1 / size, 1 / size);
        if (SceneManager.GetActiveScene().name == "BossFight" || PlayerPrefs.GetInt("InfAmmo") == 1)
        weaponAmmo[animController.GetInteger("WeaponNum") - 1] = 255;
        if (!playerCamera.GetComponent<CameraIntro>().enabled){
            if (jumps == 0)
                accelerate /= 2;
            else if ((Input.GetAxis("Vertical") > 0 && Input.GetAxisRaw("Mouse X") > 0) || (Input.GetAxis("Vertical") < 0 && Input.GetAxisRaw("Mouse X") < 0))
                accelerate++;
        }
        
       //Debug.Log("Acceleration: " + accelerate);
        if (Time.timeScale != 0)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            if (!retroMode)
                rotationY += Input.GetAxisRaw("Mouse Y") * sensitivityY * Time.fixedDeltaTime * 15 * PlayerPrefs.GetFloat("Mouse");
            else if (animController.GetInteger("WeaponNum") != 9)
            {
                animController.SetInteger("WeaponNum", 9);
                animController.SetBool("Switched", true);
            }

            rotationX += Input.GetAxisRaw("Mouse X") * sensitivityY * Time.fixedDeltaTime * 15 * PlayerPrefs.GetFloat("Mouse");

            if (lookAtEnemyRatio == 0)
            {
                rotationY = Mathf.Min(Mathf.Max(-90, rotationY), 90);
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

                if (animController.GetInteger("WeaponNum") - 1 == 0)
                {
                    if (Input.GetKey(KeyCode.R) || (Input.GetAxis("Inspect") != 0))
                    {
                        if ((Input.GetMouseButtonDown(1)))
                        {
                            nearestEnemy = null;
                            Debug.Log("CHECKEDEDEDDE");
                            enemyHealth[] enemiesInRange = FindObjectsOfType<enemyHealth>();

                            float bestAngle = -1f;
                            foreach (enemyHealth enemy in enemiesInRange)
                            {
                                Vector3 vectorToEnemy = enemy.transform.position - transform.position;
                                vectorToEnemy.Normalize();
                                float angleToEnemy = Vector3.Dot(transform.forward, vectorToEnemy);
                                if (angleToEnemy > bestAngle)
                                {
                                    nearestEnemy = enemy;
                                    bestAngle = angleToEnemy;
                                }
                            }
                            if (nearestEnemy)
                            {
                                transform.LookAt(nearestEnemy.transform);
                                transform.Rotate(-19, 2, 0);
                            }
                        }
                        else if ((Input.GetMouseButton(1) || Input.GetAxis("Fire2") > 0))
                        {
                            transform.LookAt(nearestEnemy.transform);
                            playerCamera.transform.LookAt(nearestEnemy.transform);
                            transform.Rotate(-19, 2, 0);
                        }
                    }
                }
            }
            else
            {
                kickMove = Vector3.MoveTowards(kickMove, targetPos, 2);
                Vector3 fm = kickMove;
                fm.y = transform.position.y;
                Vector3 ep = ePos;
                ep.y = transform.position.y;
                Vector3 fw = Vector3.MoveTowards(fm, ep, 2);
                //GetComponent<Rigidbody>().velocity = (fm-transform.position)*Time.fixedDeltaTime;
                transform.LookAt(targetPos);
                if (kickMove == targetPos)
                    lookAtEnemyRatio = 0;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        lastHealth = PlayerHealth;

    }
    void FixedUpdate()
    {
        lastHotPos = transform.position;
        if (PlayerPrefs.GetInt("NoHUD") == 1 && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
            if (Time.realtimeSinceStartup > moveTime)
        {
            moveTime = 0;
            Unpause();
        }
        if (Time.realtimeSinceStartup < moveTime)
        {
            transform.position += strafeVel * 75 * Time.fixedDeltaTime;
            if (Time.realtimeSinceStartup < moveTime-0.1f)
                transform.position += strafeVel * 15 * Time.fixedDeltaTime;
        }
        Quaternion oldRot = transform.rotation;
        Quaternion newRot = transform.rotation;
        newRot.x = 0;
        newRot.z = 0;
        transform.rotation = newRot;


        if (PlayerPrefs.GetInt("AirDash") == 1 && dashes > 0 && Time.realtimeSinceStartup > moveTime+2)
        {
            if (Input.GetKey(KeyCode.LeftShift)) {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
            {
                jettSource.PlayOneShot(jettClip);
                moveTime = Time.realtimeSinceStartup + 0.4f;
                strafeVel = -transform.right * 3;
                animController.Play("FlyLeft", 0);
                dashes -= 5;
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                jettSource.PlayOneShot(jettClip);
                moveTime = Time.realtimeSinceStartup + 0.4f;
                strafeVel = transform.forward * 3;
                animController.Play("FlyForward", 0);
                dashes -= 5;
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
            {
                jettSource.PlayOneShot(jettClip);
                moveTime = Time.realtimeSinceStartup + 0.4f;
                animController.Play("FlyRight", 0);
                strafeVel = transform.right * 3;
                dashes -= 5;
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
            {
                jettSource.PlayOneShot(jettClip);
                moveTime = Time.realtimeSinceStartup + 0.4f;
                strafeVel = -transform.forward * 3;
                legAnim.Play("kick");
                dashes -= 5;
            }
        }
        }
        if (jumps == 0)
            dashes = 3;
        transform.rotation = oldRot;
        if (animController.GetInteger("WeaponNum") == 11)
        animController.SetLayerWeight(2, 1);
        else
            animController.SetLayerWeight(2, 0);

        if (Ground1t)
        {
            if (Vector3.Distance(transform.position, portalLocation) < 15)
            {
                
                PlayerPrefs.SetInt("EqWP", animController.GetInteger("WeaponNum"));
                PlayerPrefs.SetInt("NextSceneName", SceneManager.GetActiveScene().buildIndex + 1);
                for (int i = 0; i < equippedWeapons.Length; i++)
                {
                    int isTrue = 0;
                    if (equippedWeapons[i])
                        isTrue = 1;
                    PlayerPrefs.SetInt(i + "", isTrue);
                }
                if (FindObjectOfType<NextLevelName>())
                {
                    Debug.Log("THIS IS ME ITS ME I USED THE LOADNEXTSCENE THATSD ME HASHASHASDHASHDAHSDHASDDHSAD");
                    SceneManager.LoadScene(FindObjectOfType<NextLevelName>().nextLevel);
                    this.enabled = false;
                    return;
                }
            }
        }
        
        if ((Input.GetKeyDown(KeyCode.R) || (Input.GetAxis("Inspect") != 0)))
        {
            if (animController.GetInteger("WeaponNum") == 3)
                animController.Play("uziVidEquip");
            else if (animController.GetInteger("WeaponNum") == 10)
                animController.Play("chaingunInpect");
            else if(animController.GetInteger("WeaponNum") == 1)
                animController.Play("flipGat");
            else if (animController.GetInteger("WeaponNum") == 6)
            {
                if (UnityEngine.Random.Range(1, 10) != 6)
                    animController.Play("InspectShotgun");
                else
                    animController.Play("RareInspect");
            }
            else if (animController.GetInteger("WeaponNum") == 7)
            {
                    animController.Play("ARInspect");
            }
            else if (animController.GetInteger("WeaponNum") == 4)
            {
                if(UnityEngine.Random.Range(1, 2) == 3)
                    animController.Play("csgoPistolInspect");
                else
                    animController.Play("csgodefaultInspect");
            }
            else if (animController.GetInteger("WeaponNum") == 9)
            {
                    animController.Play("DoubleBarrelFlip");
            }
            else
                animController.Play("weaponInspect", 4);
        }
        if (!playerCamera)
        {
            playerCamera = FindObjectOfType<Camera>().gameObject;
        }
        else
        {
            if ((Input.GetMouseButton(1) || Input.GetAxis("Fire2") > 0) && animController.GetInteger("WeaponNum") - 1 == 0)
            {
                playerCamera.GetComponent<Camera>().fieldOfView += Time.fixedDeltaTime * 5 * ((lastFOV / 8) * 3 - playerCamera.GetComponent<Camera>().fieldOfView);
                rifle = true;
            }
            else
            {
                rifle = false;
            }
        }
        if (easterEgg)
            g.SetActive(Vector3.Distance(transform.position, new Vector3(-106, -52, -187)) < 150);
        sensitivityY = (PlayerPrefs.GetFloat("Mouse"));
        sensitivityX = (PlayerPrefs.GetFloat("Mouse"));
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            sensitivityX += 1;
            sensitivityY += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            sensitivityX -= 1;
            sensitivityY -= 1;
        }
        PlayerPrefs.SetFloat("Mouse", sensitivityX);
        if (weaponAmmo.Length - 1 >= animController.GetInteger("WeaponNum") - 1 && animController.GetInteger("WeaponNum") - 1 >=0)
        {
            if (weaponAmmo[animController.GetInteger("WeaponNum") - 1] > 1)
            {
                if (fireTime < Time.realtimeSinceStartup)
                {
                    if (fireAnims[animController.GetInteger("WeaponNum") - 1] != "")
                    {
                        if (Input.GetButtonDown("Fire1"))
                        {
                            animController.Play(fireAnims[animController.GetInteger("WeaponNum") - 1]);
                            fireTime = Time.realtimeSinceStartup + fireLength[animController.GetInteger("WeaponNum") - 1];
                        }
                    }
                    else
                    {
                        animController.SetBool("IsFiring", Input.GetButton("Fire1") && weaponAmmo[animController.GetInteger("WeaponNum") - 1] > 1);
                        animController.SetBool("mouseDown", (Input.GetButtonDown("Fire1") && doneShot.fireTime < Time.realtimeSinceStartup && weaponAmmo[animController.GetInteger("WeaponNum") - 1] > 1));
                        if (Input.GetButton("Fire1") && weaponAmmo[animController.GetInteger("WeaponNum") - 1] > 1)
                        {
                            animController.SetBool("Switched", true);
                            rotateOffsetcount = 0;
                        }
                    }
                }
            }
            else
            {
                animController.SetBool("IsFiring", false);
            }
        }
        lastPos = transform.position;
        /*
        if (Input.GetKeyDown(KeyCode.F) && kickTime < Time.realtimeSinceStartup)
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
                        //colliderSource.pitch = Random.Range(-0.7f, 1.3f);
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
                        if (e.gameObject.GetComponent<enemyHealth>())
                        {
                            e.gameObject.GetComponent<enemyHealth>().Currenthealth -= e.gameObject.GetComponent<enemyHealth>().startingHealth * 0.8f;
                            if (e.gameObject.GetComponent<enemyHealth>().Currenthealth < 0.1f)
                            {
                                if (Time.realtimeSinceStartup > combTime + 0.2f)
                                    comboCounter += 15f;
                                combTime = Time.realtimeSinceStartup;
                                
                                combochangetime = Time.realtimeSinceStartup;
                                DestroyEnemy(e.gameObject);
                                if (PlayerHealth < 75 && e.gameObject.GetComponent<enemyHealth>())
                                {

                                    if (PlayerHealth > 75)
                                        PlayerHealth = 75;
                                }
                            }
                        }
                        lookAtEnemyRatio = 1;

                        Time.timeScale = 0.4f;
                        done = true;
                    }

                }


            }
            else
            {
                if (Physics.Raycast(rwj, 15))
                    legAnim.Play("slide");
            }
            kickTime = Time.realtimeSinceStartup + 0.5f;
            
            transform.localEulerAngles = oldrot;
            transform.rotation = oldQuat;
            
        }
        */
        if (!jetpack)
            PlayerRigidBody.velocity = new Vector3(0, PlayerRigidBody.velocity.y, 0);
        if (Input.GetKeyDown(KeyCode.J))
            jetpack = !jetpack;
        if (Time.realtimeSinceStartup < startuptime + 10)
            playerHealth = 100;
        if (Time.timeScale != 0.5f)
        {
            if (Time.timeScale > 0 && Time.timeScale < 1)
                Time.timeScale += (1 - Time.timeScale) / 20;
            if (Time.timeScale > 0.95 && Time.timeScale != 1)
                Time.timeScale = 1;
            if (Time.timeScale == 0.5f)
                Time.timeScale = 0.6f;
            if (combTime + 0.15f > Time.realtimeSinceStartup)
            {
                Time.timeScale = 0.95f;
                if (comboCounter < 20)
                Time.timeScale = 0.85f;
                else if (comboCounter < 50)
                    Time.timeScale = 0.75f;
                else if (comboCounter < 70)
                    Time.timeScale = 0.65f;
                else if (comboCounter < 90)
                    Time.timeScale = 0.55f;
            }
            else if (combTime + 0.5f > Time.realtimeSinceStartup)
                Time.timeScale = 1;
        }
        if (!loadLevel && (int)Time.realtimeSinceStartup % 2 == 0)
        {
            float enemyCCount = FindObjectsOfType<enemyHealth>().Length;
            if (enemyCCount == 0)
            {
                if (transition)
                {
                    transition.GetComponent<transition>().target = new Vector3(0, 0, 0);
                    transition.GetComponent<transition>().outro = true;
                    transition.GetComponent<transition>().scene = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name;
                    if (loadMap == 0)
                        loadMap = Time.realtimeSinceStartup;
                    else if (loadMap + 5 < Time.realtimeSinceStartup)
                    {

                        if (SceneManager.GetActiveScene().name == "RetroGround10")
                            SceneManager.LoadScene("Credits");
                        else
                        {
                            if (FindObjectOfType<NextLevelName>())
                            {
                                Debug.Log("THIS IS ME ITS ME I USED THE LOADNEXTSCENE THATSD ME HASHASHASDHASHDAHSDHASDDHSAD");
                                SceneManager.LoadScene(FindObjectOfType<NextLevelName>().nextLevel);
                                this.enabled = false;
                                return;
                            }
                            {
                                musicHost host = FindObjectOfType<musicHost>();
                                int foundvalue = -1;
                                string currentScene = SceneManager.GetActiveScene().name;
                                for (int i = 0; i < host.sceneOrder.Length; i++)
                                {
                                    if (host.sceneOrder[i] == currentScene)
                                        foundvalue = i;
                                }
                                if (foundvalue != -1)
                                {
                                    Debug.Log("USED FOUND VALUE");
                                    SceneManager.LoadScene(host.sceneOrder[foundvalue + 1]);
                                    return;

                                }
                            }
                            PlayerPrefs.SetInt("SceneLoad", SceneManager.GetActiveScene().buildIndex + 1);
                            PlayerPrefs.Save();
                            SceneManager.LoadScene("Loading"); this.enabled = false;
                        }
                    }

                }
                else
                {
                    if (FindObjectOfType<NextLevelName>())
                    {
                        Debug.Log("THIS IS ME ITS ME I USED THE LOADNEXTSCENE THATSD ME HASHASHASDHASHDAHSDHASDDHSAD");
                        SceneManager.LoadScene(FindObjectOfType<NextLevelName>().nextLevel);
                        this.enabled = false;
                        return;
                    }
                    musicHost host = FindObjectOfType<musicHost>();
                        int foundvalue = -1;
                        string currentScene = SceneManager.GetActiveScene().name;
                        for (int i = 0; i < host.sceneOrder.Length; i++)
                        {
                            if (host.sceneOrder[i] == currentScene)
                                foundvalue = i;
                        }
                        if (foundvalue != -1)
                        {
                            Debug.Log("USED FOUND VALUE");
                            SceneManager.LoadScene(host.sceneOrder[foundvalue + 1]);
                            return;

                        }
                    }
                    PlayerPrefs.SetInt("SceneLoad", SceneManager.GetActiveScene().buildIndex + 1);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); this.enabled = false;
                }
            }

        if (PlayerRigidBody)
            extraSpeed = Vector3.ClampMagnitude(PlayerRigidBody.velocity, 15);
        else
            PlayerRigidBody = GetComponent<Rigidbody>();
        animController.SetBool("IsAltFire", (Input.GetMouseButton(1) || Input.GetAxis("Fire2") > 0));
        if (Time.timeScale != 0)
        {
            if (!(Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 1")))
                spaceDown = false;
            if (!retroMode)
                GetComponent<Animator>().SetBool("Move", jumps == 0 && (Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")) > 0));
            if (animController.GetInteger("WeaponNum") == 10)
            GetComponent<Animator>().SetBool("Move", false);
            transPos = transform.position + extraSpeed;
            Quaternion rot = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
            float extraBoost = 0;
            if (speedBoostTime > Time.realtimeSinceStartup)
                extraBoost = 1.5f;
            transPos += (bhopspeed+CombospeedBoost+extraBoost) * JumpStreak * 60 * speedBoost * 45 * ((rot * Vector3.right) * Input.GetAxis("Horizontal") + (rot * Vector3.forward) * Input.GetAxis("Vertical")) / (52 / 1 + (JumpStreak / 9) + speedMultiplier);

            
            CameraJumping.SetBool("Jumping", jumps != 0);
            if (((scenename == false &&  jumps < 2) || jumps == 0 ) && (!groundLevels))
            {
                accelerate /= 1 + ((3 - jumps) * Time.fixedDeltaTime);
                if ((Input.GetKeyDown(KeyCode.Space)) && jumps != 0 && GetComponent<Rigidbody>().velocity.y < 2)
                {
                    spaceUp = true;
                    colliderSource.PlayOneShot(jumpSound, 1);
                        PlayerRigidBody.velocity = new Vector3(0, 20, 0);
                    jumptime = Time.realtimeSinceStartup + 0.1f;
                    JumpTime = Time.realtimeSinceStartup + 0.2f;
                    jumps++;
                    if (onejump)
                        PlayerRigidBody.velocity /= 3;

                }
                else if (PlayerPrefs.GetInt("BunnyHop") == 1 && ((Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 1"))) && jumps == 0 && Time.realtimeSinceStartup>jumptime)
                {
                    bhopspeed += (3 + bhopspeed) * Time.deltaTime;
                    firstJumpTime = Time.realtimeSinceStartup;
                    spaceUp = true;
                    if (colliderSource)
                        colliderSource.PlayOneShot(jumpSound, 1);
                    jumptime = Time.realtimeSinceStartup + 0.1f;
                    jumps++;
                    PlayerRigidBody.velocity = new Vector3(0, 20, 0);
                    if (onejump)
                        PlayerRigidBody.velocity /= 3;
                }
                else if ((Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 1")) && jumps == 0 && !spaceDown)
                {
                    spaceDown = true;
                    firstJumpTime = Time.realtimeSinceStartup;
                    spaceUp = true;
                    if (colliderSource)
                        colliderSource.PlayOneShot(jumpSound, 1);
                    JumpTime = Time.realtimeSinceStartup + 0.2f;
                    jumps++;
                    if (Time.realtimeSinceStartup < landTime + 0.3f && PlayerPrefs.GetInt("SuperBounce") == 1)
                    {
                        BoxCollider.GetComponent<boxColliders>().source.PlayOneShot(BoxCollider.GetComponent<boxColliders>().landClips[UnityEngine.Random.Range(0, BoxCollider.GetComponent<boxColliders>().landClips.Length - 1)]);
                        Debug.Log("BOOST");
                        PlayerRigidBody.velocity += new Vector3(0, 30, 0) + transform.forward * 25;
                        screenFlash.GetComponent<Image>().color = new Color(0, 0, 15, 0.05f);
                    }
                    PlayerRigidBody.velocity = new Vector3(0, 20, 0);
                    jumptime = Time.realtimeSinceStartup + 0.4f;
                    if (onejump)
                        PlayerRigidBody.velocity /= 3;
                }
                else if (jumps == 0)
                {
                    bhopspeed -= 4*Time.deltaTime;
                }
                bhopspeed = Mathf.Max(1, bhopspeed);
                spaceUp = !(Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 1"));
                
            }
            if (jumps == 0 && landTime == -50)
                landTime = Time.realtimeSinceStartup;
            else if (jumps != 0 && landTime != 50)
                landTime = -50;
            if (animController.GetInteger("WeaponNum") - 1 >= 0 && animController.GetInteger("WeaponNum") - 1 <= weaponAmmo.Length - 1)
            Ammo = weaponAmmo[animController.GetInteger("WeaponNum") - 1];
            {
                float lastWepp = animController.GetInteger("WeaponNum");
                bool switched = true;
                if (Input.GetKey("1"))
                {
                    animController.SetInteger("WeaponNum", 4);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;
                    tryEquipWeapon();
                    animController.enabled = false;
                    animController.enabled = true;

                    switched = true;
                    lastPistol = 0;
                }
                if (Input.GetKey("2") && equippedWeapons[6] || animController.GetInteger("WeaponNum") == 4 && retroLevel)
                {
                    animController.SetInteger("WeaponNum", 6);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;
                    tryEquipWeapon();
                    animController.enabled = false;
                    animController.enabled = true;

                    switched = true;
                }
                if (Input.GetKey("3") && equippedWeapons[9])
                {
                    animController.SetInteger("WeaponNum", 9);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;
                    tryEquipWeapon();
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
                    tryEquipWeapon();
                    switched = true;
                }
                if (Input.GetKey("5") && equippedWeapons[1] || nextWeapon == 1)
                {
                    animController.SetInteger("WeaponNum", 1);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;
                    animController.enabled = false;
                    animController.enabled = true;
                    tryEquipWeapon();
                    switched = true;
                }
                if (Input.GetKey("6") && equippedWeapons[3] || nextWeapon == 3)
                {
                    animController.SetInteger("WeaponNum", 3);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;
                    animController.enabled = false;
                    animController.enabled = true;
                    tryEquipWeapon();
                    switched = true;
                }
                if (Input.GetKey("7") && equippedWeapons[5] || nextWeapon == 5)
                {
                    animController.SetInteger("WeaponNum", 5);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;
                    animController.enabled = false;
                    animController.enabled = true;
                    tryEquipWeapon();
                    switched = true;
                }
                if (Input.GetKey("8") && equippedWeapons[10] || nextWeapon == 10)
                {
                    animController.SetInteger("WeaponNum", 10);
                    animController.SetBool("Switched", true);
                    nextWeapon = -1;
                    animController.enabled = false;
                    animController.enabled = true;
                    tryEquipWeapon();
                    switched = true;
                }

                if ((Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKey("joystick button 4")) && Time.realtimeSinceStartup > delayy)
                {
                    delayy = Time.realtimeSinceStartup + 0.35f;
                    int lastGoodwep = animController.GetInteger("WeaponNum");
                    int z = lastGoodwep + 1;
                    while ((!equippedWeapons[z] || (SceneManager.GetActiveScene().name.Contains("Retro") && z == 3)) && z < equippedWeapons.Length)
                        z++;
                    if (equippedWeapons[z] && z < equippedWeapons.Length)
                        animController.SetInteger("WeaponNum", z);
                    tryEquipWeapon();
                }
                if ((Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKey("joystick button 5")) && Time.realtimeSinceStartup > delayy)
                {
                    delayy = Time.realtimeSinceStartup + 0.35f;
                    int lastGoodwep = animController.GetInteger("WeaponNum");
                    int z = lastGoodwep - 1;
                    while ((!equippedWeapons[z] || (SceneManager.GetActiveScene().name.Contains("Retro") && z == 3) )&& z >= 0)
                        z--;
                    if (equippedWeapons[z] && z >= 0)
                        animController.SetInteger("WeaponNum", z);
                    tryEquipWeapon();

                }
                if (playerCamera)
                if (!playerCamera.GetComponent<CameraIntro>().enabled)
                {
                    if (Ccrosshair.GetComponent<RectTransform>().localPosition.y != -50)
                    {
                        hitMarker.GetComponent<RectTransform>().localPosition = Ccrosshair.GetComponent<RectTransform>().localPosition;
                        playerCamera.transform.position = transform.position + transform.up * (crosshairOffset * (Ccrosshair.GetComponent<RectTransform>().localPosition.y + 50));
                        playerCamera.transform.rotation = transform.rotation;
                        playerCamera.transform.Rotate((15 * (Ccrosshair.GetComponent<RectTransform>().localPosition.y + 50) / 50), 0, 0);

                    }
                    else
                        playerCamera.transform.rotation = transform.rotation;
                    if (!retroMode && !Intro)
                    {
                        crosshairOutside.SetActive(true);
                        playerCrosshair.SetActive(true);
                        crosshairObject.GetComponent<Image>().color = Color.white;
                        playerCrosshair.GetComponent<Image>().color = crosshairObject.GetComponent<Image>().color;
                        scanRefresh = false;
                    }

                }

                if (camdisabled)
                {
                    PlayerHealth = 100;
                    if (PlayerPrefs.GetString("Mode") == "One Life" || PlayerPrefs.GetString("Mode") == "Perfect Run")
                    {
                        if (transition)
                        {
                            transition.GetComponent<transition>().target = new Vector3(0, 0, 0);
                            transition.GetComponent<transition>().outro = true;
                            transition.GetComponent<transition>().scene = "Ground1";
                            if (loadMap == 0)
                                loadMap = Time.realtimeSinceStartup;
                            else if (loadMap + 5 < Time.realtimeSinceStartup)
                                SceneManager.LoadScene("Ground1");
                        }
                        else
                            SceneManager.LoadScene("Ground1");
                    }
                    else
                    {
                        if (transition)
                        {
                            Debug.Log("SCENE LOADING");
                            transition.GetComponent<transition>().target = new Vector3(0, 0, 0);
                            transition.GetComponent<transition>().outro = true;
                            transition.GetComponent<transition>().scene = SceneManager.GetActiveScene().name;
                            if (loadMap == 0)
                                loadMap = Time.realtimeSinceStartup;
                            else if (loadMap + 5 < Time.realtimeSinceStartup)
                                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        }
                        else
                        {
                            Debug.Log("SCENE LOADING WRONG");
                            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        }
                    }
                }
                if ((PlayerHealth < 1 && !Intro) || (heightlive == false && (StartY - 300 > transPos.y || ((StartY - 430 > transPos.y || StartY + 330 < transPos.y) && StartY != 0)) && !Intro || PlayerHealth < 0))
                {
                    foreach (RobotMoving h in FindObjectsOfType<RobotMoving>())
                    {
                        h.enabled = false;
                    }
                    foreach (LookatPlayer h in FindObjectsOfType<LookatPlayer>())
                    {
                        h.enabled = false;
                    }
                    foreach (runatPlayer h in FindObjectsOfType<runatPlayer>())
                    {
                        h.enabled = false;
                    }
                    GameObject.Find("Title").transform.parent = null;
                    
                        foreach (Canvas k in FindObjectsOfType<Canvas>())
                        {

                            k.gameObject.SetActive(false);
                        }
                    
                    deadCamera.SetActive(true);
                    deadCamera.transform.position = transform.position;
                    deadCamera.transform.rotation = transform.rotation;
                    deadCamera.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
                    Destroy(playerCamera);
                    transform.position = playerSpawn.transform.position;
                    Destroy(this);
                    transform.position += new Vector3(300, 0, 300);
                    transform.localScale *= 0;
                    playerCamera.transform.parent = null;
                    playerCamera.AddComponent<LookAt>();
                    playerCamera.GetComponent<Animator>().enabled = false;
                    camdisabled = true;

                }
                Vector3 change = transform.position;
                if (retroLevel)
                    change += (transPos - transform.position) / (80 * size);
                if (PlayerPrefs.GetString("Mode") == "Easy")
                    change += (transPos - transform.position) / (60 * size);
                if (PlayerPrefs.GetString("Mode") == "Hard")
                    change += (transPos - transform.position) / (40 * size);
                else
                    change += (transPos - transform.position) / (50 * size);
                PlayerRigidBody.MovePosition(change);
            }
        }
        if (superHot)
        {
            float change = Vector3.Distance(transform.position, lastHotPos);
            Time.timeScale = Mathf.Max(0.1f, change);
        }

    }
    public Vector3 raycast()
    {
        return transform.position - (playerCamera.transform.position - transform.position) + transform.forward * 100;
    }

    public void ScrollUp()
    {
        delayy = Time.realtimeSinceStartup + 0.15f;
        int lastGoodwep = animController.GetInteger("WeaponNum");
        int z = lastGoodwep + 1;
        while ((!equippedWeapons[z] || (SceneManager.GetActiveScene().name.Contains("Retro") && z == 3)) && z < equippedWeapons.Length)
            z++;
        if (equippedWeapons[z] && z < equippedWeapons.Length)
            animController.SetInteger("WeaponNum", z);
        if (lastGoodwep == 11 || animController.GetInteger("WeaponNum") == 11)
        {
            GetComponent<doneShooting>().Fire();
            animController.Play("LeftFire", 2);
            animController.Play("StartPistolFire", 0);
        }
        }
    public void ScrollDown()
    {
        delayy = Time.realtimeSinceStartup + 0.15f;
        int lastGoodwep = animController.GetInteger("WeaponNum");
        int z = lastGoodwep - 1;
        while ((!equippedWeapons[z] || (SceneManager.GetActiveScene().name.Contains("Retro") && z == 3)) && z >= 0)
            z--;
        if (equippedWeapons[z] && z >= 0)
            animController.SetInteger("WeaponNum", z);
        if (lastGoodwep == 11 || animController.GetInteger("WeaponNum") == 11)
        {
            GetComponent<doneShooting>().Fire();
            animController.Play("LeftFire", 2);
            animController.Play("StartPistolFire", 0);
        }
    }
    public void KillEnemy(GameObject collision, GameObject caller)
    {
        
        Destroy(caller);
        if (Time.realtimeSinceStartup > colliderSource.GetComponent<enemyHealth>().lastHitTime)
            colliderSource.GetComponent<enemyHealth>().lastHitTime = Time.realtimeSinceStartup + 0.1f;
        else
            return;
        collision.GetComponent<enemyHealth>().Currenthealth -= Mathf.Abs((float)(collision.GetComponent<enemyHealth>().startingHealth * ((collision.GetComponent<enemyHealth>().weaponDamages[animController.GetInteger("WeaponNum") - 1]))));
        GameObject.Find("HitMarker").GetComponent<Animator>().Play("HitMarker", -1, 0f);

        {
            if (lastText + 0.1f < Time.realtimeSinceStartup)
            {
                lastText = Time.realtimeSinceStartup;
                GameObject epicHealth = Instantiate(EdamageText);

                
                epicHealth.GetComponent<TextMesh>().fontSize = 100;
                epicHealth.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

                epicHealth.transform.position = collision.transform.position + transform.up * (5 + UnityEngine.Random.Range(-1, 3));
                epicHealth.GetComponent<TextMesh>().text =  (int)Mathf.Min(100, 100 * (collision.GetComponent<enemyHealth>().Currenthealth * (100/collision.GetComponent<enemyHealth>().startingHealth))) + "%";
                epicHealth.GetComponent<Rigidbody>().velocity.Set(0, 3, 0);
            }
            lastText = Time.realtimeSinceStartup;
        }

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
        if (collision.GetComponent<enemyHealth>().Currenthealth < 0.1f)// || PlayerPrefs.GetString("Mode") == "One Shot")
        {
            PlayerPrefs.SetInt("Kills", PlayerPrefs.GetInt("Kills")+1);
            if (Time.realtimeSinceStartup > combTime + 0.5f)
                comboCounter += 15f;
            combTime = Time.realtimeSinceStartup;
            combochangetime = Time.realtimeSinceStartup;

            if (PlayerHealth < 75)
            {
                if (PlayerPrefs.GetString("Mode") == "Easy")
                    PlayerHealth += 2 * (2 - collision.GetComponent<enemyHealth>().Currenthealth);
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
                            child.GetComponent<BoxCollider>().size /= 2;

                        child.name = "Dead";
                        child.layer = 13;
                        Destroy(child, 1);

                    }
                    if (collision.gameObject.GetComponent<BoxCollider>() != null)
                        GetComponent<BoxCollider>().size /= 2;
                    collision.gameObject.transform.LookAt(transform);
                    collision.gameObject.transform.Rotate(-90, 0, 0);
                    if (collision.GetComponent<Rigidbody>() != null)
                        collision.GetComponent<Rigidbody>().velocity = ((Vector3.up * 30) - (transform.forward * 20))/size;
                    if (collision.GetComponent<Rigidbody>() == null)
                        collision.AddComponent<Rigidbody>();
                    collision.transform.position += transform.up;
                    collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

                    collision.gameObject.tag = "dead";
                    collision.transform.tag = "dead";
                    foreach (Transform t in collision.transform)
                        t.gameObject.tag = "dead";
                    if (animController.GetInteger("WeaponNum") == 4)
                        Destroy(collision.gameObject, 0.5f);
                    else
                        DestroyEnemy(collision.gameObject);
                }
            }
        }

    }

    public void KillEnemy()
    {
        
    }

    public void test()
    {

    }


    public void KillEnemy(GameObject collision, bool asdf)
    {

        Debug.Log("HI! IM KILLING THIS ENEMY OK?");
        //transform.position += transform.up * 25;

        if (retroMode)
        {
            Destroy(collision.gameObject);
        }
        else
        {
            bool customDamage = false;
            if (collision.GetComponent<enemyHealth>())
            {
                float original = collision.GetComponent<enemyHealth>().Currenthealth;

                if (collision.GetComponent<enemyHealth>().weaponDamages.Length >= animController.GetInteger("WeaponNum") - 1)
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
                        PlayerPrefs.SetInt("Kills", PlayerPrefs.GetInt("Kills") + 1);
                        if (Time.realtimeSinceStartup > combTime + 0.5f)
                            comboCounter += 15f;
                        combTime = Time.realtimeSinceStartup;
                        combochangetime = Time.realtimeSinceStartup;
                        if (PlayerHealth < 75)
                        {
                            if (PlayerPrefs.GetString("Mode") == "Easy")
                                PlayerHealth += 2 * (2 - collision.GetComponent<enemyHealth>().Currenthealth);
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
                                        child.GetComponent<BoxCollider>().size /= 2;

                                    child.name = "Dead";
                                    child.layer = 13;
                                    Destroy(child, 1);

                                }
                                if (collision.gameObject.GetComponent<BoxCollider>() != null)
                                    GetComponent<BoxCollider>().size /= 2;
                                collision.gameObject.transform.LookAt(transform);
                                collision.gameObject.transform.Rotate(-90, 0, 0);
                                collision.GetComponent<Rigidbody>().velocity = ((Vector3.up * 30) - (transform.forward*20))/size;
                                if (collision.GetComponent<Rigidbody>() == null)
                                    collision.AddComponent<Rigidbody>();
                                collision.transform.position += transform.up;
                                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                                
                                collision.gameObject.tag = "dead";
                                collision.transform.tag = "dead";
                                foreach (Transform t in collision.transform)
                                    t.gameObject.tag = "dead";
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
                        epicHealth.GetComponent<TextMesh>().fontSize = 100;
                        epicHealth.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        epicHealth.transform.position = collision.transform.position + transform.up * 5;
                        epicHealth.GetComponent<TextMesh>().text = "-"+ Mathf.Min(100,Mathf.Round(100 * ((original - newF) / collision.GetComponent<enemyHealth>().startingHealth))) + "%";
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
            if (lastText + 0.1f < Time.realtimeSinceStartup)
            {
                lastText = Time.realtimeSinceStartup;
                GameObject epicHealth = Instantiate(EdamageText);
                epicHealth.transform.position = collision.transform.position + transform.up * 5;
                float original = collision.GetComponent<enemyHealth>().Currenthealth;
                collision.GetComponent<enemyHealth>().Currenthealth -= Mathf.Abs((float)(collision.GetComponent<enemyHealth>().startingHealth * ((collision.GetComponent<enemyHealth>().weaponDamages[animController.GetInteger("WeaponNum") - 1]))));
                float newF = collision.GetComponent<enemyHealth>().Currenthealth;
                if (newF < 0)
                    newF = 0;
                epicHealth.GetComponent<TextMesh>().fontSize = 100;
                epicHealth.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                epicHealth.GetComponent<TextMesh>().text = 100 + "%";
                epicHealth.GetComponent<Rigidbody>().velocity.Set(0, 9, 0);
            }
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
                        child.GetComponent<Rigidbody>().velocity = ((child.transform.position - collision.gameObject.transform.position) * 5)/size;
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
    /// <summary>
        /// Update music effects volume
        /// </summary>
        /// <param name="f"></param>
    public void UpdateSensitivity(float f){
        try
            {
        PlayerPrefs.SetFloat("Mouse", f*2);
            }
        catch
        {
            Debug.Log("Please assign music sources in the manager");
        }
    }

}


