using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FireScript : MonoBehaviour
{
    public float FireRate; public float GunDamage; public float gunPower;   public Texture2D damageimage;   
    public Rigidbody rb; public Texture2D crosshairImage; public GameObject quad; Vector3 v2; public GameObject PlayerTemp;
    public GameObject me; public Rigidbody muzzle; Vector3 vectors; public Rigidbody fire;  
    public GameObject left; public GameObject right; public GameObject back; 
    public GameObject grounded; public GameObject up; public CharacterController characterController; private Vector3 movePos;
    public GameObject bullet; public Rigidbody exit; public GameObject EmptyObj; public Animator ShotgunAnim;
    Vector3 bulletOffset; float moving; double force = 0; float shoottime; float movetime; double offsettime;
    public GameObject weaponOb; public Rigidbody weaponRig; Vector3 weaponPos; Vector3 fullweaponpos; Quaternion weaponRot;
    float rmbpressed; Vector3 bulletSpeed; public AudioSource jumpSound;    public GameObject Chaingun;
    Vector3 fullspeed; public GameObject tempmuzzle; public GameObject tempexit; public Rigidbody gunModel; Quaternion rot; public Object newBullet;
    float lmbpressed; float ctrlpressed; public GameObject Newbullet; public Rigidbody bulletRig;   public float weapondamage;
    float fov; float slowness; Vector3 moveF; float jumptime; float jumps;  GameObject AnimgunModel;
    public GameObject weaponpos; public GameObject shotgun; public GameObject assaultRifle; private Animation anim; public GameObject revolver;
    public SphereCollider sphcollide; float alreadyshot;    public TextMesh countdown;
    public AudioSource deathsound;  public TextMesh health; public float Playerhealth; public float hitdelay; public TextMesh enemycount; float wintime;
    public GameObject Mycamera; public GameObject firstPerson; public GameObject deadCam; float dead; float won;    
    public float equippedweapon;   public GameObject explode;   public Rigidbody explosion;   public float startuptime;
    public Camera playercamera; public float inwater;
    public TextMesh enemyhealth; public GameObject DamageTextObject;    public GameObject rocketlauncher;
    public float AssaultRifleAmmo; public float ShotgunAmmo;    public float RocketLauncherAmmo; public float ChaingunAmmo; public float RevolverAmmo;
    public float Ammo; public FontStyle GUIStyle;   public GameObject musicPlayer; public AudioSource music;
    private bool tb;    private bool bb;    private bool quitb; private float mouseXratio;  private float mouseYratio;
    private GUIStyle button;    private GUIStyle button2;   private GUIStyle quitbutton;    public bool escPressed; private float escStage;
    private float boxY; bool movedYet;  private Vector2 blackboxcurrent; private Vector2 blackboxtarget;    private string SceneName;
    private Vector2 introcurrent; private Vector2 introtarget;
    private Vector2 textcurrent; private Vector2 texttarget;    private float JumpStreak;

    void Start()
    {

        textcurrent = new Vector2(Screen.width * 1.5f, Screen.height / 2);
        texttarget = new Vector2(Screen.width /2, Screen.height / 2);
        blackboxcurrent = new Vector2(0, 0);
        blackboxtarget = new Vector2(0, Screen.height * 2);

        gameObject.tag = "Player";
        playercamera.cullingMask = 1 << 0;
        
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<SphereCollider>().radius = 0.5f;
        ShotgunAmmo = 15;
        AssaultRifleAmmo = 25;
        RocketLauncherAmmo = 5;
        ChaingunAmmo = 75;
        RevolverAmmo = 10;

        GameObject TRASH = GameObject.Find("Bullet (1)");
        GameObject.Destroy(TRASH);
        movedYet = false;

        startuptime = Time.realtimeSinceStartup;

        GameObject trail = GameObject.Find("Trail");
        trail.GetComponent<TrailRenderer>().enabled = false;

        
        musicPlayer = GameObject.FindGameObjectWithTag("musicPlayer");
        //musicPlayer.GetComponent<GlobalControl>().animDoneTime = 0;
        escStage = 1;
        escPressed = false;
        button = new GUIStyle();
        button.normal.textColor = Color.white;
        button.fontStyle = FontStyle.Bold;
        button.fontSize = 50;
        button2 = new GUIStyle();
        button2.normal.textColor = Color.white;
        button2.fontStyle = FontStyle.Bold;
        button2.fontSize = 50;
        quitbutton = new GUIStyle();
        quitbutton.normal.textColor = Color.white;
        quitbutton.fontStyle = FontStyle.Bold;
        quitbutton.fontSize = 100;

        PlayerPrefs.SetString("lastLevel", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();

        if (GameObject.FindGameObjectWithTag("musicPlayer") != null)
        GameObject.FindGameObjectWithTag("musicPlayer").GetComponent<AudioSource>().Play();
        AssaultRifleAmmo = 25 * PlayerPrefs.GetInt("Difficulty") / 2;
        ShotgunAmmo = 15 * PlayerPrefs.GetInt("Difficulty") / 2;
        RocketLauncherAmmo = 5 * PlayerPrefs.GetInt("Difficulty") / 2;
        ChaingunAmmo = 75 * PlayerPrefs.GetInt("Difficulty") / 2;
        RevolverAmmo = 10 * PlayerPrefs.GetInt("Difficulty") / 2;

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        gameObject.tag = "Player";
        if ((SceneManager.GetActiveScene().name) != "MainHub")
            GetComponent<SphereCollider>().radius = 0.5f;
        else
            GetComponent<SphereCollider>().radius = 0.2f;

        explode.transform.position = new Vector3(900, 900, 900);
        muzzle.GetComponent<MeshRenderer>().enabled = false;
        explode.GetComponent<MeshRenderer>().enabled = false;
        Playerhealth = 5 * PlayerPrefs.GetInt("Difficulty");
        equippedweapon = 2;
        moveF = transform.position;
        fov = 60;
        bulletSpeed = Vector3.MoveTowards(muzzle.position, exit.position, 15);
        movetime = 0;
        shoottime = 3;
        characterController = GetComponent<CharacterController>();
        bulletOffset = new Vector3(0, 0, 0);
        fullweaponpos = new Vector3(0, 0, 0);
        weaponRot = new Quaternion(0, 0, 0, 0);
        moving = 0;
        rmbpressed = 0;
        lmbpressed = 0;
        fullspeed = bulletSpeed;
        rot = rb.rotation;
        alreadyshot = 0;
        hitdelay = 0;
        wintime = 0;
        dead = 0;
        
        if ((SceneManager.GetActiveScene().name) == "MainHub")
        {
            equippedweapon = 4;
        }


        AudioSource[] sounds = GetComponents<AudioSource>();
        for (int i = 0; i<(sounds.Length); i++)
        {
            if (sounds[i] != jumpSound && sounds[i] != deathsound)
            {
                sounds[i].volume = 0;
            }
                
        }
        musicPlayer = GameObject.FindGameObjectWithTag("musicPlayer");

        AnimgunModel = shotgun;
        Newbullet.GetComponent<BulletShooting>().size = 10;
        Newbullet.GetComponent<BulletShooting>().damage = 3;
        Newbullet.GetComponent<BulletShooting>().speed = .1f;

        shotgun.SetActive(true);
        revolver.SetActive(false);
        assaultRifle.SetActive(false);
        Chaingun.SetActive(false);
        rocketlauncher.SetActive(false);

        Ammo = ShotgunAmmo;

        equippedweapon = 1;

        introtarget = new Vector2(0, Screen.height * 2);
        introcurrent = new Vector2(0, 0);
    }

    void OnGUI()
    {
        introcurrent += (introtarget - introcurrent) * 0.02f;
        Texture2D texture2 = new Texture2D(1, 1);
        texture2.SetPixel(0, 0, Color.black);
        texture2.Apply();
        GUI.skin.box.normal.background = texture2;
        Rect position2 = new Rect();
        position2.position = introcurrent;
        position2.size = new Vector2(Screen.width, Screen.height);
        GUI.Box(position2, GUIContent.none);

        //Color color = Color.green;
        // Rect rectangle = new Rect;
        //rectangle.size = new Vector2(Screen.width, Screen.height);


        GUIStyle labelText = new GUIStyle();
        GUIStyle numText = new GUIStyle();
        labelText.fontSize = 20;
        numText.fontSize = 50;
        labelText.fontStyle = FontStyle.Bold;
        //Show Box
        
        if (SceneManager.GetActiveScene().name != "MainHub")
        {
            if (Input.GetKeyDown("escape") && escStage == 1)
                escStage = 2;
            else if (Input.GetKeyUp("escape") && escStage == 2)
            {
                escStage = 3;
                escPressed = true;
            }
            else if (Input.GetKeyDown("escape") && escStage == 3)
                escStage = 4;
            else if (Input.GetKeyUp("escape") && escStage == 4) {
                escStage = 1;
                escPressed = false;
            }

            if (escPressed)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                mouseXratio = (Input.mousePosition.x / Screen.width);
                mouseYratio = (Input.mousePosition.y / Screen.height);


                tb = false;
                bb = false;
                quitb = false;

                if (mouseXratio < 0.26 && mouseYratio < 0.6 && mouseYratio > 0.5)
                    tb = true;
                if (mouseXratio < 0.26 && mouseYratio < 0.45 && mouseYratio > 0.35)
                    bb = true;
                if (mouseXratio < 0.26 && mouseYratio < 0.3 && mouseYratio > 0.2)
                    quitb = true;


                GUI.Label(new Rect(Screen.width * 0.1f, -75 + (Screen.height * 1.5f) / 10, 100, 20), "", quitbutton);
                GUI.Label(new Rect(Screen.width * 0.15f, -75 + (Screen.height * 3f) / 10, 100, 20), "PAUSED", quitbutton);


                if (tb)
                    GUI.Label(new Rect(Screen.width * 0.15f, -75 + (Screen.height * 5f) / 10, 100, 20), "New Game", button2);
                else
                    GUI.Label(new Rect(Screen.width * 0.1f, -75 + (Screen.height * 5f) / 10, 100, 20), "New Game", button2);

                if (bb)
                    GUI.Label(new Rect(Screen.width * 0.15f, -75 + (Screen.height * 6.5f) / 10, 100, 20), "Restart", button);
                else
                    GUI.Label(new Rect(Screen.width * 0.1f, -75 + (Screen.height * 6.5f) / 10, 100, 20), "Restart", button);

                if (quitb)
                    GUI.Label(new Rect(Screen.width * 0.15f, -75 + (Screen.height * 8f) / 10, 100, 20), "Quit", button);
                else
                    GUI.Label(new Rect(Screen.width * 0.1f, -75 + (Screen.height * 8f) / 10, 100, 20), "Quit", button);
               
                if (Input.GetMouseButtonDown(0) && (tb || bb || quitb))
                {
                    if (quitb)
                    {
                        Debug.Log("Quitting!");
                        Application.Quit();
                        
                    }
                    else if (tb)
                    {
                        PlayerPrefs.SetString("lastLevel", "Ground1");
                        PlayerPrefs.SetFloat("AssaultRifle", 0);
                        PlayerPrefs.SetFloat("Shotgun", 1);
                        PlayerPrefs.SetFloat("Revolver", 0);
                        PlayerPrefs.SetFloat("Chaingun", 0);
                        PlayerPrefs.SetFloat("RocketLauncher", 0);
                    }
                    {
                        blackboxtarget = new Vector2(0, 0);
                        SceneName = ((PlayerPrefs.GetString("lastLevel")));
                    }
                    GameObject musicPlayer = GameObject.FindGameObjectWithTag("musicPlayer");
                    

                }
            }
            else
            {
                if (Time.realtimeSinceStartup > 0.1f && movedYet)
                {
                    movedYet = true;
                    moveF = Vector3.MoveTowards(transform.position, back.transform.position, 15);
                    moveF.y = transform.position.y;
                    transform.position += (transform.position - moveF) / slowness * 240 * Time.deltaTime;
                }
                    
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                //Show Ammo
                GUI.Label(new Rect(Screen.width / 10, (Screen.height * 8.5f) / 10, 100, 20), "Ammo:", labelText);
                GUI.Label(new Rect(Screen.width / 10, (Screen.height * 9) / 10, 100, 20), ("  " + Ammo), numText);
                //Show Health
                GUI.Label(new Rect(2 * Screen.width / 10, (Screen.height * 8.5f) / 10, 100, 20), "Health:", labelText);
                GUI.Label(new Rect(2 * Screen.width / 10, (Screen.height * 9) / 10, 100, 20), ("  " + Playerhealth), numText);
                //Show Time
                GUI.Label(new Rect(1 * Screen.width / 15, (Screen.height * 1) / 15, 100, 20), "Time:", labelText);
                GUI.Label(new Rect(1 * Screen.width / 15, (Screen.height * 1.5f) / 15, 100, 20), "" + Mathf.RoundToInt(Time.realtimeSinceStartup - startuptime), numText);
                //Show Enemies
                GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
                GUI.Label(new Rect(8 * Screen.width / 10, (Screen.height * 8.5f) / 10, 100, 20), "Enemies:", labelText);
                GUI.Label(new Rect(8 * Screen.width / 10, (Screen.height * 9) / 10, 100, 20), "" + Enemies.Length, numText);
                //Show Floor
                string  floor = SceneManager.GetActiveScene().name;
                string finalFloor = floor.Substring(5, floor.Length - 5);
                GUI.Label(new Rect(9 * Screen.width / 10, (Screen.height * 8.5f) / 10, 100, 20), "Floor:", labelText);
                GUI.Label(new Rect(9 * Screen.width / 10, (Screen.height * 9) / 10, 100, 20), "" + finalFloor, numText);

                float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
                float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
                GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
                xMin = (Screen.width / 2) - (damageimage.width / 2);
                yMin = (Screen.height / 2) - (damageimage.height / 2);
                if (hitdelay > Time.realtimeSinceStartup)
                {
                    //GUI.DrawTexture(new Rect(xMin, yMin, damageimage.width, damageimage.height), damageimage);
                }
            }
        }
        string floor2 = SceneManager.GetActiveScene().name;
        string finalFloor2 = floor2.Substring(5, floor2.Length - 5);
        if (Playerhealth < 1 || quad.transform.position.y < 120)
        {

            textcurrent = new Vector2(Screen.width * -2, Screen.height / 2);
        }
        else if (blackboxtarget == new Vector2(0, 0) && blackboxcurrent == blackboxtarget)
        {

            textcurrent += (texttarget - textcurrent) * 0.02f;
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, Color.black);
            texture.Apply();
            GUI.skin.box.normal.background = texture;
            Rect position = new Rect();
            position.position = blackboxcurrent;
            position.size = new Vector2(Screen.width, Screen.height);
            GUI.Box(position, GUIContent.none);

            GUIStyle levelText2 = new GUIStyle();
            levelText2.normal.textColor = Color.red;
            levelText2.fontSize = 105;
            levelText2.alignment = TextAnchor.MiddleCenter;


            if (Mathf.Abs(textcurrent.x - (Screen.width / 2)) < 15)
            {
                texttarget = new Vector2(Screen.width * -2, Screen.height / 2);
            }

            floor2 = SceneManager.GetActiveScene().name;
            finalFloor2 = floor2.Substring(5, floor2.Length - 5);

            var centeredStyle = GUI.skin.GetStyle("Label");
            centeredStyle.alignment = TextAnchor.UpperCenter;

            string[] levelnames = { "Back to Square One", "Tower Islands", "Rise and Shine", "the unforGiving Tree", "The Catapult", "Sea Tower", "Castle Crashing", "Doomed Dungeon", "The Four Towers", "The Final Battle", "Thanks for Playing!" };

            GUI.Label(new Rect(textcurrent.x, textcurrent.y, 100, 20), levelnames[(int)float.Parse(finalFloor2)], levelText2);

            levelText2.fontSize = 40;
            GUI.Label(new Rect(textcurrent.x, textcurrent.y * (1/1.3f), 100, 20), "Now Entering:", levelText2);
            GUI.Label(new Rect(textcurrent.x, textcurrent.y * 1.3f, 100, 20), "Floor " + ((int)float.Parse(finalFloor2)+1), levelText2);
        }
    }

    float GroundDistance;
    bool IsGrounded()

    {
        return Physics.Raycast(grounded.transform.position, -Vector3.up * 2, GroundDistance + 0.3f);
    }
    // Update is called once per frame

    void Update()
    {

        if (PlayerPrefs.GetInt("Difficulty") == 4 && Playerhealth > 1)
        {
            Playerhealth = 1;
        }
        if (blackboxtarget == new Vector2(0, 0) && blackboxcurrent == blackboxtarget && textcurrent.x <= (5 + Screen.width * -2))
        {
            PlayerPrefs.SetString("lastLevel", SceneName);
            SceneManager.LoadScene(SceneName);
        }
            

        if (textcurrent.x < (Screen.width / 2))
        blackboxcurrent.y += (blackboxtarget.y - blackboxcurrent.y) * 0.2f;

        if (GetComponent<Camera>())
        GetComponent<Camera>().enabled = false;

        if (bullet == null)
        {
            //SceneManager.LoadScene("MainMenu");
        }
        if (Playerhealth < 1 || quad.transform.position.y < 120)
        {
            //Mycamera.transform.position = deadCam.transform.position;
            //Mycamera.transform.LookAt(PlayerTemp.transform.position);
            //THIS IS TEMPORARY
            if (Time.realtimeSinceStartup > 3 + startuptime)
            {
                {
                    textcurrent = new Vector2(Screen.width * 1.5f, Screen.height / 2);
        texttarget = new Vector2(Screen.width /2, Screen.height / 2);
        blackboxcurrent = new Vector2(0, 0);
        blackboxtarget = new Vector2(0, Screen.height * 2);
                    blackboxtarget = new Vector2(0, 0);
                    SceneName = SceneManager.GetActiveScene().name;
                }
            }
            

            if (dead == 0 && !(wintime == 0 && SceneManager.GetActiveScene().name != "MainHub") && !(wintime != 0 && wintime < Time.realtimeSinceStartup) && wintime != -50 && (startuptime + 3 < Time.realtimeSinceStartup))
            {



                countdown.text = ("YOU DIED!");
                enemycount.text = ("You died!");
                dead = Time.realtimeSinceStartup + 4;
                explode.GetComponent<MeshRenderer>().enabled = true;
                explosion.AddExplosionForce(10, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), 20);
                for (float i = 1; i < 22; i++)
                {

                    Object Explodey = GameObject.Instantiate(explosion, new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + Random.Range(-2, 2), transform.position.z + Random.Range(-2, 2)), transform.rotation);
                    Destroy(Explodey, 1);
                }

            }
            else if (dead < Time.realtimeSinceStartup && !(wintime == 0 && SceneManager.GetActiveScene().name != "MainHub"))
            {
                if (Time.realtimeSinceStartup > 3 + startuptime)
                {
                    blackboxtarget = new Vector2(0, 0);
                    SceneName = SceneManager.GetActiveScene().name;
                }
            }
        }
        else
        {
            //Mycamera.transform.position = firstPerson.transform.position;
            if (Time.realtimeSinceStartup < 3 + startuptime)
            {
                countdown.text = ("" + Mathf.Round(3 - (Time.realtimeSinceStartup - startuptime)));
            }
            else
            {
                countdown.text = ("");
                GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
                float enemynum = 0;
                foreach (GameObject target in Enemies)
                {
                    enemynum++;
                }


                if (enemynum != 0)
                    enemycount.text = ("");
                else if (wintime == 0 && SceneManager.GetActiveScene().name != "MainHub")
                {
                    PlayerPrefs.Save();
                    wintime = Time.realtimeSinceStartup + 3;
                    enemycount.text = ("You Win!");
                    GameObject.FindGameObjectWithTag("musicPlayer").GetComponent<AudioSource>().Stop();
                }
            }
        }


        if ((wintime != 0 && wintime < Time.realtimeSinceStartup) && wintime != -50 && (startuptime+3 < Time.realtimeSinceStartup))
        {
            wintime = -50;
            if (Time.realtimeSinceStartup > 3 + startuptime)
            {
                if (SceneManager.GetActiveScene().name == "Ground1")
                    SceneName = (("Level2"));

                if (SceneManager.GetActiveScene().name == "Level2")
                    SceneName = (("Level3"));

                if (SceneManager.GetActiveScene().name == "Level3")
                    SceneName = (("Level4"));

                if (SceneManager.GetActiveScene().name == "Level4")
                    SceneName = (("Level5"));

                if (SceneManager.GetActiveScene().name == "Level5")
                    SceneName = (("Level6"));

                if (SceneManager.GetActiveScene().name == "Level6")
                    SceneName = (("Level7"));

                if (SceneManager.GetActiveScene().name == "Level7")
                    SceneName = (("Level8"));

                if (SceneManager.GetActiveScene().name == "Level8")
                    SceneName = (("Level9"));

                if (SceneManager.GetActiveScene().name == "Level9")
                    SceneName = (("Ground10"));

                if (SceneManager.GetActiveScene().name == "Ground10")
                    SceneName = (("Ground11"));

                if (SceneManager.GetActiveScene().name == "Ground11")
                    SceneName = (("Ground12"));

                if (SceneManager.GetActiveScene().name == "Ground12")
                    SceneName = (("Ground13"));

                PlayerPrefs.SetString("lastLevel", SceneName);
                blackboxtarget = new Vector2(0, 0);
            }
        }
        
        alreadyshot = 0;

        if (escPressed)
        {
            //playercamera.GetComponent<PostProcessingBehaviour>().profile = musicPlayer.GetComponent<GlobalControl>().blur;
        }
        else if (inwater == 1)
        {
            fov = 100;



        }
        else
        {



            fov = 120;
            
            rb.useGravity = true;
        }

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        
foreach (GameObject target in bullets)
        {
            if (alreadyshot == 0)
            {
                float distance = Vector3.Distance(target.transform.position, transform.position);
                if (distance < 2 || (PlayerPrefs.GetInt("Difficulty") != 4 && distance < 5) && distance != 0 && Time.realtimeSinceStartup > 5 && hitdelay< Time.realtimeSinceStartup) {
                    alreadyshot = 1;
                    Playerhealth--;
                    hitdelay = Time.realtimeSinceStartup+1;
                    deathsound.Play();
                }
                    
                
            }

        }
        if (Playerhealth > 1)
        {
            health.text = ("");
        }
        


        if (equippedweapon == 0 || SceneManager.GetActiveScene().name == "MainHub")
        {

            shotgun.SetActive(false);
            revolver.SetActive(false);
            assaultRifle.SetActive(false);
            Chaingun.SetActive(false);
            rocketlauncher.SetActive(false);
        }
        else
        {
            if (equippedweapon == 1)
            {
                AnimgunModel = shotgun;
                Newbullet.GetComponent<BulletShooting>().size = 10;
                Newbullet.GetComponent<BulletShooting>().damage = 3;
                Newbullet.GetComponent<BulletShooting>().speed = .1f;

                shotgun.SetActive(true);
                revolver.SetActive(false);
                assaultRifle.SetActive(false);
                Chaingun.SetActive(false);
                rocketlauncher.SetActive(false);

                Ammo = ShotgunAmmo;
            }
            else if (equippedweapon == 2)
            {
                

                AnimgunModel = assaultRifle;
                Newbullet.GetComponent<BulletShooting>().speed = .15f;
                Newbullet.GetComponent<BulletShooting>().size = .5f;
                Newbullet.GetComponent<BulletShooting>().damage = .2f;

                shotgun.SetActive(false);
                revolver.SetActive(false);
                assaultRifle.SetActive(true);
                Chaingun.SetActive(false);
                rocketlauncher.SetActive(false);

                Ammo = AssaultRifleAmmo;
            }
            else if (equippedweapon == 3)
            {
                AnimgunModel = revolver;
                Newbullet.GetComponent<BulletShooting>().speed = 1.5f;
                Newbullet.GetComponent<BulletShooting>().size = .3f;
                Newbullet.GetComponent<BulletShooting>().damage = 2f;

                shotgun.SetActive(false);
                revolver.SetActive(true);
                assaultRifle.SetActive(false);
                Chaingun.SetActive(false);
                rocketlauncher.SetActive(false);

                Ammo = RevolverAmmo;
            }
            else if (equippedweapon == 4)
            {
                Newbullet.GetComponent<BulletShooting>().speed = .35f;
                Newbullet.GetComponent<BulletShooting>().size = .2f;
                Newbullet.GetComponent<BulletShooting>().damage = .3f;
                AnimgunModel = Chaingun;


                shotgun.SetActive(false);
                revolver.SetActive(false);
                assaultRifle.SetActive(false);
                Chaingun.SetActive(true);
                rocketlauncher.SetActive(false);

                Ammo = ChaingunAmmo;
            }
            else if (equippedweapon == 5)
            {
                Newbullet.GetComponent<BulletShooting>().size = 10;
                Newbullet.GetComponent<BulletShooting>().damage = 6;
                Newbullet.GetComponent<BulletShooting>().speed = .09f;
                AnimgunModel = rocketlauncher;

                rocketlauncher.SetActive(true);
                shotgun.SetActive(false);
                revolver.SetActive(false);
                assaultRifle.SetActive(false);
                Chaingun.SetActive(false);

                Ammo = RocketLauncherAmmo;
            }
        }


        if (Input.GetMouseButtonDown(1))
            rmbpressed = 1;
        else if (Input.GetMouseButtonUp(1))
            rmbpressed = 0;


        if (equippedweapon == 4)
            lmbpressed = 0;
        else if (Input.GetMouseButtonDown(0))
            lmbpressed = 1;
        else if (Input.GetMouseButtonUp(0))
            

        if (Input.GetKeyDown(KeyCode.LeftControl))
            ctrlpressed = 1;

        else if (Input.GetKeyUp(KeyCode.LeftControl))
            ctrlpressed = 0;

        if (ctrlpressed == 1)
            Time.timeScale = 1f;
        else
            Time.timeScale = 0.7f;



        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        bullet.transform.localScale = new Vector3(0.1F, 0.1F, 0.1F);
        if (rb.velocity.y > 10)
        {
            Vector3 velocity2 = rb.velocity;
            velocity2.y = 10;
            rb.velocity = velocity2;
        }
        Vector3 velocity = rb.velocity;
        velocity.x = 0;
        velocity.z = 0;
        rb.velocity = velocity;




            if (SceneManager.GetActiveScene().name == "MainHub")
                equippedweapon = 0;
            if (Input.GetKey("1") && PlayerPrefs.GetFloat("Shotgun") == 1)
                equippedweapon = 1;
            if (Input.GetKey("2") && PlayerPrefs.GetFloat("AssaultRifle") == 1)
                equippedweapon = 2;
            if (Input.GetKey("3") && PlayerPrefs.GetFloat("Revolver") == 1)
                equippedweapon = 3;
            if (Input.GetKey("4") && PlayerPrefs.GetFloat("Chaingun") == 1)
                equippedweapon = 4;
            if (Input.GetKey("5") && PlayerPrefs.GetFloat("RocketLauncher") == 1)
                equippedweapon = 5;

            if (equippedweapon == 5 && PlayerPrefs.GetFloat("RocketLauncher") != 1)
                equippedweapon = 4;
            if (equippedweapon == 4 && PlayerPrefs.GetFloat("Chaingun") != 1)
                equippedweapon = 3;
            if (equippedweapon == 3 && PlayerPrefs.GetFloat("Revolver") != 1)
                equippedweapon = 2;
            if (equippedweapon == 2 && PlayerPrefs.GetFloat("AssaultRifle") != 1)
                equippedweapon = 1;
        if (Time.realtimeSinceStartup > 3 + startuptime && Playerhealth >= 1 || SceneManager.GetActiveScene().name == "MainHub")
        {


            

            if (inwater == 1)
                jumps = 0;

            slowness /= 1 + (JumpStreak / 9);
            if (Input.GetKey(KeyCode.LeftShift))
                slowness = 8;
            else
                slowness = 10;

            if (Input.GetKey("w"))
            {
                moveF = Vector3.MoveTowards(transform.position, back.transform.position, 15);
                moveF.y = transform.position.y;
                transform.position += (transform.position - moveF) / slowness * 120 * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                moveF = Vector3.MoveTowards(transform.position, back.transform.position, 15);
                moveF.y = transform.position.y;
                transform.position += (moveF - transform.position) / slowness * 120 * Time.deltaTime;
            }
             if (Input.GetKey(KeyCode.LeftShift))
                slowness = 32;
            else
                slowness = 40;

            if (Input.GetKey("w"))
            {
                moveF = Vector3.MoveTowards(transform.position, back.transform.position, 15);
                moveF.y = transform.position.y;
                transform.position += (transform.position - moveF) / slowness * 240 * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                moveF = Vector3.MoveTowards(transform.position, left.transform.position, 15);
                moveF.y = transform.position.y;
                transform.position += (transform.position - moveF) / slowness * 4 * 240 * Time.deltaTime;
            }

            if (Input.GetKey("a"))
            {
                moveF = Vector3.MoveTowards(transform.position, left.transform.position, 15);
                moveF.y = transform.position.y;
                transform.position += (moveF - transform.position) / slowness * 4 *240 * Time.deltaTime;
            }
            Debug.Log("Jump Streak: " + JumpStreak);
            if (!(Input.GetAxis("Jump") != 0) && (Physics.Raycast(transform.position, -Vector3.up, sphcollide.bounds.extents.y + 0.1f)))
            {
                JumpStreak = 0;
            }
            if (((Input.GetAxis("Jump") != 0 && jumps == 0 && (jumptime + 1 < Time.realtimeSinceStartup) && (Physics.Raycast(transform.position, -Vector3.up, sphcollide.bounds.extents.y + 0.1f))) || Input.GetKeyDown("space") && (jumptime + 0.3 < Time.realtimeSinceStartup))  && jumps < 2)
            {
                if (!Input.GetKeyDown("space") && (Physics.Raycast(transform.position, -Vector3.up, sphcollide.bounds.extents.y + 0.1f)))
                {
                    JumpStreak++;
                }
                jumpSound.Play();
                jumptime = Time.realtimeSinceStartup;
                Vector3 moveF = rb.velocity;
                jumps++;
                moveF.y = 10 * jumps;
                rb.velocity = moveF;

            }

            if (Physics.Raycast(transform.position, -Vector3.up, sphcollide.bounds.extents.y + 0.1f))
                jumps = 0;
            else
            {

            }


            if (Input.GetMouseButtonDown(2))


                if (force > 0)
                {
                    force = force * 0.99;
                }
                else
                {
                    force = 0;
                }

        }

    }

}
