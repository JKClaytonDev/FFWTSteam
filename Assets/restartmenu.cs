using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class restartmenu : MonoBehaviour
{
    public void loadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
