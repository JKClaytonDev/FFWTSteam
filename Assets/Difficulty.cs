using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Difficulty : MonoBehaviour
{
    public void setDifficulty(int diff)
    {
        PlayerPrefs.SetInt("Difficulty", diff);
        SceneManager.LoadScene("Level2");
    }
}
