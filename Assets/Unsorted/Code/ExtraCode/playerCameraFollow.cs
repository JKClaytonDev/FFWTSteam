using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCameraFollow : MonoBehaviour {
	public float recoil;    public AudioClip[] music;   float startupTime;
	// Use this for initialization
	void Start () {
        startupTime = Time.realtimeSinceStartup;
        if (music.Length >= 1 && GetComponent<AudioSource>() != null)
		GetComponent<AudioSource>().clip = music[Random.Range(0, music.Length)];
        GetComponent<AudioSource>().enabled = false;
        GetComponent<AudioSource>().enabled = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = GameObject.Find("Player").transform.position;
        transform.rotation = GameObject.Find("Player").transform.rotation;
		transform.Rotate(-recoil, (recoil/15)*Random.Range(-1, 1), (recoil/15)*Random.Range(-1, 1));
		recoil/=1.1f;
        if (Input.GetKey("c"))
        transform.Rotate(-19, 0, 17);
        //GetComponent<Camera>().farClipPlane = (int)(Time.realtimeSinceStartup-startupTime) * (Time.realtimeSinceStartup - startupTime) * 20;
	}
}
