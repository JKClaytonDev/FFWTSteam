using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GlobalControl : MonoBehaviour
{
    /*
    public static GlobalControl Instance;
    public PostProcessingProfile blur;
    public float lastLevel;
    public string loadScene;
    public float time;
    public GameObject player;
    public AudioSource MusicBox;
    public AudioClip[] levelmusic;
    public Canvas SmoothAnim;
    public GameObject panel;
    public GameObject intro;
    public double SensX;
    public float SensY;
    private string tempscene;
    public float animDoneTime;
    private bool JustSet;
    private bool ready;

    void Update()

    {
        if (!PlayerPrefs.HasKey("MouseSens"))
            PlayerPrefs.SetFloat("MouseSens", 1);
        if (PlayerPrefs.GetFloat("MouseSens") <= 0)
            PlayerPrefs.SetFloat("MouseSens", 1);

        if (SensX > 0.2f)
        {
            SensX *= 10;
            SensX = Mathf.Round((float)SensX);
            SensX /= 10;
        }

            if (SensX != 1)
            PlayerPrefs.SetFloat("MouseSens", (float)(SensX*200));

            SensX = PlayerPrefs.GetFloat("MouseSens")/200;

        PlayerPrefs.Save();

        Debug.Log("Sensitivity: " + SensX);
        if (ready && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("MOVED");
            if (SensX <= 0.2)
                SensX *= 2;
            else
                SensX += 0.1;
            ready = false;
            time = Time.realtimeSinceStartup + 0.3f ;
        }
        else if (ready && Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("MOVED");
            if (SensX <= 0.2)
                SensX /=2;
            else
               SensX -= 0.1;
           ready = false;
            time = Time.realtimeSinceStartup + 0.3f;
        }
        else 
        {
            ready = true;
        }
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            MusicBox.Stop();
        }
        else if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            for (int i = 1; i <= levelmusic.Length; i++)
            {
                if (("Level" + i) == SceneManager.GetActiveScene().name)
                {
                    if (MusicBox.clip != levelmusic[i])
                    {
                        MusicBox.Stop();
                        MusicBox.clip = levelmusic[i];
                        Debug.Log("Playing " + MusicBox.clip.name);
                        if (!MusicBox.isPlaying)
                            MusicBox.Play();

                    }

                }
            }
        }

        if (GameObject.Find("Player"))
        {
            player = GameObject.Find("Player");
            Debug.Log(player.GetComponent<FireScript>().startuptime);
        }

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            bool transitionDone = (panel.transform.localScale.y == 1);
            if (loadScene != "" && loadScene != "null")
            {
                JustSet = true;
                animDoneTime = Time.realtimeSinceStartup + 1;


                tempscene = (loadScene + "");

            }
            if (Time.realtimeSinceStartup > animDoneTime && animDoneTime != 0 && JustSet)
            {
                JustSet = false;
                loadScene = "";
                Debug.Log("IM TRYING MY BEST OK!!");
                Animator intro = GetComponent<GlobalControl>().panel.GetComponent<Animator>();
                intro.enabled = false;
                if (GameObject.Find("Player"))
                {
                    player = GameObject.Find("Player");
                }
                if (SceneManager.GetActiveScene().name == "MainMenu" || (Time.realtimeSinceStartup > 3 + player.GetComponent<FireScript>().startuptime))
                    SceneManager.LoadScene(tempscene);
            }

            if (animDoneTime == 0)
            {
                panel.GetComponent<RectTransform>().position = new Vector3(10000, 10000, 0);
            }
            else
            {
                panel.GetComponent<RectTransform>().position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            }
        }
        else
        {
            if (panel)
            panel.GetComponent<RectTransform>().position = new Vector3(10000, 10000, 0);
            if (loadScene != "")
            {
                tempscene = (loadScene + "");
                loadScene = "";
                SceneManager.LoadScene(tempscene);
                
            }
            }


    }
    private void OnGUI()
    {
        if (Time.realtimeSinceStartup < time)
        {
            GUIStyle labelText = new GUIStyle();
            GUIStyle numText = new GUIStyle();
            labelText.fontSize = 20;
            numText.fontSize = 150;
            labelText.fontStyle = FontStyle.Bold;
            numText.alignment = TextAnchor.MiddleCenter;


            GUI.Label(new Rect(Screen.width / 2, (Screen.height / 2), 100, 0), ("  " + SensX), numText);
        }
    }
    void Awake()
    {
        tag = "musicPlayer";


            if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    */
}