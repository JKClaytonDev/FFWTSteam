using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalLevel : MonoBehaviour
{
    public GameObject exit;
    public bool useCL;
    public string CustomLevel;
    public string loadLevelName;
    public string LevelScene;
    public GameObject player;
    // Use this for initialization

    void Start()
    {


        this.name = "LevelPortal";
        /*
        if (SceneManager.GetActiveScene().name != "Level4")
        {
            if (transform.localScale.y <= 1.715404f)
            {
                transform.localScale *= 3;
                transform.position += Vector3.up * 20;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit))
                    transform.position = hit.point + Vector3.up * (57.27f - 48.074f) * 3;
                else
                    transform.position -= Vector3.up * 20;
            }
        }
        */
        Object[] ec = FindObjectsOfType<enemyCount>();
        if (ec.Length > 0)
        {
            foreach (GameObject e in ec)
                Destroy(e);
        }

        Debug.Log("useCL");
        Debug.Log(CustomLevel);
    }
    // Update is called once per frame

    void Update()
    {
        if (player == null)
            player = GameObject.Find("Player");
        else if (Time.frameCount % 5 == 0 && Time.realtimeSinceStartup > 5)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < (Vector3.Distance(transform.position, exit.transform.position)))
            {
                
                Movement m = player.GetComponent<Movement>();
                PlayerPrefs.SetInt("EqWP", player.GetComponent<Movement>().animController.GetInteger("WeaponNum"));
                PlayerPrefs.SetInt("NextSceneName", SceneManager.GetActiveScene().buildIndex + 1);
                for (int i = 0; i<m.equippedWeapons.Length; i++)
                {
                    int isTrue = 0;
                    if (m.equippedWeapons[i])
                        isTrue = 1;
                    PlayerPrefs.SetInt(i+"", isTrue);
                }
                if (FindObjectOfType<NextLevelName>())
                {
                    Debug.Log("THIS IS ME ITS ME I USED THE LOADNEXTSCENE THATSD ME HASHASHASDHASHDAHSDHASDDHSAD");
                    SceneManager.LoadScene(FindObjectOfType<NextLevelName>().nextLevel);
                    this.enabled = false;
                    return;
                }
                /*
                if (FindObjectOfType<musicHost>())
                {
                    musicHost host = FindObjectOfType<musicHost>();
                    int foundvalue = -1;
                    string currentScene = SceneManager.GetActiveScene().name;
                    for (int i = 0; i<host.sceneOrder.Length; i++)
                    {
                        if (host.sceneOrder[i] == currentScene)
                            foundvalue = i;
                    }
                    if (foundvalue != -1)
                    {
                        Debug.Log("USED FOUND VALUE " + host.sceneOrder[foundvalue + 1]);
                        SceneManager.LoadScene(host.sceneOrder[foundvalue + 1]);
                        gameObject.SetActive(false);
                        return;
                        
                    }
                }
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
                return;
                int buildIndex = SceneManager.GetActiveScene().buildIndex + 1;
                
                PlayerPrefs.SetInt("SceneLoad", buildIndex);
                PlayerPrefs.Save();
                SceneManager.LoadScene("Loading"); this.enabled = false;
                return;
                    if (SceneManager.GetActiveScene().name == "Ground11")
                    {
                        SceneManager.LoadScene("Upgrade");
                        return;
                    }
                    if (SceneManager.GetActiveScene().name == "Ground111")
                {
                    SceneManager.LoadScene("bossCutScene");
                    return;
                }
                if (SceneManager.GetActiveScene().name == "Ground110")
                {
                    SceneManager.LoadScene("Ground111");
                    return;
                }
                if (SceneManager.GetActiveScene().name == "Level7")
                {
                    SceneManager.LoadScene("Level8");
                    return;
                }
                if (SceneManager.GetActiveScene().name == "Level8")
                {
                    SceneManager.LoadScene("Level9");
                    return;
                }
                if (SceneManager.GetActiveScene().name == "Ground1")
                {
                    SceneManager.LoadScene("Level2");
                    return;
                }
                if (SceneManager.GetActiveScene().name == "Level2")
                {
                    SceneManager.LoadScene("Level3");
                    return;
                }
                if (SceneManager.GetActiveScene().name == "Level5")
                {
                    SceneManager.LoadScene("Level6");
                    return;
                }
                if (SceneManager.GetActiveScene().name == "Level6")
                {
                    SceneManager.LoadScene("Level7");
                    return;
                }
                if (SceneManager.GetActiveScene().name == "Ground11")
                    PlayerPrefs.SetInt("LoadingScene", 41);
                else
                    PlayerPrefs.SetInt("LoadingScene", SceneManager.GetActiveScene().buildIndex + 1);
                
                */
                return;
                /*
                if (SceneManager.GetActiveScene().name == "Ground11")
                {
                    SceneManager.LoadScene("upgrade");
                    return;
                }
                if (SceneManager.GetActiveScene().name == "Level2")
                {
                    SceneManager.LoadScene("Level3");
                    return;
                }
                foreach (Object o in FindObjectsOfType<enemyHealth>())
                    Destroy(o);

                if (!useCL)
                {
                    Debug.Log("OK SUCK MY COCK NOW");
                    string Sname = SceneManager.GetActiveScene().name;
                    string scene = Sname.Substring(0, Sname.Length - 1);
                    char s = Sname.ToCharArray()[Sname.Length - 1];
                    int c = (int)char.GetNumericValue(s);
                    c++;
                    if (player)
                    {
                        if (player.GetComponent<Movement>().transition)
                        {
                            player.GetComponent<Movement>().transition.GetComponent<transition>().target = new Vector3(0, 0, 0);
                            player.GetComponent<Movement>().transition.GetComponent<transition>().outro = true;
                            player.GetComponent<Movement>().transition.GetComponent<transition>().scene = (scene + c);
                            return;
                        }
                        else
                            SceneManager.LoadScene(scene + c);
                    }
                    else
                        SceneManager.LoadScene(scene + c);
                }
                else
                {
                    if (player)
                    {
                        if (player.GetComponent<Movement>().transition)
                        {
                            player.GetComponent<Movement>().transition.GetComponent<transition>().target = new Vector3(0, 0, 0);
                            player.GetComponent<Movement>().transition.GetComponent<transition>().outro = true;
                            player.GetComponent<Movement>().transition.GetComponent<transition>().scene = (CustomLevel);
                            return;
                        }
                        else
                            SceneManager.LoadScene(CustomLevel);
                    }
                    else
                        SceneManager.LoadScene(CustomLevel);
                }
                */
            }
        }
    }
}
