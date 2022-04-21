using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCrate : MonoBehaviour {
    private GameObject player;
    public AudioSource healSound;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetString("Mode", "Default");
        PlayerPrefs.Save();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("Player").GetComponent<Movement>().PlayerHealth = 100;

        healSound.Play();
            transform.position = new Vector3(-500, -500, -500);

            Debug.Log("got health");

        }
    }
    // Update is called once per frame
    void Update () {
    }
}
