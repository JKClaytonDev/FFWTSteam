using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    /*
            load game:
           topL 0.25, 1.25
           topR 0.40, 1.25
           bottomL 0.25, 0.03
           bottomR 0.40, 0.03

           new game:
           topL   0.5,1.25 
           topR    0.83,1.25
           bottomL     0.5,0.03
           bottomR     0.83,0.03
    */
    private bool tb;
    private bool MouseDown;
    private bool Animready;
    private bool bb;
    private bool quitb;
    private float mouseXratio;
    private float mouseYratio;
    private GUIStyle button;
    private GUIStyle button2;
    private GUIStyle quitbutton;
    private GUIStyle title;
    public Texture BoxTexture;
    private GameObject 
        
        Player;
    public bool introyet;
    private bool LoadingScene;
    public float ImReal;
    private Vector2 blackboxcurrent;
    private Vector2 blackboxtarget;
    private Vector2 introcurrent; private Vector2 introtarget;
    private bool difficulty;
    private bool ready;
    public bool specb;

    // Use this for initialization
    void Start () {
        difficulty = false;
        introyet = false;
        LoadingScene = false;
        //musicPlayer = GameObject.FindGameObjectWithTag("musicPlayer");
        mouseXratio = (Input.mousePosition.x / Screen.width);
        mouseYratio = (Input.mousePosition.y / Screen.height);
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
        title = new GUIStyle();
        title.normal.textColor = Color.white;
        title.fontStyle = FontStyle.Bold;
        title.fontSize = 120;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        introtarget = new Vector2(0, Screen.height * 2);
        introcurrent = new Vector2(0, 0);
        blackboxcurrent = new Vector2(0, Screen.height * 2);
        blackboxtarget = new Vector2(0, 0);
        ready = false;
    }
    void OnGUI()
    {

        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.black);
        texture.Apply();
        GUI.skin.box.normal.background = texture;
        Rect position = new Rect();
        position.position = blackboxcurrent;
        position.size = new Vector2(Screen.width, Screen.height);
        GUI.Box(position, GUIContent.none);
        if (introyet)
        {
            blackboxcurrent.y += (blackboxtarget.y - blackboxcurrent.y) * 0.2f;
        }
       

        if (!introyet) {
            mouseXratio = (Input.mousePosition.x / Screen.width);
            mouseYratio = (Input.mousePosition.y / Screen.height);

            //Debug.Log("x" + Input.mousePosition.x/ Screen.width + "     y" + Input.mousePosition.y / Screen.height);
            tb = false;
            bb = false;
            quitb = false;
            specb = false;

            if (mouseXratio < 0.26 && mouseYratio < 0.6 && mouseYratio > 0.5)
                tb = true;
            if (mouseXratio < 0.26 && mouseYratio < 0.5 && mouseYratio > 0.4)
                bb = true;
            if (mouseXratio < 0.26 && mouseYratio < 0.4 && mouseYratio > 0.3)
                quitb = true;
            if (mouseXratio < 0.26 && mouseYratio < 0.3 && mouseYratio > 0.2)
                specb = true;


            GUI.Label(new Rect(Screen.width * 0.015f, -75 + (Screen.height * 1.5f) / 10, 100, 20), "Flying", quitbutton);
            GUI.Label(new Rect(Screen.width * 0.05f, -75 + (Screen.height * 3f) / 10, 100, 20), "Frags", quitbutton);

            if (difficulty)
            {
                if (tb)
                    GUI.Label(new Rect(Screen.width * 0.15f, -75 + (Screen.height * 5f) / 10, 100, 20), "Easy", button2);
                else
                    GUI.Label(new Rect(Screen.width * 0.1f, -75 + (Screen.height * 5f) / 10, 100, 20), "Easy", button2);

                if (bb)
                    GUI.Label(new Rect(Screen.width * 0.15f, -75 + (Screen.height * 6f) / 10, 100, 20), "Normal", button);
                else
                    GUI.Label(new Rect(Screen.width * 0.1f, -75 + (Screen.height * 6f) / 10, 100, 20), "Normal", button);

                if (quitb)
                    GUI.Label(new Rect(Screen.width * 0.15f, -75 + (Screen.height * 7f) / 10, 100, 20), "Hard", button);
                else
                    GUI.Label(new Rect(Screen.width * 0.1f, -75 + (Screen.height * 7f) / 10, 100, 20), "Hard", button);

                if (specb)
                    GUI.Label(new Rect(Screen.width * 0.15f, -75 + (Screen.height * 8f) / 10, 100, 20), "One Shot", button);
                else
                    GUI.Label(new Rect(Screen.width * 0.1f, -75 + (Screen.height * 8f) / 10, 100, 20), "One Shot", button);
            }
            else
            {
                if (tb)
                    GUI.Label(new Rect(Screen.width * 0.15f, -75 + (Screen.height * 5f) / 10, 100, 20), "New Game", button2);
                else
                    GUI.Label(new Rect(Screen.width * 0.1f, -75 + (Screen.height * 5f) / 10, 100, 20), "New Game", button2);

                if (bb)
                    GUI.Label(new Rect(Screen.width * 0.15f, -75 + (Screen.height * 6f) / 10, 100, 20), "Load", button);
                else
                    GUI.Label(new Rect(Screen.width * 0.1f, -75 + (Screen.height * 6f) / 10, 100, 20), "Load", button);

                if (quitb)
                    GUI.Label(new Rect(Screen.width * 0.15f, -75 + (Screen.height * 7f) / 10, 100, 20), "Quit", button);
                else
                    GUI.Label(new Rect(Screen.width * 0.1f, -75 + (Screen.height * 7f) / 10, 100, 20), "Quit", button);
            }
                //box = musicPlayer.GetComponent<GlobalControl>().panel;
                //GameObject box = musicPlayer;
        }

        if (difficulty)
        {
            if (!Input.GetMouseButtonDown(0))
            {
                MouseDown = false;
            }
             if (Input.GetMouseButtonDown(0) && (tb || bb || quitb || specb) && MouseDown == false)
            {
                PlayerPrefs.SetFloat("Difficulty", 1);
                PlayerPrefs.SetString("lastLevel", "Level1");
                PlayerPrefs.SetFloat("AssaultRifle", 0);
                PlayerPrefs.SetFloat("Shotgun", 1);
                PlayerPrefs.SetFloat("Revolver", 0);
                PlayerPrefs.SetFloat("Chaingun", 0);
                PlayerPrefs.SetFloat("RocketLauncher", 0);

                if (quitb)
                    {
                        PlayerPrefs.SetInt("Difficulty", 1);
                    }
                    else if (tb)
                    {
                        PlayerPrefs.SetInt("Difficulty", 3);
                    }
                    else if (bb)
                    {
                        PlayerPrefs.SetInt("Difficulty", 2);
                    }                    
                    else
                    {
                        PlayerPrefs.SetInt("Difficulty", 4);
                    }

                introyet = true;
            }
            
            
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && (tb || bb || quitb))
            {
                if (tb)
                {
                    MouseDown = true;
                    difficulty = true;
                }
                if (bb)
                {
                    
                    introyet = true;
                }
                if (quitb)
                {
                    Application.Quit();
                }
            }
            if (blackboxcurrent == blackboxtarget)
            {
                if (quitb)
                {
                    Application.Quit();
                }
                else if (tb)
                {
                    difficulty = true;
                    PlayerPrefs.SetFloat("Difficulty", 1);
                    PlayerPrefs.SetString("lastLevel", "Level1");
                    PlayerPrefs.SetFloat("AssaultRifle", 0);
                    PlayerPrefs.SetFloat("Shotgun", 1);
                    PlayerPrefs.SetFloat("Revolver", 0);
                    PlayerPrefs.SetFloat("Chaingun", 0);
                    PlayerPrefs.SetFloat("RocketLauncher", 0);
                }

                ready = true;
            }




        }
            


    }
        // Update is called once per frame
        void Update () {
        if (blackboxcurrent == blackboxtarget)
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("lastLevel"));
            LoadingScene = true;
        }
        Debug.Log("Difficulty is: " + PlayerPrefs.GetInt("Difficulty"));
        //Debug.Log("x" + Input.mousePosition.x / Screen.width + "     y" + Input.mousePosition.y / Screen.height);
    }

}
