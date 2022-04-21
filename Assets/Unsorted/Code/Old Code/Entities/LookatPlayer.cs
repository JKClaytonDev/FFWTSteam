using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatPlayer : MonoBehaviour {
    
    public TextMesh DamageText;
    public GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        
    }
	
	// Update is called once per frame
	void Update () {
        if (player)
        transform.LookAt(player.transform);
        if (player == null)
            player = GameObject.Find("Player");
    }
}
