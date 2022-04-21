using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour {
    private float PlayerHealth;
    private float showTime;
    Movement mvt;
	// Use this for initialization
	void Start () {
        showTime = 0;
        mvt = GameObject.FindObjectOfType<Movement>();

    }
	
	// Update is called once per frame
	void Update () {
        if (!mvt)
            mvt = GameObject.FindObjectOfType<Movement>();
        if (!mvt)
            return;
        if (mvt.PlayerHealth < PlayerHealth)
            showTime = Time.realtimeSinceStartup + 0.2f;
        if (showTime > Time.realtimeSinceStartup)
            transform.localScale = new Vector3(25, 25, 25);
        else
            transform.localScale = new Vector3(0, 0, 0);
        PlayerHealth = mvt.PlayerHealth;
	}
}
