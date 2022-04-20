using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadScene : MonoBehaviour {
    float loadTime;
    public string SceneName;
    public GameObject destroy;
	// Use this for initialization
	void Start () {
        loadTime = Time.realtimeSinceStartup + 1;
	}
    public void load(string scene)
    {
        if (destroy)
            Destroy(destroy);
            SceneManager.LoadScene(scene);
        
    }
    public void loadNext()
    {
        if (destroy)
            Destroy(destroy);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    // Update is called once per frame
    void Update() {
        if (Time.realtimeSinceStartup > loadTime)
        {
            loadTime = Time.realtimeSinceStartup + 256;
            GameObject[] imStuff = FindObjectsOfType(typeof(GameObject)) as GameObject[];
            foreach (GameObject item in imStuff)
            {
                if (item != gameObject)
                item.SetActive(false);
            }
            if (SceneName == "BossFight" && Random.Range(1, 10) == 1)
                Application.OpenURL("https://drive.google.com/file/d/1V0DWLaTkaL01qQC9ax4nAFUJPQy5CS05/view");
            Application.LoadLevel(SceneName);
        }
        
	}

}
