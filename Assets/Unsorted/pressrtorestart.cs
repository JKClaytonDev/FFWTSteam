using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pressrtorestart : MonoBehaviour
{
    AnimationEvent evt;
    // Start is called before the first frame update
    void Start()
    {
        evt = new AnimationEvent();
        evt.functionName = "SceneLoad";
    }
    public void SceneLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
