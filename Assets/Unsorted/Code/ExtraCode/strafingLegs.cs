using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strafingLegs : MonoBehaviour {
    private float calculateTime;
    public float extraSpeed;
    public Vector3 randomTarget;
    private Vector3 start;
    public float extraArea;
    Quaternion originalRot;
	// Use this for initialization
	void Start () {
        calculateTime = 0;
        start = transform.position;
        originalRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (calculateTime < 1 || Vector3.Distance(transform.position, randomTarget) < 3)
        {
            calculateTime = 30 * (1 + (extraArea / 5));
            randomTarget = new Vector3(start.x + (Random.insideUnitCircle * (20 + extraArea)).x, transform.position.y, start.z + (Random.insideUnitCircle * (20 + extraArea)).y);
            
        }
        transform.position += (extraSpeed + 1) * ((Vector3.MoveTowards(transform.position, randomTarget, 1)) - transform.position) / 5;
        calculateTime--;
    }
}
