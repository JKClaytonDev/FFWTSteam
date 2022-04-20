using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGravity : MonoBehaviour {
    float inwater;
	// Use this for initialization
	void Start () {
        inwater = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        

        

    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject target in player)
        {
            target.GetComponent<FireScript>().inwater = 1;
            inwater = 1;
            Debug.Log("IN WATER");
        }
            

    }
    private void OnTriggerStay(Collider other)
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject target in player)
        {
            Debug.Log("IN WATER");
            target.GetComponent<FireScript>().inwater = 1;
            inwater = 1;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject target in player)
        {
            Debug.Log("OUT OF WATER");
            if (inwater == 1)
            {
                target.GetComponent<FireScript>().inwater = 0;
                inwater = 0;
            }
            
        }
        
    }
}

