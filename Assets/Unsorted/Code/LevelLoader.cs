using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScreen;
    public GameObject blackBox;
    public Vector3 defaultPos;
    string sceneIndex;
    bool imenabled;
    public Slider slider;
    public Text progressText;
    public GameObject backGround;
    public bool loading;
    private GameObject canv;
    private bool noClip;

    public void QuitGame()
    {
        Application.Quit();
    }
    void Start()
    {
        PlayerPrefs.SetFloat("Reverse", 0);
        PlayerPrefs.SetInt("NoClip", 0);
        noClip = false;
        blackBox.SetActive(false);
        imenabled = false;
    }

    public void LoadingScreen()
    {
        loadingScreen.SetActive(true);
        backGround.GetComponent<Animator>().SetBool("LoadDone", false);
        backGround.GetComponent<Animator>().SetBool("Play", true);

    }

    public void LoadLevel(string sceneIndexIn)
    {

        if (sceneIndexIn == "reverse" || sceneIndexIn == "backwards" || sceneIndexIn == "return" || sceneIndexIn == "runitback")
        {
            PlayerPrefs.SetInt("Reverse", 1);
            GameObject.Find("Main Camera").GetComponent<Animator>().enabled = false;
            GameObject.Find("Main Camera").transform.position -= transform.up * 60;

            return;
        }
        if (sceneIndexIn == "Shesez" || sceneIndexIn == "Boundary Break" || sceneIndexIn == "Noclip" || sceneIndexIn == "BoundaryBreak")
        {
            PlayerPrefs.SetInt("NoClip", 1);
            GameObject.Find("Main Camera").GetComponent<Animator>().enabled = false;
            GameObject.Find("Main Camera").transform.position -= transform.up * 60;

            return;
        }
        if (sceneIndex == "Ground1" || sceneIndexIn == "RetroGround1")
        {
            PlayerPrefs.SetInt("AirDash", 0);
            PlayerPrefs.SetInt("SuperBounce", 0);
            PlayerPrefs.SetInt("FastFiring", 0);
        }
        
        else if (sceneIndexIn == "Reset" || sceneIndexIn == "RESET" || sceneIndexIn == "Reset")
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetFloat("Mouse", 2);
            SceneManager.LoadScene("MainMenu");
            return;
        }
        List<string> scenesInBuild = new List<string>();
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            int lastSlash = scenePath.LastIndexOf("/");
            scenesInBuild.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
        }
        if (scenesInBuild.Contains(sceneIndexIn))
        {

            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                GameObject.Find("Buttons").SetActive(false);
                GameObject.Find("Main Camera").GetComponent<Animator>().enabled = false;
                GameObject.Find("Main Camera").transform.rotation = new Quaternion(90, -2.23f, 0, 0);
                GameObject.Find("TheSmashersLogo").GetComponent<RectTransform>().localPosition = new Vector2(-45, -134);
                GameObject.Find("TheSmashersLogo").GetComponent<RectTransform>().localScale = new Vector3(1, 0.7f, 0.5f);
                GameObject.Find("GameLogo").GetComponent<RectTransform>().localPosition = new Vector2(3, 21);
                GameObject.Find("GameLogo").GetComponent<RectTransform>().localScale = new Vector3(6, 2, 2);
            }
            blackBox.SetActive(true);
            sceneIndex = sceneIndexIn;
            blackBox.transform.position = defaultPos + transform.up * 500;
            imenabled = true;
            SceneManager.LoadScene(sceneIndex);
        }
    }
    public void lLevel(string sceneIndexIn)
    {
        SceneManager.LoadSceneAsync(sceneIndexIn);

    }
    public void LoadLevel(Text sceneIndex)
    {
        LoadLevel(sceneIndex.text);
    }


    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        loading = true;
        while (!backGround.GetComponent<AnimatorReadyIntro>().enabled)
        {
            yield return null;
        }
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }

    IEnumerator LoadAsynchronously(string sceneIndex)
    {
        loading = true;
        while (!backGround.GetComponent<AnimatorReadyIntro>().enabled)
        {
            yield return null;
        }
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }
    void Update()
    {
        if (GameObject.Find("Canvas") != null || canv == null)
        {
            canv = GameObject.Find("Canvas");
        }
        canv.SetActive(backGround.GetComponent<setCanvas>().active);

        if (!loading)
        {
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("LoadingScreen");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
    }
}
