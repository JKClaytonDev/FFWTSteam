using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;

using UnityEngine.Rendering.HighDefinition;

public class CameraIntro : MonoBehaviour
{
    public GameObject text; bool set;
    float rotationX;
    float rotationY;
    public string[] levelNames;
    Vector3 rotValues;
    int start;
    Vector3 pos;    Quaternion playerRot;
    Vector3 oldPos; Vector3 startPos;
    Quaternion oldRot;  public GameObject player;
    Vector3 newPos; public GameObject text1;
    Vector2 target; public GameObject text2;
    Vector2 current; public GameObject health;
    float moveCount; public GameObject ammo;
    float distance;     Vector3 newTPos;
    string subtitle;     float startTime;
    Quaternion newRot;
    Vector3 oldPlayerPos; Quaternion oldplayerRot;
    public string[] SkipIntro;
    // Start is called before the first frame update
    void OnEnable()
    {
        GetComponent<AudioSource>().clip = null;
        GetComponent<AudioSource>().Stop();
        if (SceneManager.GetActiveScene().name != "Level2")
            GetComponent<Camera>().allowMSAA = (QualitySettings.GetQualityLevel() <= 1);
        GetComponent<Camera>().allowHDR = (QualitySettings.GetQualityLevel() <= 1);
        if (PlayerPrefs.GetInt("NoClip") == 1)
        {
            if (GameObject.Find("PlayerSpawn"))
                transform.position = GameObject.Find("PlayerSpawn").transform.position;
            transform.parent = null;
            return;
        }
        set = false;
        start = Random.Range(1, 6);
        Vector3 oldPos = transform.position;
        bool skip = false;
        if (PlayerPrefs.GetString("Mode") == "Reverse")
            skip = true;
        foreach(string s in SkipIntro)
        {
            if (s == SceneManager.GetActiveScene().name)
                skip = true;
        }
        if (skip)
        {
            //transform.parent = player.transform;
            player.GetComponent<Animator>().Play("spawnEquip");
            text1.GetComponent<Text>().enabled = false;
            text2.GetComponent<Text>().enabled = false;
            health.SetActive(true);
            ammo.SetActive(true);
            Destroy(GetComponent<Rigidbody>());
            player.transform.position = GameObject.Find("PlayerSpawn").transform.position;
            this.enabled = false;
        }
        else
        {
            oldPlayerPos = GameObject.Find("PlayerSpawn").transform.position;
            oldplayerRot = player.transform.rotation;
            transform.parent = null;
            startTime = Time.realtimeSinceStartup;
            text1.SetActive(true);
            text2.SetActive(true);
            health.SetActive(false);
            ammo.SetActive(false);
            if (GameObject.Find("PlayerSpawn") == null)
                startPos = player.transform.position;
            else
                startPos = GameObject.Find("PlayerSpawn").transform.position;
            if (!player)
            player = GameObject.Find("Player");
            if (player.GetComponent<Movement>().Intro)
            {
                transform.position = player.transform.position;
                transform.rotation = player.transform.rotation;
                this.enabled = false;
                //Destroy(this);
                GetComponent<CameraIntro>().enabled = false;
            }
            else
            {
                playerRot = player.transform.rotation;
                current.y = Screen.height / 2;
                current.x = Screen.width * 2;
                target.x = Screen.width / 2;
                target.y = Screen.height / 2;
                moveCount = 1;
                GetComponent<Animator>().enabled = false;
                if (FindObjectOfType<portalLevel>() != null)
                {
                    Debug.Log("Found Portal");
                    pos = FindObjectOfType<portalLevel>().gameObject.transform.position;
                    subtitle = "Reach the Portal";
                    oldPos = FindObjectOfType<portalLevel>().gameObject.transform.position;
                    transform.position = FindObjectOfType<portalLevel>().gameObject.transform.position;
                    transform.LookAt(FindObjectOfType<portalLevel>().gameObject.transform.position);
                }
                else
                {
                    GameObject[] imStuff = FindObjectsOfType(typeof(GameObject)) as GameObject[];
                    pos = new Vector3(0, 0, 0);
                    float count = 0;
                    foreach (GameObject g in imStuff)
                    {
                        {
                            pos += g.transform.position;
                            count++;
                        }
                    }
                    pos /= count;
                    oldPos = pos;
                    subtitle = "Kill all Enemies";
                    transform.LookAt(player.transform);
                }
                transform.position = oldPos;
                oldRot = transform.rotation;
                
            }
            distance = Vector3.Distance(transform.position, GameObject.Find("PlayerSpawn").transform.position);
            text2.GetComponent<Text>().text = subtitle;
        }
        text.SetActive(!skip);
        newTPos = transform.position;
        /*
        if (QualitySettings.GetQualityLevel() == 0)
        {


            GameObject[] imStuff = FindObjectsOfType(typeof(GameObject)) as GameObject[];

            foreach (GameObject item in imStuff)
            {

                if (item != gameObject)
                {
                    if (item.GetComponent<Volume>())
                    {
                        Volume v = item.GetComponent<Volume>();
                        VisualEnvironment x;

                        if (!v.profile.TryGet(out x))
                        {
                            Destroy(item.GetComponent<Volume>());
                        }

                    }

                    if (item.GetComponent<ParticleSystem>() != null)
                    {
                        Destroy(item.GetComponent<ParticleSystem>());
                    }
                    if (item.GetComponent<ReflectionProbe>() != null)
                    {
                        Destroy(item.GetComponent<ReflectionProbe>());
                    }

                    if (item.GetComponent<MeshRenderer>() != null)
                    {
                        MeshRenderer m = item.GetComponent<MeshRenderer>();
                        foreach (Material r in m.materials)
                            r.SetTextureScale("_BaseColorMap", new Vector2(0.01f, 0.01f));
                    }
                    if (item.GetComponent<SkinnedMeshRenderer>() != null)
                    {
                        SkinnedMeshRenderer m = item.GetComponent<SkinnedMeshRenderer>();
                        foreach (Material r in m.materials)
                            r.SetTextureScale("_BaseColorMap", new Vector2(0.01f, 0.01f));
                    }
                    if (item.GetComponent<Renderer>() != null)
                    {
                        Renderer m = item.GetComponent<Renderer>();
                        foreach (Material r in m.materials)
                            r.SetTextureScale("_BaseColorMap", new Vector2(0.01f, 0.01f));
                    }
                }
            }
        }
        */
    }
    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("NoClip") == 1)
        {
            
            rotationY += Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * 15 * PlayerPrefs.GetFloat("Mouse");
            rotationX += Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * 15 * PlayerPrefs.GetFloat("Mouse");
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            transform.position += transform.right * Input.GetAxis("Horizontal") * 5;
            transform.position += transform.forward * Input.GetAxis("Vertical") * 5;
            if (Input.GetKey(KeyCode.Escape))
                SceneManager.LoadScene("MainMenu");
            return;
        }

            
            transform.position = player.transform.position;
        if (Time.realtimeSinceStartup > 1)
        {
            if (transform.position == player.transform.position || Vector3.Distance(transform.position, oldPlayerPos) < 2)
            {
                text.SetActive(false);
                transform.parent = player.transform;
                text1.GetComponent<Text>().enabled = false;
                text2.GetComponent<Text>().enabled = false;
                health.SetActive(true);
                ammo.SetActive(true);
                Destroy(GetComponent<Rigidbody>());
                transform.position = player.transform.position;
                transform.rotation = player.transform.rotation;

                if (player.GetComponent<Animator>().GetInteger("WeaponNum") == 4)
                    player.GetComponent<Animator>().Play("spawnEquip");
                Vector3 pos = GameObject.Find("PlayerSpawn").transform.position;
                if (pos.y > player.transform.position.y)
                    pos.y = player.transform.position.y;
                player.transform.position = pos;
                player.GetComponent<Movement>().enabled = true;
                this.enabled = false;

            }
        }
        if (transform.position.y < player.transform.position.y)
            transform.position = new Vector3(transform.position.x, player.transform.position.y + (player.transform.position.y - transform.position.y), transform.position.z);


        transform.LookAt(player.transform.position);
        //GameObject.Find("PlayerSpawn").transform.position = oldPlayerPos;
        player.transform.rotation = oldplayerRot;
        //transform.rotation = player.transform.rotation;
        transform.position = player.transform.position;
        if (!set && (Time.realtimeSinceStartup < startTime+1 || startTime == 0))
        {
            if (start == 1)
            transform.position = FindObjectOfType<portalLevel>().gameObject.transform.position;
            else if (start == 2)
                transform.position = player.transform.position + transform.up * 260;
            else if (start == 3)
                transform.position = player.transform.position + transform.right * 260;
            else if (start == 4)
                transform.position = player.transform.position + transform.forward * 260;
            else if (start == 5)
                transform.position = player.transform.position + transform.right * -260;
            else
                transform.position = player.transform.position + transform.forward * -260;
            set = true;
        }
        else
        {
            
            transform.position = Vector3.MoveTowards(transform.position, oldPlayerPos, Vector3.Distance(newTPos, oldPlayerPos)*Time.fixedDeltaTime);
            
            
        }
        
    }
    void OnGUI()
    {
        GUIStyle headerText = new GUIStyle();
        GUIStyle subText = new GUIStyle();
        headerText.fontSize = 100;
        headerText.alignment = TextAnchor.MiddleCenter;
        headerText.fontStyle = FontStyle.Bold;
        subText.fontSize = 20;
        subText.alignment = TextAnchor.MiddleCenter;
        
    }
}
