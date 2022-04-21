using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelName : MonoBehaviour
{
    public string[] SceneNames;
    public string[] LevelNames;
    public AudioClip[] levelMusic;
    public AudioSource source;
    public Movement player;
    public GameObject lowAmmo;
    public GameObject noAmmo;
    public GameObject health;
    public GameObject ammo;
    public GameObject enemies;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SceneNames.Length; i++) {
                if (SceneManager.GetActiveScene().name == SceneNames[i])
                {
                GetComponent<Text>().text = LevelNames[i];
                source.clip = levelMusic[i];
                source.loop = true;
                source.Play();
                }
        }   
    }
    void FixedUpdate()
    {
        
        {
            health.GetComponent<Text>().text = "" + player.PlayerHealth;
            ammo.GetComponent<Text>().text = "" + (player.weaponAmmo[player.animController.GetInteger("WeaponNum") - 1]-1);
            noAmmo.SetActive(player.weaponAmmo[player.animController.GetInteger("WeaponNum") - 1] - 1 == 0);
            lowAmmo.SetActive(!noAmmo.activeInHierarchy && player.weaponAmmo[player.animController.GetInteger("WeaponNum") - 1] - 1 < player.PlayerOriginalAmmo[player.animController.GetInteger("WeaponNum") - 1]/3);
            if (player.loadLevel || player.enemycount > 10)
            {
                if (enemies.transform.parent)
                enemies.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                if(enemies.transform.parent)
                enemies.transform.parent.gameObject.SetActive(true);
                enemies.GetComponent<Text>().text = "" + player.enemycount;
            }
        }
    }
}
