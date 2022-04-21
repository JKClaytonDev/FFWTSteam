using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadNextScene : MonoBehaviour
{
    AnimationEvent evt;
    // Start is called before the first frame update
    void Start()
    {
        evt = new AnimationEvent();
        evt.functionName = "loadNextSceneAnim";
    }
    public void loadNextSceneAnim()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameObject.SetActive(false);
    }

    
}
