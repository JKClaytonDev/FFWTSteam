using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class transition : MonoBehaviour
{
    public bool outro;
    public Vector3 target;
    public string scene;
    bool load;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().enabled = true;
        load = false;
        GetComponent<RectTransform>().position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (outro)
            GetComponent<RectTransform>().localScale *= 1.2f;
        else
            GetComponent<RectTransform>().localScale += (new Vector3(65.51821f, 22.262f, 11.262f) - GetComponent<RectTransform>().localScale) * Time.deltaTime * 5;
        if (!load && outro && GetComponent<RectTransform>().position.y <= 5)
        {
            load = true;
            Debug.Log("TIME TO LOAD SCENE!");
            int buildIndex = SceneManager.GetActiveScene().buildIndex+1;
            PlayerPrefs.SetInt("SceneLoad", buildIndex);
            PlayerPrefs.Save();
            SceneManager.LoadScene(buildIndex); this.enabled = false;

        }
        else if (!(float.IsNaN(target.x) || float.IsNaN(target.y) || float.IsNaN(target.z)))
        {
            Vector3 pos = (10 * (target - GetComponent<RectTransform>().position) * (Time.deltaTime / 15)) / Time.timeScale;
            if (!(float.IsNaN(pos.x) || float.IsNaN(pos.y) || float.IsNaN(pos.z)))
            {
                if (outro)
                    GetComponent<RectTransform>().position += (10 * (target - GetComponent<RectTransform>().position) * (Time.deltaTime)) / Time.timeScale;
                else
                    GetComponent<RectTransform>().position += (10 * (target - GetComponent<RectTransform>().position) * (Time.deltaTime / 15)) / Time.timeScale;
            }
        }
        Vector2 poss = GetComponent<RectTransform>().position;
        if (poss.y < 0)
            poss.y = 0;
        GetComponent<RectTransform>().position = poss;
    }
}
