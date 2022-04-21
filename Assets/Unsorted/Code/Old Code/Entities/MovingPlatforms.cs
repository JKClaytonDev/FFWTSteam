using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour {
    public GameObject part1;
    public float MoveTime;
    public GameObject part2;
    float ratio;
    float dir;
	// Use this for initialization
	void Start () {
        ratio = 1;
        dir = 1;
        part1.transform.localScale = new Vector3(0, 0, 0);
        part2.transform.localScale = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += (((part1.transform.position * ratio/(100*MoveTime)) + part2.transform.position * (1 - ratio/ (100 * MoveTime)))-transform.position)*Time.deltaTime*60*Time.timeScale;

        if (ratio > (100 * MoveTime))
        {
            ratio = (100 * MoveTime);
            dir = -1;
        }
        if (ratio < 0)
        {
            ratio = 0;
            dir = 1;
        }
        ratio += dir;
    }
    
}
