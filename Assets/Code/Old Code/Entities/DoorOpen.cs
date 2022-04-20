using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {
    public float KillsNeeded;
    public Vector3 Direction;
    public float Distance;
    public bool activated;
    private float DistanceSoFar;
    // Use this for initialization
    void Start () {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        KillsNeeded = Enemies.Length - KillsNeeded;
        DistanceSoFar = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (activated) {
            transform.position += Direction;
            DistanceSoFar++;
            if (DistanceSoFar > Distance)
                Destroy(gameObject);
        }
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (!activated && Enemies.Length <= KillsNeeded)
        {
            activated = true;
        }

	}
}
