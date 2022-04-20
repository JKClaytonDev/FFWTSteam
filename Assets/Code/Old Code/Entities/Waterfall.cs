using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityStandardAssets.Utility;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Waterfall : MonoBehaviour
{
    string[] Modes = { "Normal", "Normal", "Normal", "Normal", "Normal", "Normal", "Normal", "Normal" };
    int selected;
    GameObject g;
    bool mouseOver;
    public float WF_speed = 0.75f;

    private Renderer WF_renderer;

    void OnMouseEnter()
    {
        mouseOver = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("POINTER ENTERED");
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("Mouse"))
            PlayerPrefs.SetFloat("Mouse", 2);
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayerPrefs.SetInt("NoClip", 0);
            
        }
        GameObject[] cubes = Resources.FindObjectsOfTypeAll<GameObject>();
        GameObject ga;
        ga = GameObject.Find("Cube");
        foreach (GameObject c in cubes)
        {
            if (c.name == "Cube")
                ga = c;
        }



        if (!PlayerPrefs.HasKey("Mode"))
            PlayerPrefs.SetString("Mode", "Normal");
        Time.timeScale = 1;
        selected = 1;
        if (gameObject.name != "Difficulty")
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                PlayerPrefs.SetInt("Chaingun", 0);
                PlayerPrefs.SetInt("Mirror", 0);
                PlayerPrefs.SetInt("TinyPlayer", 0);
                PlayerPrefs.SetInt("SuperHot", 0);
                PlayerPrefs.SetInt("MoonGravity", 0);
                PlayerPrefs.SetInt("NoHUD", 0);
                PlayerPrefs.SetInt("NoClip", 0);
                PlayerPrefs.SetInt("BunnyHop", 0);
                PlayerPrefs.SetInt("Reverse", 0);
                PlayerPrefs.SetInt("AllGuns", 0);
                PlayerPrefs.SetInt("InfAmmo", 0);
                /*
                GameObject k = Instantiate(GameObject.Find("Workshop"));
                k.GetComponent<Text>().text = "Left / Right to change mode";
                k.GetComponent<Text>().fontSize = 25;
                Destroy(k.GetComponent<Button>());
                k.transform.parent = GameObject.Find("Buttons").transform;
                k.GetComponent<RectTransform>().localPosition = new Vector3(969, -740, 68);
                k.transform.localScale = new Vector3(1.666143f, 1.666143f, 1.666143f);
                k.name = "menu";

                g = Instantiate(GameObject.Find("Workshop"));
                g.GetComponent<Text>().text = "Difficulty";
                Destroy(g.GetComponent<Button>());
                g.transform.parent = GameObject.Find("Buttons").transform;
                g.GetComponent<RectTransform>().localPosition = new Vector3(969, -646, 68);
                g.transform.localScale = new Vector3(1.666143f, 1.666143f, 1.666143f);
                g.name = "Difficulty";
                */
                CanvasScaler[] canvs = GameObject.FindObjectsOfType<CanvasScaler>();
                foreach (CanvasScaler canv in canvs)
                {
                    canv.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                    canv.referenceResolution = new Vector2(1000, 600);
                    Debug.Log("Hi!!! " + canv.name);
                    canv.name = "Fortnite";
                }

            }
            if (GetComponent<Renderer>())
                WF_renderer = GetComponent<Renderer>();
            else if (GetComponent<MeshRenderer>())
                WF_renderer = GetComponent<MeshRenderer>();
            else if (GetComponent<SkinnedMeshRenderer>())
                WF_renderer = GetComponent<SkinnedMeshRenderer>();
        }
        if (PlayerPrefs.GetFloat("Completed") == 1)
            GameObject.Find("SpaceShipasdf").SetActive(true);
        else if (GameObject.Find("SpaceShipasdf"))
            GameObject.Find("SpaceShipasdf").SetActive(false);
        /*
        GameObject Controls = Instantiate(GameObject.Find("Exit"));
        Controls.name = "Controls";
        Controls.transform.parent = GameObject.Find("Exit").transform.parent;
        Controls.GetComponent<RectTransform>().localPosition = GameObject.Find("Exit").GetComponent<RectTransform>().localPosition;
        GameObject.Find("Exit").GetComponent<RectTransform>().localPosition -= new Vector3(0, 106, 0);
        Controls.GetComponent<Text>().text = "Controls";
        Controls.GetComponent<Text>().fontSize = 40;
        */
        
        Debug.Log("LOL");
        if (1 == 1)
        {
            GameObject.Find("Workshop").GetComponent<Text>().text = "     Bonus Content";
            GameObject.Find("GameLogo").GetComponent<RectTransform>().localPosition = new Vector2(-282, 93);
            GameObject.Find("GameLogo").GetComponent<RectTransform>().localScale = new Vector3(2.355616f, 0.7357447f, 0.51703377f);
            GameObject.Find("Buttons").transform.localPosition = new Vector3(-334.3f, 26.8f, -16.1f);
            GameObject.Find("Buttons").transform.localScale = new Vector3(0.2491128f, 0.2491128f, 0.2491128f);
            GameObject.Find("New Game").GetComponent<RectTransform>().localPosition = new Vector3(43.3f, 13.56702f, 64.41388f);
            GameObject.Find("Continue").GetComponent<RectTransform>().localPosition = new Vector3(6.8f, -93.06897f, 65);
            GameObject.Find("Workshop").GetComponent<RectTransform>().localPosition = new Vector3(60, -205.37f, 64.41f);
            GameObject.Find("Settings").GetComponent<RectTransform>().localPosition = new Vector3(-7.75f, -311, 65);
            GameObject.Find("Exit").GetComponent<RectTransform>().localPosition = new Vector2(-75, -400);
            GameObject.Find("Main Camera").transform.position = new Vector3(-19, -60.2f, -10);
            GameObject.Find("Main Camera").transform.rotation = new Quaternion(-7.95f, -3.28f, 0, 0);
            GameObject.Find("Main Camera").GetComponent<Camera>().fieldOfView = 52.2f;
            
            //GameObject ga = GameObject.Find("Cube");
            /*
            ga.SetActive(true);
            GameObject g1 = Instantiate(ga);
            GameObject g2 = Instantiate(ga);
            GameObject g3 = Instantiate(ga);
            GameObject g4 = Instantiate(ga);
            GameObject g5 = Instantiate(ga);
            GameObject g6 = Instantiate(ga);
            GameObject g7 = Instantiate(ga);
            GameObject g8 = Instantiate(ga);
            GameObject g9 = Instantiate(ga);
            GameObject g10 = Instantiate(ga);
            GameObject g11 = Instantiate(ga);
            GameObject g12 = Instantiate(ga);


            g1.transform.position = new Vector3(79, 80, 432);
            g1.transform.Rotate(29, -147, 4, 0);
            g1.transform.localScale = new Vector3(40.5f, 15, 233);

            g2.transform.position = new Vector3(90, 115, 446);
            g2.transform.Rotate(29, -147, 4, 0);
            g2.transform.localScale = new Vector3(40.5f, 34, 135);

            g3.transform.position = new Vector3(80, 105, 430);
            g3.transform.Rotate(29, -147, 4, 0);
            g3.transform.localScale = new Vector3(154, 34, 40);


            g4.transform.position = new Vector3(137, 92, 378);
            g4.transform.Rotate(24 + 14, -119 - 178, 16 - 23, 0);
            g4.transform.localScale = new Vector3(40.5f, 34.17f, 35.8f);


            g5.transform.position = new Vector3(42, 60, 371);
            g5.transform.Rotate(38, -146, 4, 0);
            g5.transform.localScale = new Vector3(40.5f, 34, 86);


            g6.transform.position = new Vector3(184, 146, 464);
            g6.transform.Rotate(29, -147, 4, 0);
            g6.transform.localScale = new Vector3(60.6f, 34, 21.2f);


            g7.transform.position = new Vector3(198, 167, 474);
            g7.transform.Rotate(29, -147, 4, 0);
            g7.transform.localScale = new Vector3(60.6f, 34, 21.2f);


            g8.transform.position = new Vector3(2.2f, 101, 459);
            g8.transform.Rotate(41, 34, 135, 0);
            g8.transform.localScale = new Vector3(40.5f, 34.17f, 35.8f);


            g9.transform.position = new Vector3(61, 154.5f, 538);
            g9.transform.Rotate(28, -147, 3, 0);
            g9.transform.localScale = new Vector3(60.6f, 34, 21);


            g10.transform.position = new Vector3(75, 175, 549);
            g10.transform.Rotate(28, -147, 3.6f, 0);
            g10.transform.localScale = new Vector3(60.6f, 34, 21);


            g11.transform.position = new Vector3(89, 145.7f, 507);
            g11.transform.Rotate(22.7f, -114, 18, 0);
            g11.transform.localScale = new Vector3(60.6f, 34, 21);


            g12.transform.position = new Vector3(141, 140, 470);
            g12.transform.Rotate(-18.902f, -26, 22, 0);
            g12.transform.localScale = new Vector3(60.6f, 34, 21);
            */
            ga.SetActive(false);
            
            GameObject.Find("menu").GetComponent<RectTransform>().localPosition = new Vector2(2696, -950);
            GameObject.Find("Difficulty").GetComponent<RectTransform>().localPosition = new Vector2(2696, -846);
            Destroy(GameObject.Find("Particle System"));
            GameObject.Find("Fortnite").GetComponent<CanvasScaler>().referenceResolution = new Vector2(855, 855);
            //AudioClip cc = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Sounds/
            //OldMusic/e s c p Above the Clouds [Chill Electro] from Royalty Free Planet.mp3");
            //GameObject.Find("Main Camera").GetComponent<AudioSource>().clip = cc;
            //GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
            //GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
        }
        if (GameObject.Find("Main Camera"))
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume /= 2;
    }

    void Update()
    {
        PlayerPrefs.SetString("Mode", "Normal");
        return;
        if (gameObject.name != "Difficulty")
        {
            if (SceneManager.GetActiveScene().name == "MainMenu" && g.GetComponent<Text>())
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                    selected++;
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                    selected--;
                selected = Mathf.Min(Modes.Length - 1, selected);
                selected = Mathf.Max(0, selected);
                PlayerPrefs.SetString("Mode", Modes[selected]);
                Debug.Log("Mode " + PlayerPrefs.GetString("Mode"));
                g.GetComponent<Text>().text = Modes[selected];

                if (gameObject.name == "Difficulty")
                {
                    GetComponent<Text>().text = "" + mouseOver;
                }
            }
        }
    }
}
